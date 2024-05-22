using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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

        public void Criar(Obra novaObra)
        {
            throw new NotImplementedException();
        }

        public void CriarObra(Obra novaObra)
        {
            throw new NotImplementedException();
        }

        public void Editar(Obra obra)
        {
            throw new NotImplementedException();
        }

        public void ObterPorId()
        {
            throw new NotImplementedException();
        }

        public void Remover(Obra obra)
        {
            throw new NotImplementedException();
        }
    }
}
