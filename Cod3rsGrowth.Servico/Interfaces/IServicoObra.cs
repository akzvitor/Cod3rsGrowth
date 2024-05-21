using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoObra
    {
        public List<Obra> ObterTodos();
        public void Criar(Obra novaObra);
        public void Editar(Obra obra);
        public void Remover(Obra obra);
        public void ObterPorId();
    }
}
