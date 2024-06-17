using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes
{
    public class TestesServicoCompraCliente : TesteBase
    {
        private ServicoCompraCliente? _servicoCompraCliente;
        private readonly FiltroCompraCliente _filtro;

        public TestesServicoCompraCliente()
        {
            CarregarServicos();
            _servicoCompraCliente.ObterTodos(_filtro).Clear();
            InicializarBancoDeDados();
        }

        private void CarregarServicos()
        {
            _servicoCompraCliente = ServiceProvider.GetService<ServicoCompraCliente>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoCompraCliente)}]");
        }

        private List<CompraCliente> InicializarDadosMockados()
        {
            var listaCompras = new List<CompraCliente>
            {
                new()
                {
                    Id = 100,
                    Cpf = "123.456.789-09",
                    Nome = "Vitor",
                    Telefone = "(64)99332-7668",
                    Email = "vitor@hotmail.com",
                    Produtos = new List<int>
                    {
                        100,
                        103
                    },
                    ValorCompra = 12,
                    DataCompra = DateTime.Parse("May 29, 2024")
                },
                new() {
                    Id = 101,
                    Cpf = "405.036.220-10",
                    Nome = "Matheus",
                    Telefone = "(63)99849-0887",
                    Email = "cascao@yahoo.com",
                    Produtos = new List<int>
                    {
                        101,
                        104
                    },
                    ValorCompra = 60,
                    DataCompra = DateTime.Parse("Mar 28, 2024")
                },
                new()
                {
                    Id = 102,
                    Cpf = "684.198.350-56",
                    Nome = "Henrique",
                    Telefone = "(11)99887-8022",
                    Email = "henrique@uol.com",
                    Produtos = new List<int>
                    {
                        102,
                        105
                    },
                    ValorCompra = 120,
                    DataCompra = DateTime.Parse("May 07, 2024")
                }
            };

            return listaCompras;
        }

        private void InicializarBancoDeDados()
        {
            var listaMock = InicializarDadosMockados();

            listaMock.ForEach(item => _servicoCompraCliente.Criar(item));
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarAListaCompraCliente()
        {
            var listaMock = InicializarDadosMockados();

            var listaDoBanco = _servicoCompraCliente.ObterTodos(_filtro);

            Assert.NotNull(listaDoBanco);
            Assert.Equivalent(listaMock, listaDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDoTipoCompraCliente()
        {
            var listaDoBanco = _servicoCompraCliente.ObterTodos(_filtro);

            Assert.NotNull(listaDoBanco);
            Assert.IsType<List<CompraCliente>>(listaDoBanco);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarCompraClienteCorreta()
        {
            var listaMock = InicializarDadosMockados();
            var idValidoInformado = 100;
            var compraClienteMock = listaMock.FirstOrDefault();

            var compraCliente = _servicoCompraCliente.ObterPorId(idValidoInformado);

            Assert.NotNull(compraCliente);
            Assert.Equivalent(compraClienteMock, compraCliente);
        }

        [Fact]
        public void ObterPorId_InformandoIdInvalido_DeveRetornarExcecaoObjetoNaoEncontrado()
        {
            var idInvalidoInformado = 10;

            var excecao = Assert.Throws<Exception>(() => _servicoCompraCliente.ObterPorId(idInvalidoInformado));

            Assert.Equal($"O ID informado ({idInvalidoInformado}) é inválido. Compra não encontrada.", excecao.Message);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObjetoDoTipoCompraCliente()
        {
            var idValidoInformado = 102;

            var compraCliente = _servicoCompraCliente.ObterPorId(idValidoInformado);
            
            Assert.NotNull(compraCliente);
            Assert.IsType<CompraCliente>(compraCliente);
        }

        //Criar CompraCliente
        [Fact]
        public void Criar_ComDadosValidos_DeveCriarCompraClienteComSucesso()
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();

            var compraCadastrada = _servicoCompraCliente.Criar(novaCompra);

            Assert.NotNull(compraCadastrada?.Id);
            Assert.Equivalent(novaCompra, compraCadastrada);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Criar_ComNomeDoClienteNuloOuVazio_DeveRetornarExcecao(string nomeInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Nome = nomeInvalido;
            var mensagemDeErro = "O nome do cliente deve ser informado.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("@@@$$")]
        [InlineData("    $*&#(*&¨#$(      ")]
        [InlineData("AAA222355")]
        public void Criar_ComCaracteresInvalidosNoNomeDoCliente_DeveRetornarExcecao(string nomeInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Nome = nomeInvalido;
            var mensagemDeErro = "O nome deve conter apenas letras, espaços ou símbolos como - e '.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComNomeDoClienteMaiorQue100Caracteres_DeveRetornarExcecao()
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Nome = "Antlez Broke the Stereo Neon Tide Bring Back Honesty " +
                "Coalition Feedback Hand of Aces Keep Going Captain Let's Pretend Lost State of " +
                "Dance Paper Taxis Lunar Road Up Down Strange All and I Neon Sheep Eve Hornby Faye " +
                "Bradley AJ Wilde Michael Rice Dion Watts Matthew Appleyard John Ashurst Lauren " +
                "Swales Zoe Angus Jaspreet Singh Emma Matthews Nicola Brown Leanne Pickering " +
                "Victoria Davies Rachel Burnside Gil Parker Freya Watson Alisha Watts James " +
                "Pearson Jacob Sotheran Darley Beth Lowery Jasmine Hewitt Chloe Gibson Molly " +
                "Farquhar Lewis Murphy Abbie Coulson Nick Davies Harvey Parker Kyran Williamson " +
                "Michael Anderson Bethany Murray Sophie Hamilton Amy Wilkins Emma Simpson Liam " +
                "Wales Jacob Bartram Alex Hooks Rebecca Miller Caitlin Miller Sean McCloskey " +
                "Dominic Parker Sharpe Elena Larkin Rebecca Simpson Nick Dixon Abbie Farrelly " +
                "Liam Grieves Casey Smith Downing Ben Wignall Elizabeth Hann Danielle Walker L" +
                "auren Glen James Johnson Ervine Kate Burton James Hudson Daniel Mayes Matthew " +
                "Kitching Josh Bennett Evolution Dreams";
            var mensagemDeErro = "O nome do cliente pode ter até 100 caracteres.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Criar_ComEmailNuloOuVazio_DeveRetornarExcecao(string emailInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Email = emailInvalido;
            var mensagemDeErro = "O e-mail do cliente é obrigatório.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("vvvvvvvvv")]
        [InlineData("vitorhotmail.com")]
        [InlineData("@vvvvvvvvv")]
        [InlineData("vvvvvvvvv@")]
        public void Criar_ComFormatoDeEmailInvalido_DeveRetornarExcecao(string emailInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Email = emailInvalido;
            var mensagemDeErro = "Formato de e-mail inválido.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("vit%$%$or@hotmail.com")]
        [InlineData("vitór@hotmail.com")]
        public void Criar_ComCaracteresInvalidosNoEmail_DeveRetornarExcecao(string emailInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Email = emailInvalido;
            var mensagemDeErro = "O email deve conter apenas letras sem acento, números, espaços ou alguns símbolos, como - e _.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComValorDaCompraMenorQue0_DeveRetornarExcecao()
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.ValorCompra = -1000;
            var mensagemDeErro = "O valor da compra não pode ser negativo.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComAListaDeProdutosVazia_DeveRetornarExcecao()
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Produtos = new List<int> { };
            var mensagemDeErro = "A compra deve conter pelo menos um produto.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("111.111.111-11")]
        [InlineData("1111111111")]
        [InlineData("aaaaaaaaaaa")]
        [InlineData("aaa.aaa.aaa-aa")]
        [InlineData("123.456.789-10")]
        [InlineData("666.777.888-99")]
        public void Criar_ComCPFInvalido_DeveRetornarExcecao(string cpfInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Cpf = cpfInvalido;
            var mensagemDeErro = "O CPF informado é inválido.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Criar_ComCPFNuloOuVazio_DeveRetornarExcecao(string cpfInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Cpf = cpfInvalido;
            var mensagemDeErro = "O CPF do cliente é obrigatório.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("123231231231322")]
        [InlineData("aaaaaaa")]
        [InlineData("(aa) 1111-1111")]
        [InlineData("(632)2233334-4444")]
        public void Criar_ComFormatoDeTelefoneInvalido_DeveRetornarExcecao(string telefoneInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Telefone = telefoneInvalido;
            var mensagemDeErro = "O telefone deve ter apenas números e símbolos e estar no formato correto " +
                "(XX) XXXXX-XXXX ou (XX) XXXX-XXXX.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Criar_ComTelefoneNuloOuVazio_DeveRetornarExcecao(string telefoneInvalido)
        {
            var listaMock = InicializarDadosMockados();
            var novaCompra = listaMock.FirstOrDefault();
            novaCompra.Telefone = telefoneInvalido;
            var mensagemDeErro = "O telefone do cliente é obrigatório.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        //Método Editar
        [Fact]
        public void Editar_ComDadosValidos_DeveEditarDadosDaCompraSelecionadaCorretamente()
        {
            var listaMock = InicializarDadosMockados();
            var compraEditada = listaMock.FirstOrDefault();
            compraEditada.Nome = "Heitor";

            var compraNoBanco = _servicoCompraCliente.Editar(compraEditada);

            Assert.Equivalent(compraEditada, compraNoBanco);
        }

        [Fact]
        public void Editar_ComIdInexistente_DeveRetornarExcecao()
        {
            var listaMock = InicializarDadosMockados();
            var compraASerEditada = listaMock.FirstOrDefault();
            var idInexistente = 1542;
            compraASerEditada.Id = idInexistente;
            compraASerEditada.Nome = "Alexandre";
            var mensagemDeErro = $"O ID informado ({idInexistente}) é inválido. Compra não encontrada.";

            var excecao = Assert.Throws<Exception>(() => _servicoCompraCliente.Editar(compraASerEditada));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Editar_ComDataDeCompraDiferente_DeveRetornarExcecaoDefinidaNoRuleSet()
        {
            var listaMock = InicializarDadosMockados();
            var compraEditada = listaMock.FirstOrDefault();
            compraEditada.DataCompra = DateTime.Parse("Sep 14, 2020");
            var mensagemDeErro = "A data de uma compra concluída não pode ser alterada.";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Editar(compraEditada));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        //Método Remover
        [Fact]
        public void Remover_ComIdValido_DeveRemoverACompraCorreta()
        {
            var listaMock = InicializarDadosMockados();
            var compraASerRemovida = listaMock.FirstOrDefault();
            var idDaCompra = compraASerRemovida.Id;
            var mensagemDeErro = $"O ID informado ({idDaCompra}) é inválido. Compra não encontrada.";

            _servicoCompraCliente.Remover(idDaCompra);
            var excecao = Assert.Throws<Exception>(() => _servicoCompraCliente.Remover(idDaCompra));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Remover_ComIdInvalido_DeveRetornarExcecao()
        {
            var idParaRemocao = 4000;
            var mensagemDeErro = $"O ID informado ({idParaRemocao}) é inválido. Compra não encontrada.";

            var excecao = Assert.Throws<Exception>(() => _servicoCompraCliente.Remover(idParaRemocao));

            Assert.Equal(mensagemDeErro, excecao.Message);
        }
    }
}
