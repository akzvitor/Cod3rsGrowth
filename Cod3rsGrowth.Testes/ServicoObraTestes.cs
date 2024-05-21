using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes
{
    public class ServicoObraTestes : TesteBase
    {
        private readonly IServicoObra _servicoObra;

        public ServicoObraTestes()
        {
            _servicoObra = ServiceProvider.GetService<IServicoObra>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoObra)}]");
        }

        [Fact]
        public void Obter_todos_deve_retornar_uma_lista_vazia()
        {
            //arrange

            //act
            var obras = _servicoObra.ObterTodos();
            var tamanhoDaListaObras = obras.Count;

            //assert
            Assert.NotNull(obras);
            Assert.Equal(0, tamanhoDaListaObras);
        }
    }
}