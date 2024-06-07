using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioCompraCliente
    {
        List<CompraCliente> ObterTodos();
        CompraCliente ObterPorId(int id);
        CompraCliente Criar(CompraCliente compraCliente);
        CompraCliente Editar(CompraCliente compraCliente);
        void Remover(int id);
    }
}
