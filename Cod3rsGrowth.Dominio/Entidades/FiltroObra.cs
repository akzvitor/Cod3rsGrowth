using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class FiltroObra : IFiltro
    {
        public string? AutorObra { get; set; }
        public string? TituloObra { get; set; }
        public List<Genero>? ListaDeGenerosObra { get; set; }
        public Formato? FormatoObra { get; set; }
        public bool? ObraFoiFinalizada { get; set; }
        public string? AnoDaPublicacao { get; set; }
    }
}
