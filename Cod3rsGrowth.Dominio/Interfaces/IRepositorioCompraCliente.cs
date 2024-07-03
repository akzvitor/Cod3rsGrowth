using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorioCompraCliente : IRepositorio<CompraCliente, FiltroCompraCliente>
    {
        public List<int> ObterProdutosVinculados(int compraId);
    }
}
