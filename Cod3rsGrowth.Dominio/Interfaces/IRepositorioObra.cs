using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorioObra : IRepositorio<Obra, FiltroObra>
    {
        public List<string> ObterGenerosVinculados(int obraId);
    }
}
