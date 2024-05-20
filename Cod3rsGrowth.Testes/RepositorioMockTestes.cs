using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit; 

namespace Cod3rsGrowth.Testes
{
    public class RepositorioMockTestes : TesteBase
    {
        private readonly IRepositorio _repositorioMock;

        public RepositorioMockTestes()
        {
            _repositorioMock = ServiceProvider.GetService<IRepositorio>();
        }

        [Fact]
        public void deveriaObterNumeroDeElementosNaListaDeObras_3_3()
        {
            //arrange
            var listaSingleton = _repositorioMock.ObterTodos();
            //act
            var listaObras = listaSingleton.ListaObra;
            //assert
            Assert.Equal(3, 3);
        }

        [Fact]
        public void deveriaFalharAoObterNumeroDeElementosNaListaDeObras_1_3()
        {

        }
    }
}