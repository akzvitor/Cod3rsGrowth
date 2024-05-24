using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoObra : IServicoObra
    {
        private readonly IRepositorioObra _repositorioObra;

        public ServicoObra(IRepositorioObra repositorioObra)
        {
            _repositorioObra = repositorioObra;
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
