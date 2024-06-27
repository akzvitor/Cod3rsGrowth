using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
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

        public List<CompraCliente> ObterTodos(FiltroCompraCliente filtro)
        {
            return _repositorioCompraCliente.ObterTodos(filtro);
        }

        public CompraCliente ObterPorId(int id)
        {
            return _repositorioCompraCliente.ObterPorId(id);
        }

        public CompraCliente Criar(CompraCliente compraCliente)
        {
            var resultadoValidacao = _validadorCompraCliente.Validate(compraCliente);

            if(!resultadoValidacao.IsValid) 
            {
                var erros = string.Join(Environment.NewLine, resultadoValidacao.Errors.Select(x => x.ErrorMessage).ToArray());

                throw new ValidationException(erros);
            }

            return _repositorioCompraCliente.Criar(compraCliente);
        }

        public void AdicionarProdutos(int compraId, List<int> idProdutos)
        {
            _repositorioCompraCliente.AdicionarProdutos(compraId, idProdutos);
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

        public void Remover(int id)
        {
            _repositorioCompraCliente.Remover(id);
        }
    }
}
