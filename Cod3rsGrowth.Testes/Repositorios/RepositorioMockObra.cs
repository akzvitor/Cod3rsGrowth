using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioMockObra : IRepositorioObra
    {
        public List<Obra> ListaObra = ListaSingleton.Instancia.ListaObra;

        public RepositorioMockObra() { }

        public List<Obra> ObterTodos()
        {
            return ListaObra;
        }
    }
}
