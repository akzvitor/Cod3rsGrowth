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

            var listaDoBanco = _servicoCompraCliente.ObterTodos();
            listaDoBanco.Clear();
            listaDoBanco.Add(novaCompra);

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

        [Fact]
        public void ObterPorId_InformandoIdInvalido_DeveRetornarMensagemDeErro()
        {
            
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarCompraClienteCorreta()
        {
            //arrange
            var novaCompra = new CompraCliente
            {
                Cpf = "22222222222",
                Id = 10,
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
                Id = 20,
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
            var compraClienteVitor = _servicoCompraCliente.ObterPorId(10);
            var compraClienteJorge = _servicoCompraCliente.ObterPorId(20);

            //assert
            Assert.NotNull(compraClienteVitor);
            Assert.Equal(novaCompra, compraClienteVitor);
            Assert.NotNull(compraClienteJorge);
            Assert.Equal(novaCompra2, compraClienteJorge);
        }
    }
}
