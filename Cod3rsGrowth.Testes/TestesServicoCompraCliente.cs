﻿using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Enums;
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

        public TestesServicoCompraCliente()
        {
            CarregarServicos();
            _servicoCompraCliente.ObterTodos().Clear();
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
                    Produtos = new List<Obra>
                        {
                            new()
                            {
                                Titulo = "Re:Zero kara Hajimeru Isekai Seikatsu",
                                Autor = "Tappei Nagatsuki",
                                FoiFinalizada = false,
                                Formato = Formato.WebNovel,
                                Generos = new List<Genero>
                                {
                                    Genero.Sobrenatural,
                                    Genero.Psicologico,
                                    Genero.Misterio
                                },
                                InicioPublicacao = DateTime.Parse("Jan 24, 2014"),
                                NumeroCapitulos = 20,
                                ValorObra = 0,
                                Sinopse = "Subaru Natsuki estava apenas tentando chegar à loja de conveniência, " +
                                "mas acabou convocado para outro mundo. Ele encontra coisas comuns – situações de " +
                                "risco de vida, belezas de cabelos prateados, fadas felinas – você sabe, coisas normais. " +
                                "Tudo isso já seria ruim o suficiente, mas ele também ganhou a habilidade mágica " +
                                "mais inconveniente de todas: viajar no tempo, mas ele precisa morrer para usá-la. " +
                                "Como você retribui alguém que salvou sua vida quando tudo o que você pode fazer é morrer?"
                            },
                            new()
                            {
                                Titulo = "Kaguya-sama wa Kokurasetai: Tensaitachi no Renai Zunousen",
                                Autor = "Aka Akasaka",
                                FoiFinalizada = true,
                                Formato = Formato.Manga,
                                Generos = new List<Genero>
                                {
                                    Genero.Romance,
                                    Genero.Comedia,
                                    Genero.VidaEscolar
                                },
                                InicioPublicacao = DateTime.Parse("May 19, 2015"),
                                NumeroCapitulos = 281,
                                ValorObra = 12,
                                Sinopse = "Como líderes do conselho estudantil de sua prestigiada academia, Kaguya e Miyuki " +
                                "são a elite da elite! Mas no topo é solitário… Felizmente para eles, eles se apaixonaram! Só " +
                                "há um problema: ambos têm orgulho demais para admitir. E assim começa a trama diária para " +
                                "fazer com que o objeto de seu afeto confesse primeiro seus sentimentos românticos... O amor " +
                                "é uma guerra que você ganha ao perder."
                            }
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
                    Produtos = new List<Obra>
                    {
                        new()
                        {
                            Titulo = "Hagane no Renkinjutsushi",
                            Autor = "Hiromu Arakawa",
                            FoiFinalizada = true,
                            Formato = Formato.Manga,
                            Generos = new List<Genero>
                            {
                                Genero.Acao,
                                Genero.Aventura,
                                Genero.Drama,
                                Genero.Fantasia
                            },
                            InicioPublicacao = DateTime.Parse("Jul 12, 2001"),
                            NumeroCapitulos = 116,
                            ValorObra = 20,
                            Sinopse = "A alquimia destruiu os corpos dos irmãos Elric. O vínculo deles pode torná-los " +
                            "inteiros novamente? Neste mundo, os alquimistas são aqueles que estudam e realizam a " +
                            "arte da transmutação alquímica – a ciência da manipulação e transformação da matéria. Eles estão " +
                            "sujeitos à Lei da Troca Equivalente: para ganhar algo, é preciso sacrificar algo de igual valor. " +
                            "Em um ritual alquímico que deu errado, Edward Elric perdeu o braço e a perna, e seu irmão Alphonse " +
                            "se tornou nada além de uma alma em uma armadura. Equipado com membros mecânicos de “correio " +
                            "automático”, Edward se torna um alquimista do estado, buscando a única coisa que pode restaurar o " +
                            "corpo dele e de seu irmão... a lendária Pedra Filosofal."
                        },
                        new()
                        {
                            Titulo = "Kiseijuu",
                            Autor = "Hitoshi Iwaaki",
                            FoiFinalizada = true,
                            Formato = Formato.Manga,
                            Generos = new List<Genero>
                            {
                                Genero.Acao,
                                Genero.Drama,
                                Genero.SciFi,
                                Genero.Horror,
                                Genero.Psicologico
                            },
                            InicioPublicacao = DateTime.Parse("Nov 22, 1989"),
                            NumeroCapitulos = 64,
                            ValorObra = 40,
                            Sinopse = "Eles chegam em silêncio e escuridão. Eles descem dos céus. Eles têm fome de carne humana. " +
                            "Eles estão em toda parte. Eles são parasitas, criaturas alienígenas que devem invadir – e assumir o " +
                            "controle – de um hospedeiro humano para sobreviver. E depois de infectarem suas vítimas, eles podem " +
                            "assumir qualquer forma mortal que escolherem: monstros com dentes gigantes, demônios alados, criaturas " +
                            "com lâminas no lugar das mãos. Mas a maioria optou por esconder o seu propósito letal por trás de " +
                            "rostos humanos comuns. Portanto, ninguém conhece o segredo deles – exceto um estudante comum do ensino " +
                            "médio. Shin está lutando pelo controle de seu próprio corpo contra um parasita alienígena, mas será que " +
                            "ele encontrará uma maneira de alertar a humanidade sobre os horrores que estão por vir?"
                        }
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
                    Produtos = new List<Obra>
                        {
                            new()
                            {
                                Titulo = "Na Honjaman Level Up",
                                Autor = "Chu-Gong",
                                FoiFinalizada = true,
                                Formato = Formato.Manhwa,
                                Generos = new List<Genero>
                                {
                                    Genero.Acao,
                                    Genero.Aventura,
                                    Genero.Fantasia
                                },
                                InicioPublicacao = DateTime.Parse("Mar 4, 2018"),
                                NumeroCapitulos = 201,
                                ValorObra = 70,
                                Sinopse = "Num mundo onde seres despertos chamados “Caçadores” devem lutar contra monstros mortais " +
                                "para proteger a humanidade, Sung Jinwoo, apelidado de “o caçador mais fraco de toda a humanidade”, " +
                                "encontra-se numa luta constante pela sobrevivência. Um dia, depois de um encontro brutal em uma " +
                                "masmorra dominada destruir seu grupo e ameaçar acabar com sua vida, um misterioso Sistema o escolhe " +
                                "como único jogador: Jinwoo teve a rara oportunidade de aprimorar suas habilidades, possivelmente além " +
                                "de quaisquer limites conhecidos. . Acompanhe a jornada de Jinwoo enquanto ele enfrenta inimigos cada " +
                                "vez mais fortes, tanto humanos quanto monstros, para descobrir os segredos profundos das masmorras e a " +
                                "extensão máxima de seus poderes."
                            },
                            new()
                            {
                                Titulo = "Jeonjijeok Dokja Sijeom",
                                Autor = "Sing-Shong",
                                FoiFinalizada = false,
                                Formato = Formato.Manhwa,
                                Generos = new List<Genero>
                                {
                                    Genero.Acao,
                                    Genero.Aventura,
                                    Genero.Fantasia
                                },
                                InicioPublicacao = DateTime.Parse("May 26, 2020"),
                                NumeroCapitulos = 180,
                                ValorObra = 50,
                                Sinopse = "Naquela época, Dok-Ja não tinha ideia. Ele não tinha ideia de que seu romance favorito na " +
                                "web, 'Três maneiras de sobreviver ao apocalipse', ganharia vida e que ele se tornaria a única pessoa " +
                                "a saber como o mundo iria acabar. Ele também não tinha ideia de que acabaria se tornando o protagonista " +
                                "desse romance que virou realidade. Agora, Dok-Ja embarcará em uma jornada para mudar o rumo da história " +
                                "e salvar a humanidade de uma vez por todas."
                            }
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

            var listaDoBanco = _servicoCompraCliente.ObterTodos();

            Assert.NotNull(listaDoBanco);
            Assert.Equivalent(listaMock, listaDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDoTipoCompraCliente()
        {
            var listaDoBanco = _servicoCompraCliente.ObterTodos();

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
            novaCompra.Produtos = new List<Obra> { };
            var mensagemDeErro = "A compra deve conter a lista de produtos preenchida.";

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
    }
}
