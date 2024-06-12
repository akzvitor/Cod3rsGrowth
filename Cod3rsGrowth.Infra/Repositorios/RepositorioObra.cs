using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.ConexaoDeDados;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;

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
            var query = Filtrar(_db.Obras, filtro);
            var obrasFiltradas = query.ToList();

            return obrasFiltradas;
        }

        public Obra ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Obra Criar(Obra obra)
        {
            obra.Id = _db.InsertWithInt32Identity(obra);

            return obra;
        }

        public Obra Editar(Obra obra)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<Obra> Filtrar(IQueryable<Obra> obras, FiltroObra filtro) 
        {
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

            return obras;
        }
    }
}
