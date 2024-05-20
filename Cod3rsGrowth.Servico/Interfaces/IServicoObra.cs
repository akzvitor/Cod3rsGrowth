using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoObra
    {
        public void Criar(Obra novaObra);
        public void Editar(Obra obra);
        public void Remover(Obra obra);
        public List<Obra> ObterTodos();
        public void ObterPorId();
    }
}
