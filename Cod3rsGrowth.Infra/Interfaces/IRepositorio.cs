using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorio
    {
        public List<Obra> ObterTodos();
    }
}
