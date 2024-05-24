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
        private List<CompraCliente> _listaDoBanco;
        private List<CompraCliente> _listaMock;

        public ServicoCompraClienteTestes()
        {
            CarregarServicos();
            _listaMock = InicializarDadosMockados();
        }

        private void CarregarServicos()
        {
            _servicoCompraCliente = ServiceProvider.GetService<IServicoCompraCliente>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoCompraCliente)}]");
        }

        private List<CompraCliente> InicializarDadosMockados()
        {
            List<CompraCliente> listaDeComprasCliente = new()
            {
                new CompraCliente
                {
                    Id = 1,
                    Cpf = "11111111111",
                    Nome = "Vitor",
                    Produtos = new List<Obra>
                    {
                        new()
                        {
                            Titulo = "Dungeon Meshi",
                        },
                        new()
                        {
                            Titulo = "Dorohedoro"
                        }
                    }
                },
                new CompraCliente
                {
                    Id = 2,                    
                    Cpf = "22222222222",
                    Nome = "Luiz",
                    Produtos = new List<Obra>
                    {
                        new()
                        {
                            Titulo = "Gachiakuta",
                        },
                        new()
                        {
                            Titulo = "Sakamoto Days"
                        }
                    }
                },
                new CompraCliente
                {
                    Id = 3,
                    Cpf = "33333333333",
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
                }
            };

            _listaDoBanco = _servicoCompraCliente.ObterTodos();

            foreach (var compraCliente in listaDeComprasCliente)
            {
                _listaDoBanco.Add(compraCliente);
            }

            return listaDeComprasCliente;
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarAListaCompraCliente()
        {
            _listaDoBanco = _servicoCompraCliente.ObterTodos();

            Assert.NotNull(_listaDoBanco);
            Assert.Equivalent(_listaMock, _listaDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDoTipoCompraCliente()
        {
            _listaDoBanco = _servicoCompraCliente.ObterTodos();
            
            Assert.NotNull(_listaDoBanco);
            Assert.IsType<List<CompraCliente>>(_listaDoBanco);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarCompraClienteCorreta()
        {
            var idValidoInformado = 1;
            var compraCliente = _servicoCompraCliente.ObterPorId(idValidoInformado);
            var compraClienteMock = _listaMock.FirstOrDefault();

            Assert.NotNull(compraCliente);
            Assert.Equivalent(compraClienteMock, compraCliente);
        }

        [Fact]
        public void ObterPorId_InformandoIdInvalido_DeveRetornarExcecaoObjetoNaoEncontrado()
        {
            var idValidoInformado = 3;
            var idInvalidoInformado = 100;
            var compraCliente = _servicoCompraCliente.ObterPorId(idValidoInformado);

            var excecao = Assert.Throws<Exception>(() => _servicoCompraCliente.ObterPorId(idInvalidoInformado));
            Assert.Equal($"O ID informado ({idInvalidoInformado}) é inválido. Compra não encontrada.", excecao.Message);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObjetoDoTipoCompraCliente()
        {
            var idValidoInformado = 2;
            var compraCliente = _servicoCompraCliente.ObterPorId(idValidoInformado);
            
            Assert.NotNull(compraCliente);
            Assert.IsType<CompraCliente>(compraCliente);
        }
    }
}
