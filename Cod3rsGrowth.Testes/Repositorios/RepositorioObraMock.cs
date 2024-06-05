using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioObraMock : IRepositorioObra
    {
        public List<Obra> listaObra = ListaSingleton.Instancia.ListaObra;
        private int _obraId = 100;

        public List<Obra> ObterTodos()
        {
            return listaObra;
        }

        public Obra ObterPorId(int idInformado)
        {
            var obraRequisitada = listaObra.Find(obra => obra.Id == idInformado)
                ?? throw new Exception($"O ID informado ({idInformado}) é inválido. Obra não encontrada.");
            return obraRequisitada;
        }

        public Obra Criar(Obra novaObra)
        { 
            novaObra.Id = _obraId;
            _obraId++;
            listaObra.Add(novaObra);

            return novaObra;
        }
    }
}
