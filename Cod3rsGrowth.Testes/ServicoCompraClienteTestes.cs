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
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarAListaCompraCliente()
        {
            //arrange

            //act
            var novaCompra1 = new CompraCliente
            {
                Id = 1,
                Cpf = "11111111111",
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

            _servicoCompraCliente.ObterTodos().Add(novaCompra1);
            var listaDoBanco = _servicoCompraCliente.ObterTodos();

            List<CompraCliente> listaMock = new()
            {
                novaCompra1
            };

            //assert
            Assert.NotNull(listaDoBanco);
            Assert.Equivalent(listaMock, listaDoBanco);
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

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarCompraClienteCorreta()
        {
            //arrange
            var novaCompra2 = new CompraCliente
            {
                Cpf = "22222222222",
                Id = 2,
                Nome = "Luiz",
                Produtos = new List<Obra>
                {
                    new()
                    {
                        Titulo = "One Punch Man",
                    },
                    new()
                    {
                        Titulo = "Sakamoto Days"
                    }
                }
            };
            var novaCompra3 = new CompraCliente
            {
                Cpf = "33333333333",
                Id = 3,
                Nome = "Jorge",
                Produtos = new List<Obra>
                {
                    new()
                    {
                        Titulo = "Hells Paradise: Jigokuraku"
                    },
                    new()
                    {
                        Titulo = "Shingeki no Kyojin"
                    }
                }
            };

            //act
            _servicoCompraCliente.ObterTodos().Add(novaCompra2);
            _servicoCompraCliente.ObterTodos().Add(novaCompra3);
            var compraClienteLuiz = _servicoCompraCliente.ObterPorId(2);
            var compraClienteJorge = _servicoCompraCliente.ObterPorId(3);

            //assert
            Assert.NotNull(compraClienteLuiz);
            Assert.Equal(novaCompra2, compraClienteLuiz);
            Assert.NotNull(compraClienteJorge);
            Assert.Equal(novaCompra3, compraClienteJorge);
        }

        [Fact]
        public void ObterPorId_InformandoIdInvalido_DeveRetornarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            var novaCompra4 = new CompraCliente
            {
                Id = 4
            };

            //act
            _servicoCompraCliente.ObterTodos().Add(novaCompra4);

            //assert
            var excecao = Assert.Throws<Exception>(() => _servicoCompraCliente.ObterPorId(100));
            Assert.Equal("ID inválido. Compra não encontrada.", excecao.Message);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObjetoDoTipoCompraCliente()
        {
            //arrange
            var novaCompra5 = new CompraCliente
            {
                Id = 5
            };

            //act
            _servicoCompraCliente.ObterTodos().Add(novaCompra5);
            var compra = _servicoCompraCliente.ObterPorId(5);
            
            //assert
            Assert.NotNull(compra);
            Assert.IsType<CompraCliente>(compra);
        }
    }
}
