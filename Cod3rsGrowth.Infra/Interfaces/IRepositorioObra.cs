using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioObra
    {
        List<Obra> ObterTodos();
        Obra ObterPorId(int id);
        Obra Criar(Obra obra);
        Obra Editar(Obra obra);
        void Remover(int id);
    }
}
