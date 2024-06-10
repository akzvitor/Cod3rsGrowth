using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoDeDados;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioObra : IRepositorio<Obra>
    {
        private DbCodersGrowth _db;
        public RepositorioObra(DbCodersGrowth conexaoComBancoDeDados) 
        {
            _db = conexaoComBancoDeDados;
        }
        public List<Obra> ObterTodos()
        {
            var query = from o in _db.Obra
                        where o.FoiFinalizada == true
                        select o;

            return query.ToList();
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
    }
}
