using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoDeDados;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioObra : IRepositorioObra
    {
        private readonly DbCodersGrowth _db;

        public RepositorioObra(DbCodersGrowth conexaoComBancoDeDados) 
        {
            _db = conexaoComBancoDeDados;
        }

        public List<Obra> ObterTodos(FiltroObra? filtroObra = null)
        {
            var query = Filtrar(filtroObra);
            var obrasFiltradas = query.ToList();

            return obrasFiltradas;
        }

        public Obra ObterPorId(int id)
        {
            var obraRequisitada = _db.Obras.FirstOrDefault(o => o.Id == id)
                ?? throw new Exception("Obra não encontrada.");

            return obraRequisitada;
        }

        public Obra Criar(Obra obra)
        {
            obra.Id = _db.InsertWithInt32Identity(obra);
            SalvarGeneros(obra.Id, obra.GenerosParaCriacao);

            return obra;
        }

        public Obra Editar(Obra obra)
        {
            var obraNoBanco = ObterPorId(obra.Id);

            var generosAnteriores = ObterGenerosVinculados(obra.Id);
            var generosAtualizados = obra.GenerosParaCriacao;

            var hashSetGenerosAnteriores = new HashSet<string>(generosAnteriores);
            var hashSetGenerosAtualizados = new HashSet<string>(generosAtualizados);

            List<string> generosParaRemover = new();
            List<string> generosParaAdicionar = new();

            generosAnteriores.ForEach(genero =>
            {
                if (!hashSetGenerosAtualizados.Contains(genero))
                {
                    generosParaRemover.Add(genero);
                }
            });

            generosAtualizados.ForEach(genero =>
            {
                if (!hashSetGenerosAnteriores.Contains(genero))
                {
                    generosParaAdicionar.Add(genero);
                }
            });

            try   
            {
                _db.Update(obra);
                RemoverGeneros(obra.Id, generosParaRemover);
                SalvarGeneros(obra.Id, generosParaAdicionar);
            }
            catch (Exception ex) 
            {
                throw new Exception("Não foi possível editar a obra.");            
            }

            return obra;
        }

        public void Remover(int id)
        {
            var obraNoBanco = _db.Obras.FirstOrDefault(o => o.Id == id)
                ?? throw new Exception("Obra não encontrada.");

            try
            {
                _db.Obras
                    .Where(o => o.Id == id)
                    .Delete();

                RemoverComprasVinculadas();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível remover a obra selecionada.");
            }
        }

        private void SalvarGeneros(int idObra, List<string> generos)
        {
            foreach (var item in generos)
            {
                _db.Execute(
                    $"INSERT INTO GenerosObras (ObraId, Genero) VALUES (@idObra, @item)",
                    new DataParameter("@idObra", idObra),
                    new DataParameter("@item", @item)
                );
            }
        }

        private void RemoverGeneros(int obraId, List<string> generos)
        {
            generos.ForEach(genero =>
            {
                _db.Execute(
                    $"DELETE FROM GenerosObras WHERE ObraId = @obraId AND Genero = @genero",
                    new DataParameter("@obraId", obraId),
                    new DataParameter("@genero", genero) 
                );
            });
        }

        private void RemoverComprasVinculadas()
        {
            _db.Execute($"DELETE FROM ComprasObras Where ObraId = NULL");
        }

        public List<string> ObterGenerosVinculados(int obraId)
        {
            var generosVinculados = _db.Query<string>($"SELECT Genero FROM GenerosObras " +
                                                      $"WHERE ObraId = @obraId", new { obraId }).ToList();

            return generosVinculados;
        }

        public IQueryable<Obra> Filtrar(FiltroObra filtroObra) 
        {
            IQueryable<Obra> obras = _db.Obras;

            if (filtroObra == null)
            {
                return obras;
            }

            if (!string.IsNullOrEmpty(filtroObra.AutorObra))
            {
                obras = obras.Where(o => o.Autor.Contains(filtroObra.AutorObra));
            }

            if (!string.IsNullOrEmpty(filtroObra.TituloObra))
            {
                obras = obras.Where(o => o.Titulo.Contains(filtroObra.TituloObra));
            }

            if (filtroObra.FormatoObra.HasValue)
            {
                obras = obras.Where(o => o.Formato == filtroObra.FormatoObra.Value);
            }

            if (filtroObra.ObraFoiFinalizada.HasValue)
            {
                obras = obras.Where(o => o.FoiFinalizada ==  filtroObra.ObraFoiFinalizada.Value);
            }
            
            if (filtroObra.ListaDeGenerosObra != null && filtroObra.ListaDeGenerosObra.Any())
            {
                obras = obras.Where(o => o.Generos.Any(g => filtroObra.ListaDeGenerosObra.Contains(g)));
            }

            if (!string.IsNullOrEmpty(filtroObra.AnoInicialLancamento) && !string.IsNullOrEmpty(filtroObra.AnoFinalLancamento))
            {
                var intAnoInicial = Convert.ToInt32(filtroObra.AnoInicialLancamento);
                var intAnoFinal = Convert.ToInt32(filtroObra.AnoFinalLancamento);

                obras = obras.Where(o => o.InicioPublicacao.Year >= intAnoInicial && o.InicioPublicacao.Year <= intAnoFinal);
            }

            return obras;
        }
    }
}
