using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static readonly ListaSingleton? _instancia = new();

        public List<CompraCliente> ListaCompraCliente { get; set; } = new List<CompraCliente> { };
        public List<Obra> ListaObra { get; set; } = new List<Obra> { };
        public int IdObjetoCriado { get; set; } = 100;

        public static ListaSingleton Instancia
        {
            get
            {
                return _instancia
                    ?? new ListaSingleton();
            }
        }

        public int GerarNovoId()
        {
            return IdObjetoCriado++;
        }
    }
}
