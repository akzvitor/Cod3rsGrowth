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
            var novaCompra = new CompraCliente
            {
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

            _servicoCompraCliente.ObterTodos().Add(novaCompra);
            var listaDoBanco = _servicoCompraCliente.ObterTodos();

            List<CompraCliente> listaMock = new()
            {
                novaCompra
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
            var novaCompra = new CompraCliente
            {
                Cpf = "22222222222",
                Id = 1,
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
            var novaCompra2 = new CompraCliente
            {
                Cpf = "33333333333",
                Id = 2,
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
            _servicoCompraCliente.ObterTodos().Add(novaCompra);
            _servicoCompraCliente.ObterTodos().Add(novaCompra2);
            var compraClienteVitor = _servicoCompraCliente.ObterPorId(1);
            var compraClienteJorge = _servicoCompraCliente.ObterPorId(2);

            //assert
            Assert.NotNull(compraClienteVitor);
            Assert.Equal(novaCompra, compraClienteVitor);
            Assert.NotNull(compraClienteJorge);
            Assert.Equal(novaCompra2, compraClienteJorge);
        }

        [Fact]
        public void ObterPorId_InformandoIdInvalido_DeveRetornarMensagemDeErro()
        {
            //arrange
            var novaCompra1 = new CompraCliente
            {
                Id = 3
            };

            //act
            _servicoCompraCliente.ObterTodos().Add(novaCompra1);

            //assert
            Assert.Throws<ArgumentNullException>(() => _servicoCompraCliente.ObterPorId(5));
        }

        [Fact]
        public void ObterPorId_ComDadosDisponiveis_DeveRetornarObjetoDoTipoCompraCliente()
        {
            //arrange
            var novaCompra1 = new CompraCliente
            {
                Id = 3
            };

            //act
            _servicoCompraCliente.ObterTodos().Add(novaCompra1);
            var compra = _servicoCompraCliente.ObterPorId(3);
            
            //assert
            Assert.NotNull(compra);
            Assert.IsType<CompraCliente>(compra);
        }
    }
}
