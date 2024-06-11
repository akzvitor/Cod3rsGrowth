using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class FiltroObra
    {
        public string? Autor { get; set; }
        public string? Titulo { get; set; }
        public List<Genero>? ListaDeGeneros { get; set; }
        public Formato? Formato { get; set; }
        public bool? FoiFinalizada { get; set; }
    }
}
