using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static ListaSingleton? _instancia;

        public List<CompraCliente> RepositorioCompraCliente { get; private set; }
        public List<Obra> RepositorioObra { get; private set; }

        private ListaSingleton()
        {
            RepositorioCompraCliente = new List<CompraCliente>();
            RepositorioObra = new List<Obra>();
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
