using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes
{
    public class ServicoCompraClienteTestes : TesteBase
    {
        private IServicoCompraCliente? _servicoCompraCliente;

        public ServicoCompraClienteTestes()
        {
            CarregarServicos();
        }

        private void CarregarServicos()
        {
            _servicoCompraCliente = ServiceProvider.GetService<IServicoCompraCliente>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoCompraCliente)}]");
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaCompraCliente()
        {
            //arrange

            //act
            var novaCompra = new CompraCliente
            {
                Nome = "Vitor",
                Produtos = new List<Obra>
                {
                    new()
                    {
                        Titulo = "Jujutsu Kaisen",
                    },
                    new()
                    {
                        Titulo = "Dorohedoro"
                    }
                }
            };

            _servicoCompraCliente.ObterTodos().Add(novaCompra);
            var listaDoBanco = _servicoCompraCliente.ObterTodos();

            List<CompraCliente> listaMock = new()
            {
                novaCompra
            };

            //assert
            Assert.NotNull(listaDoBanco);
            Assert.Equal(listaMock, listaDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaDoTipoCompraCliente()
        {
            //arrange

            //act
            var compras = _servicoCompraCliente.ObterTodos();
            //assert
            Assert.NotNull(compras);
            Assert.IsType<List<CompraCliente>>(compras);
        }
    }
}
