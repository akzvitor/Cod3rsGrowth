using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static ListaSingleton? _instancia;

        public List<CompraCliente> ListaCompraCliente { get; set; } = new List<CompraCliente> { };
        public List<Obra> ListaObra { get; set; } = new List<Obra> { };

        public static ListaSingleton Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ListaSingleton();
                }
                return _instancia;
            }
        }
    }
}
