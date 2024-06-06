using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoCompraCliente
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

        public CompraCliente Criar(CompraCliente novaCompraCliente)
        {
            var resultadoValidacao = _validadorCompraCliente.Validate(novaCompraCliente);

            if(!resultadoValidacao.IsValid) 
            {
                var erros = string.Join(Environment.NewLine, resultadoValidacao.Errors.Select(x => x.ErrorMessage).ToArray());

                throw new ValidationException(erros);
            }

            return _repositorioCompraCliente.Criar(novaCompraCliente);
        }

        public CompraCliente Editar(CompraCliente compraCliente)
        {
            var resultadoValidacao = _validadorCompraCliente.Validate(compraCliente, options =>
            {
                options.IncludeRuleSets("Editar").IncludeRulesNotInRuleSet();
            });

            if(!resultadoValidacao.IsValid)
            {
                var erros = string.Join(Environment.NewLine, resultadoValidacao.Errors.Select(x => x.ErrorMessage).ToArray());

                throw new ValidationException(erros);
            }

            return _repositorioCompraCliente.Editar(compraCliente);
        }

        public void Remover(CompraCliente compraCliente)
        {
            throw new NotImplementedException();
        }
    }
}
