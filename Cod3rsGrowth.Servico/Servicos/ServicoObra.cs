using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Cod3rsGrowth.Servico.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoObra : IServicoObra
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

        public void Criar(Obra novaObra)
        {
            var resultadoValidacao = _validadorObra.Validate(novaObra);

            if (!resultadoValidacao.IsValid)
            {
                var mensagemDeErro = "";
                foreach (var falha in resultadoValidacao.Errors)
                {
                    mensagemDeErro += $"Falha na validação da seguinte propriedade: {falha.PropertyName}." +
                        $" Erro: {falha.ErrorMessage} \n";
                }
                throw new ValidationException(resultadoValidacao.Errors);
            }

            _repositorioObra.Criar(novaObra);
        }

        public void Editar(Obra obra)
        {
            throw new NotImplementedException();
        }

        public void Remover(Obra obra)
        {
            throw new NotImplementedException();
        }
    }
}
