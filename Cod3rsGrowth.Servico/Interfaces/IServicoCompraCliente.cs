using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoCompraCliente
    {
        public void Criar(CompraCliente novaCompraCliente);
        public void Editar(CompraCliente compraCliente);
        public void Remover(CompraCliente compraCliente);
        public List<CompraCliente> ObterTodos();
        public void ObterPorId();
    }
}
