using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Servico.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoCompraCliente : IServicoCompraCliente
    {
        private readonly IRepositorioCompraCliente _repositorioCompraCliente;
        private readonly CompraClienteValidador _validadorCompraCliente;

        public ServicoCompraCliente(IRepositorioCompraCliente repositorioCompraCliente, CompraClienteValidador validadorCompraCliente)
        {
            _repositorioCompraCliente = repositorioCompraCliente;
            _validadorCompraCliente = validadorCompraCliente;
        }

        public List<CompraCliente> ObterTodos()
        {
            return _repositorioCompraCliente.ObterTodos();
        }

        public CompraCliente ObterPorId(int idInformado)
        {
            return _repositorioCompraCliente.ObterPorId(idInformado);
        }

        public void Criar(CompraCliente novaCompraCliente)
        {
            var resultadoValidacao = _validadorCompraCliente.Validate(novaCompraCliente);

            if(!resultadoValidacao.IsValid) 
            {
                var mensagemDeErroGeral = "";

                foreach (var falha in resultadoValidacao.Errors)
                {
                    mensagemDeErroGeral += falha.ErrorMessage + " | ";
                }

                throw new ValidationException(mensagemDeErroGeral);
            }

            _repositorioCompraCliente.Criar(novaCompraCliente);
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
