using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioObra : IRepositorio<Obra>
    {
        public List<Obra> ObterTodos()
        {
            throw new NotImplementedException();
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
