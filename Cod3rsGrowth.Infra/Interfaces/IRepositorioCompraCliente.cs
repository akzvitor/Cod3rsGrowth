using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioCompraCliente
    {
        List<CompraCliente> ObterTodos();
        CompraCliente ObterPorId(int idInformado);
        CompraCliente Criar(CompraCliente novaCompraCliente);
        CompraCliente Editar(CompraCliente compraCliente);
        void Remover(int id);
    }
}
