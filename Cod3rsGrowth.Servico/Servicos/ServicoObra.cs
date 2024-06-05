using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoObra
    {
        private readonly IRepositorioObra _repositorioObra;
        private readonly ObraValidador _validadorObra;


        public ServicoObra(IRepositorioObra repositorioObra, ObraValidador validadorObra)
        {
            _repositorioObra = repositorioObra;
            _validadorObra = validadorObra;
        }

        public List<Obra> ObterTodos()
        {
            return _repositorioObra.ObterTodos();
        }

        public Obra ObterPorId(int idInformado)
        {
            return _repositorioObra.ObterPorId(idInformado);
        }

        public Obra Criar(Obra novaObra)
        {
            var resultadoValidacao = _validadorObra.Validate(novaObra);

            if (!resultadoValidacao.IsValid)
            {
                var erros = string.Join(Environment.NewLine, resultadoValidacao.Errors.Select(x => x.ErrorMessage).ToArray());

                throw new ValidationException(erros);
            }
           
            return _repositorioObra.Criar(novaObra);
        }

        public Obra Editar(Obra obraEditada)
        {
            var resultadoValidacao = _validadorObra.Validate(obraEditada, options =>
            {
                options.IncludeRuleSets("Editar");
            });

            if (!resultadoValidacao.IsValid)
            {
                var erros = string.Join(Environment.NewLine, resultadoValidacao.Errors.Select(x => x.ErrorMessage).ToArray());

                throw new ValidationException(erros);
            }

            return _repositorioObra.Editar(obraEditada);
        }

        public void Remover(Obra obra)
        {
            throw new NotImplementedException();
        }
    }
}
