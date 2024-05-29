using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioCompraClienteMock : IRepositorioCompraCliente
    {
        public List<CompraCliente> ListaCompraCliente = ListaSingleton.Instancia.ListaCompraCliente;
        private int compraClienteId = 100;

        public List<CompraCliente> ObterTodos()
        {
            return ListaCompraCliente;
        }

        public CompraCliente ObterPorId(int idInformado)
        {
            var compraRequisitada = ListaCompraCliente.Find(compra => compra.Id == idInformado)
                ?? throw new Exception($"O ID informado ({idInformado}) é inválido. Compra não encontrada.");

            return compraRequisitada;
        }

        public void Criar(CompraCliente novaCompraCliente)
        {
            novaCompraCliente.Id = compraClienteId;
            compraClienteId++;
            ListaCompraCliente.Add(novaCompraCliente);
        }
    }
}
