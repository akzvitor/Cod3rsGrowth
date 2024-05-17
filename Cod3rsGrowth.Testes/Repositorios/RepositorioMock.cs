using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioMock : IRepositorio
    {
        public List<Obra> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
