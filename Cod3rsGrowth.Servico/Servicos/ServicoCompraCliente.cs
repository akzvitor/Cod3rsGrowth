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
        private readonly ServicoObra _servicoObra;

        public ServicoCompraCliente(IRepositorioCompraCliente repositorioCompraCliente, CompraClienteValidador validadorCompraCliente,
                                    ServicoObra servicoObra)
        {
            _repositorioCompraCliente = repositorioCompraCliente;
            _validadorCompraCliente = validadorCompraCliente;
            _servicoObra = servicoObra;
        }

        public List<CompraCliente> ObterTodos(FiltroCompraCliente? filtro = null)
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

        public List<int> ObterProdutosVinculados(int compraId)
        {
            return _repositorioCompraCliente.ObterProdutosVinculados(compraId);
        }

        public List<Obra> ObterObrasVinculadas(int compraId)
        {
            var listaDeIds = ObterProdutosVinculados(compraId);
            var listaDeObras = new List<Obra>();

            listaDeIds.ForEach(item =>
            {
                listaDeObras.Add(_servicoObra.ObterPorId(item));
            });

            return listaDeObras;
        }
    }
}
