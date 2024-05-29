﻿using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using FluentValidation;
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

        //Criar CompraCliente
        [Fact]
        public void Criar_ComDadosValidos_DeveCriarCompraClienteComSucesso()
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            _servicoCompraCliente.Criar(novaCompra);

            var compraEsperada = _servicoCompraCliente.ObterTodos().Last();

            Assert.Equivalent(novaCompra, compraEsperada);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Criar_ComNomeDoClienteVazio_DeveRetornarExcecao(string nome)
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = nome,
                Telefone = "(62)99332-7668",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "O nome do cliente deve ser informado. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComNomeDoClienteMaiorQue100Caracteres_DeveRetornarExcecao()
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Antlez Broke the Stereo Neon Tide Bring Back Honesty " +
                "Coalition Feedback Hand of Aces Keep Going Captain Let’s Pretend Lost State of " +
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
                "Kitching Josh Bennett Evolution Dreams.",
                Telefone = "(62)99332-7668",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "O nome do cliente pode ter até 100 caracteres. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Criar_ComEmailVazio_DeveRetornarExcecao(string email)
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = email,
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "O e-mail do cliente é obrigatório. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("vvvvvvvvv")]
        [InlineData("vitorhotmail.com")]
        [InlineData("@vvvvvvvvv")]
        [InlineData("vvvvvvvvv@")]
        public void Criar_ComFormatoDeEmailInvalido_DeveRetornarExcecao(string email)
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = email,
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "Formato de e-mail inválido. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComValorDaCompraMenorQue0_DeveRetornarExcecao()
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = "vitor@yahoo.com",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = -12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "O valor da compra não pode ser negativo. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComDataDeCompraNoFuturo_DeveRetornarExcecao()
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = "vitor@yahoo.com",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 3000")
            };

            var mensagemDeErro = "Não é possível informar uma data futura. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComDataDeCompraVazia_DeveRetornarExcecao()
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = "vitor@yahoo.com",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
            };

            var mensagemDeErro = "A data da compra deve ser informada. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComAListaDeProdutosVazia_DeveRetornarExcecao()
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = "vitor@yahoo.com",
                Produtos = new List<Obra> { },
                DataCompra = DateTime.Parse("May 29, 2024"),
                ValorCompra = 12,
            };

            var mensagemDeErro = "A compra deve conter a lista de produtos preenchida. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_SemAListaDeProdutos_DeveRetornarExcecao()
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = "vitor@yahoo.com",
                DataCompra = DateTime.Parse("May 29, 2024"),
                ValorCompra = 12,
            };

            var mensagemDeErro = "A compra deve conter a lista de produtos preenchida. | ";

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
        public void Criar_ComCPFInvalido_DeveRetornarExcecao(string cpf)
        {
            var novaCompra = new CompraCliente
            {
                Cpf = cpf,
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = "vitor@yahoo.com",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "O CPF informado é inválido. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Criar_ComCPFNulo_DeveRetornarExcecao(string cpf)
        {
            var novaCompra = new CompraCliente
            {
                Cpf = cpf,
                Nome = "Vitor",
                Telefone = "(62)99332-7668",
                Email = "vitor@yahoo.com",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "O CPF do cliente é obrigatório. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("123231231231322")]
        [InlineData("aaaaaaa")]
        [InlineData("(aa) 1111-1111")]
        [InlineData("(632)2233334-4444")]
        public void Criar_ComFormatoDeTelefoneInvalido_DeveRetornarExcecao(string telefone)
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = telefone,
                Email = "vitor@yahoo.com",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "O telefone deve ter apenas números e símbolos e estar no formato correto " +
                "(XX) XXXXX-XXXX ou (XX) XXXX-XXXX. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(null)]
        public void Criar_ComTelefoneNulo_DeveRetornarExcecao(string telefone)
        {
            var novaCompra = new CompraCliente
            {
                Cpf = "123.456.789-09",
                Nome = "Vitor",
                Telefone = telefone,
                Email = "vitor@yahoo.com",
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
                        Sinopse = "Sinopse Re:Zero"
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
                        Sinopse = "Sinopse Kaguya-sama"
                    }
                },
                ValorCompra = 12,
                DataCompra = DateTime.Parse("May 29, 2024")
            };

            var mensagemDeErro = "O telefone do cliente é obrigatório. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoCompraCliente.Criar(novaCompra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }
    }
}
