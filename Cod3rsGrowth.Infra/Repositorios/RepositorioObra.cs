using Cod3rsGrowth.Dominio.Classes;
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

        public List<Obra> ObterTodos()
        {
            var query = Filtro(_db.Obras, formato: Formato.Manhwa);
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

        public static IQueryable<Obra> Filtro(IQueryable<Obra> obras, string? autor = null, string? titulo = null, 
                                                List<Genero> listaDeGeneros = null, Formato? formato = null, 
                                                bool? foiFinalizada = null) 
        {
            if (!string.IsNullOrEmpty(autor))
            {
                obras = obras.Where(o => o.Autor.Contains(autor));
            }

            if (!string.IsNullOrEmpty(titulo))
            {
                obras = obras.Where(o => o.Titulo.Contains(titulo));
            }

            if (formato.HasValue)
            {
                obras = obras.Where(o => o.Formato == formato.Value);
            }

            if (foiFinalizada.HasValue)
            {
                obras = obras.Where(o => o.FoiFinalizada ==  foiFinalizada.Value);
            }
            
            if (listaDeGeneros != null && listaDeGeneros.Any())
            {
                obras = obras.Where(o => o.Generos.Any(g => listaDeGeneros.Contains(g)));
            }

            return obras;
        }
    }
}
