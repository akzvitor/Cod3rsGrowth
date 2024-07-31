using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class FiltroCompraCliente : IFiltro
    {
        public string? NomeCliente { get; set; }
        public string? DataInicial { get; set; }
        public string? DataFinal { get; set; }
        public string? Cpf {  get; set; }
    }
}
