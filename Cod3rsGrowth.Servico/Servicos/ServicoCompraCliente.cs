using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoCompraCliente : IServicoCompraCliente
    {
        private readonly IRepositorioCompraCliente _repositorioCompraCliente;

        public ServicoCompraCliente(IRepositorioCompraCliente repositorioCompraCliente)
        {
            _repositorioCompraCliente = repositorioCompraCliente;
        }

        public List<CompraCliente> ObterTodos()
        {
            return _repositorioCompraCliente.ObterTodos();
        }

        public void ObterPorId()
        {
            throw new NotImplementedException();
        }

        public void Criar(CompraCliente novaCompraCliente)
        {
            throw new NotImplementedException();
        }

        public void Editar(CompraCliente compraCliente)
        {
            throw new NotImplementedException();
        }

        public void Remover(CompraCliente compraCliente)
        {
            throw new NotImplementedException();
        }
    }
}
