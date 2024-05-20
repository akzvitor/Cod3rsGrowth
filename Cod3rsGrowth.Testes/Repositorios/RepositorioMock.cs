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
            Singleton.RepositorioCompraCliente.Add(compra1);

            Obra obra1 = new()
            {
                Titulo = "Jujutsu Kaisen"
            };
            Singleton.RepositorioObra.Add(obra1);
        }

        public ListaSingleton ObterTodos()
        {
            return Singleton;
        }
    }
}
