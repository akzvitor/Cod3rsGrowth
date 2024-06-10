namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        List<T> ObterTodos();
        T ObterPorId(int id);
        T Criar(T entidade);
        T Editar(T entidade);
        void Remover(int id);
    }
}
