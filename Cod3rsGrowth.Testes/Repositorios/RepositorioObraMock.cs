using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioObraMock : IRepositorioObra
    {
        public List<Obra> ListaObra = ListaSingleton.Instancia.ListaObra;

        public List<Obra> ObterTodos()
        {
            return ListaObra;
        }

        public Obra ObterPorId(int idInformado)
        {
            var obraRequisitada = ListaObra.Find(obra => obra.Id == idInformado)
                ?? throw new Exception("ID inválido. Obra não encontrada.");
            return obraRequisitada;
        }
    }
}
