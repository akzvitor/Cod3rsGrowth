using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        List<T> ObterTodos(FiltroObra filtro);
        T ObterPorId(int id);
        T Criar(T entidade);
        T Editar(T entidade);
        void Remover(int id);
    }
}
