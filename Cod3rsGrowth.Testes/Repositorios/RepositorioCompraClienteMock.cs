using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioCompraClienteMock : IRepositorioCompraCliente
    {
        public List<CompraCliente> ListaCompraCliente = ListaSingleton.Instancia.ListaCompraCliente;

        public List<CompraCliente> ObterTodos()
        {
            return ListaCompraCliente;
        }

        public CompraCliente ObterPorId(int idInformado)
        {
            return ListaCompraCliente.Find(compra => compra.Id == idInformado);
        }
    }
}
