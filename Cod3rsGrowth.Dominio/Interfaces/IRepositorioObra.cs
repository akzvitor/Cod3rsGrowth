using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorioObra : IRepositorio<Obra, FiltroObra>
    {
        void SalvarGeneros(int idObra, List<string> generos);
    }
}
