using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Xunit; 

namespace Cod3rsGrowth.Testes
{
    public class ServicoCompraClienteTestes : TesteBase
    {
        private readonly ServicoCompraCliente servico;

        ServicoCompraClienteTestes()
        {
            servico = new ServicoCompraCliente();
        }

        [Fact]
        public void ObterTodasComprasEmUmaLista_Null_ListaDeCompras()
        {
            //arrange

            //act

            //assert
        }

        public void Dispose()
        {

        }
    }
}