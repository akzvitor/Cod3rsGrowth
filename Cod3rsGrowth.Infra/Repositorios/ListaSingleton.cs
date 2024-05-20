using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static ListaSingleton? _instancia;

        public List<CompraCliente> ListaCompraCliente { get; private set; }
        public List<Obra> ListaObra { get; private set; }

        private ListaSingleton()
        {
            ListaCompraCliente = new List<CompraCliente>();
            ListaObra = new List<Obra>();
        }

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
