using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioMockCompraCliente : IRepositorioCompraCliente
    {
        public List<CompraCliente> ListaCompraCliente = ListaSingleton.Instancia.ListaCompraCliente;

        public RepositorioMockCompraCliente() { } 

        public List<CompraCliente> ObterTodos()
        {
            return ListaCompraCliente;
        }
    }
}
