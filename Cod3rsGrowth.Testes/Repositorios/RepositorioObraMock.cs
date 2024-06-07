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

        public Obra Editar(Obra obraEditada)
        {
            var obraNoBanco = ObterPorId(obraEditada.Id);

            obraNoBanco.Titulo = obraEditada.Titulo;
            obraNoBanco.Autor = obraEditada.Autor;
            obraNoBanco.NumeroCapitulos = obraEditada.NumeroCapitulos;
            obraNoBanco.InicioPublicacao = obraEditada.InicioPublicacao;
            obraNoBanco.ValorObra = obraEditada.ValorObra;
            obraNoBanco.FoiFinalizada = obraEditada.FoiFinalizada;
            obraNoBanco.Sinopse = obraEditada.Sinopse;
            obraNoBanco.Formato = obraEditada.Formato;
            obraNoBanco.Generos = obraEditada.Generos;

            return obraNoBanco;
        }

        public void Remover(int id)
        {
            var obra = ObterPorId(id);

            listaObra.Remove(obra);
        }
    }
}
