using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioCompraClienteMock : IRepositorioCompraCliente
    {
        public List<CompraCliente> listaCompraCliente = ListaSingleton.Instancia.ListaCompraCliente;
        private int _compraClienteId = 100;

        public List<CompraCliente> ObterTodos()
        {
            return listaCompraCliente;
        }

        public CompraCliente ObterPorId(int idInformado)
        {
            var compraRequisitada = listaCompraCliente.Find(compra => compra.Id == idInformado)
                ?? throw new Exception($"O ID informado ({idInformado}) é inválido. Compra não encontrada.");

            return compraRequisitada;
        }

        public CompraCliente Criar(CompraCliente novaCompraCliente)
        {
            novaCompraCliente.Id = _compraClienteId;
            _compraClienteId++;
            listaCompraCliente.Add(novaCompraCliente);

            return novaCompraCliente;
        }

        public CompraCliente Editar(CompraCliente compraCliente)
        {
            var compraNoBanco = ObterPorId(compraCliente.Id);

            compraNoBanco.Cpf = compraCliente.Cpf;
            compraNoBanco.Nome = compraCliente.Nome;
            compraNoBanco.Telefone = compraCliente.Telefone;
            compraNoBanco.Email = compraCliente.Email;
            compraNoBanco.Produtos = compraCliente.Produtos;
            compraNoBanco.ValorCompra = compraCliente.ValorCompra;
            compraNoBanco.DataCompra = compraCliente.DataCompra;

            return compraNoBanco;
        }

        public void Remover(int id)
        {
            var compra = ObterPorId(id);

            listaCompraCliente.Remove(compra);
        }
    }
}
