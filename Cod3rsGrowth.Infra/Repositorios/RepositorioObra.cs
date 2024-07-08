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

        public List<Obra> ObterTodos(FiltroObra filtro)
        {
            var query = Filtrar(filtro);
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
            var obraNoBanco = _db.Obras.FirstOrDefault(o => o.Id == obra.Id)
                ?? throw new Exception("Obra não encontrada.");

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

        public IQueryable<Obra> Filtrar(FiltroObra filtro) 
        {
            IQueryable<Obra> obras = _db.Obras;

            if (filtro == null)
            {
                return obras;
            }

            if (!string.IsNullOrEmpty(filtro.AutorObra))
            {
                obras = obras.Where(o => o.Autor.Contains(filtro.AutorObra));
            }

            if (!string.IsNullOrEmpty(filtro.TituloObra))
            {
                obras = obras.Where(o => o.Titulo.Contains(filtro.TituloObra));
            }

            if (filtro.FormatoObra.HasValue)
            {
                obras = obras.Where(o => o.Formato == filtro.FormatoObra.Value);
            }

            if (filtro.ObraFoiFinalizada.HasValue)
            {
                obras = obras.Where(o => o.FoiFinalizada ==  filtro.ObraFoiFinalizada.Value);
            }
            
            if (filtro.ListaDeGenerosObra != null && filtro.ListaDeGenerosObra.Any())
            {
                obras = obras.Where(o => o.Generos.Any(g => filtro.ListaDeGenerosObra.Contains(g)));
            }

            if (!string.IsNullOrEmpty(filtro.AnoInicialLancamento) && !string.IsNullOrEmpty(filtro.AnoFinalLancamento))
            {
                var intAnoInicial = Convert.ToInt32(filtro.AnoInicialLancamento);
                var intAnoFinal = Convert.ToInt32(filtro.AnoFinalLancamento);

                obras = obras.Where(o => o.InicioPublicacao.Year >= intAnoInicial && o.InicioPublicacao.Year <= intAnoFinal);
            }

            return obras;
        }
    }
}
