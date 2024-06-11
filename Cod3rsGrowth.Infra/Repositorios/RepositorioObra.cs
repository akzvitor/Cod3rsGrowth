using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoDeDados;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioObra : IRepositorio<Obra>
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
            throw new NotImplementedException();
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
            if (!string.IsNullOrEmpty(filtro.Autor))
            {
                obras = obras.Where(o => o.Autor.Contains(filtro.Autor));
            }

            if (!string.IsNullOrEmpty(filtro.Titulo))
            {
                obras = obras.Where(o => o.Titulo.Contains(filtro.Titulo));
            }

            if (filtro.Formato.HasValue)
            {
                obras = obras.Where(o => o.Formato == filtro.Formato.Value);
            }

            if (filtro.FoiFinalizada.HasValue)
            {
                obras = obras.Where(o => o.FoiFinalizada ==  filtro.FoiFinalizada.Value);
            }
            
            if (filtro.ListaDeGeneros != null && filtro.ListaDeGeneros.Any())
            {
                obras = obras.Where(o => o.Generos.Any(g => filtro.ListaDeGeneros.Contains(g)));
            }

            return obras;
        }
    }
}
