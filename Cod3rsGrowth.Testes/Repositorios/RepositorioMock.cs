using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioMock : IRepositorio
    {
        public ListaSingleton Singleton = ListaSingleton.Instancia;

        public RepositorioMock() 
        {
            CompraCliente compra1 = new()
            {
                Nome = "Vitor"
            };
            CompraCliente compra2 = new()
            {
                Nome = "Higor"
            };
            CompraCliente compra3 = new()
            {
                Nome = "Bruno"
            };

            Singleton.ListaCompraCliente.Add(compra1);
            Singleton.ListaCompraCliente.Add(compra2);
            Singleton.ListaCompraCliente.Add(compra3);

            Obra obra1 = new()
            {
                Titulo = "Jujutsu Kaisen"
            };
            Obra obra2 = new()
            {
                Titulo = "Shingeki no Kyojin"
            };
            Obra obra3 = new()
            {
                Titulo = "Na Honjaman Level Up"
            };

            Singleton.ListaObra.Add(obra1);
            Singleton.ListaObra.Add(obra2);
            Singleton.ListaObra.Add(obra3);
        }

        public List<Obra> ObterTodos()
        {
            return Singleton.ListaObra;
        }
    }
}
