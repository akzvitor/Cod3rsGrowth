using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoCompraCliente
    {
        public List<CompraCliente> ObterTodos();
        public void Criar(CompraCliente novaCompraCliente);
        public void Editar(CompraCliente compraCliente);
        public void Remover(CompraCliente compraCliente);
        public void ObterPorId();
    }
}
