using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Obra
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public List<Genero> Generos { get; set; }
        public string Sinopse { get; set; }
        public string CapaImagemBase64 { get; set; }
        public int NumeroCapitulos { get; set; }
        public decimal ValorObra { get; set; }
        public Formato Formato { get; set; }
        public bool FoiFinalizada { get; set; }
        public DateTime InicioPublicacao { get; set; }
    }
}
