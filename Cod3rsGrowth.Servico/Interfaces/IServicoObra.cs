using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoObra
    {
        List<Obra> ObterTodos();
        void Criar(Obra novaObra);
        void Editar(Obra obra);
        void Remover(Obra obra);
        void ObterPorId();
    }
}
