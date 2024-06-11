using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Filtro
    {
        public string? AutorObra { get; set; }
        public string? TituloObra { get; set; }
        public List<Genero>? ListaDeGenerosObra { get; set; }
        public Formato? FormatoObra { get; set; }
        public bool? ObraFoiFinalizada { get; set; }
        public string? NomeCliente { get; set; }
        public DateTime? DataCompra { get; set; }
        public decimal? ValorCompra { get; set; }
    }
}
