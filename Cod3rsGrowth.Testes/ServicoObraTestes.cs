using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes
{
    public class ServicoObraTestes : TesteBase
    {
        private IServicoObra? _servicoObra;
        private List<Obra> _listaDoBanco;
        private List<Obra> _listaMock;

        public ServicoObraTestes()
        {
            CarregarServico();
            _listaMock = InicializarDadosMockados();
        }

        private void CarregarServico()
        {
            _servicoObra = ServiceProvider.GetService<IServicoObra>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoObra)}]");
        }

        private List<Obra> InicializarDadosMockados()
        {
            List<Obra> listaDeObras = new()
            {
                new Obra
                {
                    Id = 1,
                    Titulo = "Na Honjaman Level Up",
                    Formato = Formato.Manhwa,
                    Autor = "Chu-Gong"
                },
                new Obra
                {
                    Id = 2,
                    Titulo = "Jujutsu Kaisen",
                    Formato = Formato.Manga,
                    Autor = "Gege Akutami"
                },
                new Obra
                {
                    Id = 3,
                    Titulo = "Jeonjijeok Dokja Sijeom",
                    Formato = Formato.Manhwa,
                    Autor = "UMI"
                },
                new Obra
                {
                    Id = 4,
                    Titulo = "Re:Zero kara Hajimeru Isekai Seikatsu",
                    Formato = Formato.WebNovel,
                    Autor = "Tappei Nagatsuki"
                },
                new Obra
                {
                    Id = 5,
                    Titulo = "One Piece",
                    Formato = Formato.Manga,
                    Autor = "Eiichiro Oda"
                },
                new Obra
                {
                    Id = 100,
                    Titulo = "Dragon Ball",
                    Autor = "Akira Toriyama",
                    FoiFinalizada = false,
                    Formato = Formato.Manga,
                    Generos = new List<Genero>
                    {
                        Genero.Acao,
                        Genero.ArtesMarciais,
                        Genero.Aventura
                    },
                    InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                    NumeroCapitulos = 20,
                    ValorObra = 0,
                    Sinopse = "Sinopse Dragon Ball"
                }
            };

            _listaDoBanco = _servicoObra.ObterTodos();

            foreach (var obra in listaDeObras)
            {
                _listaDoBanco.Add(obra);
            }

            return listaDeObras;
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarAListaDeObras()
        {
            _listaDoBanco = _servicoObra.ObterTodos();

            Assert.NotNull(_listaDoBanco);
            Assert.Equivalent(_listaMock, _listaDoBanco);
        }

        [Fact]
        public void ObterTodos_EmQualquerCenario_DeveRetornarUmaListaDoTipoObra()
        {
            _listaDoBanco = _servicoObra.ObterTodos();

            Assert.NotNull(_listaDoBanco);
            Assert.IsType<List<Obra>>(_listaDoBanco);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObraCorreta()
        {
            var idValidoInformado = 1;
            var obra = _servicoObra.ObterPorId(idValidoInformado);
            var obraMock = _listaMock.FirstOrDefault();

            Assert.NotNull(obra);
            Assert.Equivalent(obraMock, obra);
        }

        [Fact]
        public void ObterPorId_InformandoIdInvalido_DeveRetornarExcecaoObjetoNaoEncontrado()
        {
            var idValidoInformado = 4;
            var idInvalidoInformado = 200;
            var obra = _servicoObra.ObterPorId(idValidoInformado);

            var excecao = Assert.Throws<Exception>(() => _servicoObra.ObterPorId(idInvalidoInformado));
            Assert.Equal($"O ID informado ({idInvalidoInformado}) é inválido. Obra não encontrada.", excecao.Message);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObjetoDoTipoObra()
        {
            var idValidoInformado = 5;
            var obra = _servicoObra.ObterPorId(idValidoInformado);

            Assert.NotNull(obra);
            Assert.IsType<Obra>(obra);
        }

        //Método Criar
        [Fact]
        public void Criar_ComDadosValidos_DeveCriarObjetoCorretamente()
        {
            var novaObra = new Obra
            {
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };

            _servicoObra.Criar(novaObra);
            _listaDoBanco = _servicoObra.ObterTodos();

            var obraNaListaMock = _listaMock.Last();
            var obraNoBanco = _listaDoBanco.Last();

            Assert.NotNull(_listaDoBanco);
            Assert.Equivalent(obraNaListaMock, obraNoBanco);
        }

        [Theory]
        [InlineData("")]
        [InlineData("      ")]
        [InlineData(null)]
        public void Criar_ComTituloVazio_DeveRetornarExcecao(string titulo)
        {
            var novaObra = new Obra
            {
                Id = 50,
                Titulo = titulo,
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "O titulo da obra é obrigatório. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComTituloMaiorQue2000Caracteres_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 51,
                Titulo = "My Life Is Just As Wrong As I Expected After Traveling to Another World Where " +
                "I’m Surrounded By Cute Girls At A Magical High School And Am Also The Fabled Hero of Legend, " +
                "But Before I Tell You That Story I Have To Tell You This Story, In Which I Was Walking " +
                "Along With My Unbelievably, Impossibly Cute Younger Sister Who Doesn’t Like Me At All, " +
                "And She Said To Me It Was My Fault She Wasn’t Popular No Matter How She Looked At It As We " +
                "Walked To School Together, And We Stopped To Look At A Garden, Which Had A Flower Whose Name " +
                "I Don’t Remember, When Suddenly A Portal Opened Up To Another World And When I Landed In A " +
                "Field And My Face Was Buried In The Largest Pair of Boobs I’d Ever Seen, And My Sister Hit " +
                "Me And Called Me An Idiot While Blushing, But Then The Girl I Landed On Saw The Birthmark On " +
                "My Hand And Gasped And She Grabbed My Hand And I Blushed But She Started Dragging Me Away " +
                "And My Sister Got Mad And Chased After Us And I Asked Where We Were Going, And She Said She " +
                "Was Taking Us To Grimheart Magic School, Where She Was The School President, And Then I Gasped " +
                "Because I Was Now In A Magical World, And When We Got To The School Which Was A Giant Castle " +
                "I Asked The Girl What Her Name Was And She Said It Was Akane Yuusha, Which I Thought Was A " +
                "Tad Strange Since She Had Blonde Hair And Blue Eyes And The Entire Aesthetic Of The School " +
                "Seemed Very Ancient European, But I Forgot About All Of That When She Told Me We Needed To " +
                "See The Headmaster Because She Had Been Taught That The Mark On My Hand Was The Symbol Of " +
                "The Reincarnation Of The Legendary Dragon Hero Of Legendary Literature, And I Said That Was " +
                "A Cool Thing To Be Taught Because At Our School The Only Book We Learned Was Atlas Shrugged, " +
                "And She Asked What That Was And I Told Her I Was The Book Our Society Based Its Philosophy On " +
                "A Speech From, And She Asked Me To Recite The Speech, Which I Did, And The Speech Went “For " +
                "A Speech From, And She Asked Me To Recite The Speech, Which I Did, And The Speech Went “For " +
                "A Speech From, And She Asked Me To Recite The Speech, Which I Did, And The Speech Went “For " +
                "A Speech From, And She Asked Me To Recite The Speech, Which I Did, And The Speech Went “For " +
                "Twelve Years You Have Been Asking…                                                          ",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "O título pode ter no máximo 2000 caracteres. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("      ")]
        [InlineData(null)]
        public void Criar_ComNomeDoAutorVazio_DeveRetornarExcecao(string autor)
        {
            var novaObra = new Obra
            {
                Id = 50,
                Titulo = "Dragon Ball",
                Autor = autor,
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "O nome do autor da obra é obrigatório. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("&&%*$*(")]
        [InlineData("Aaaaa@@#$")]
        public void Criar_ComNomeDoAutorInvalido_DeveRetornarExcecao(string autor)
        {
            var novaObra = new Obra
            {
                Id = 50,
                Titulo = "Dragon Ball",
                Autor = autor,
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "O nome do autor deve conter apenas letras, espaços e símbolos como - ou _. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComNomeDoAutorMaiorQue150Caracteres_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 50,
                Titulo = "Dragon Ball",
                Autor = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "O nome do autor deve ter até 150 caracteres. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("      ")]
        [InlineData(null)]
        public void Criar_ComSinopseVazia_DeveRetornarExcecao(string sinopse)
        {
            var novaObra = new Obra
            {
                Id = 50,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = sinopse
            };
            var mensagemDeErro = "A obra deve ter uma sinopse. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComSinopseMaiorQue2000Caracteres_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 50,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "My Life Is Just As Wrong As I Expected After Traveling to Another World Where " +
                "I’m Surrounded By Cute Girls At A Magical High School And Am Also The Fabled Hero of Legend, " +
                "But Before I Tell You That Story I Have To Tell You This Story, In Which I Was Walking " +
                "Along With My Unbelievably, Impossibly Cute Younger Sister Who Doesn’t Like Me At All, " +
                "And She Said To Me It Was My Fault She Wasn’t Popular No Matter How She Looked At It As We " +
                "Walked To School Together, And We Stopped To Look At A Garden, Which Had A Flower Whose Name " +
                "I Don’t Remember, When Suddenly A Portal Opened Up To Another World And When I Landed In A " +
                "Field And My Face Was Buried In The Largest Pair of Boobs I’d Ever Seen, And My Sister Hit " +
                "Me And Called Me An Idiot While Blushing, But Then The Girl I Landed On Saw The Birthmark On " +
                "My Hand And Gasped And She Grabbed My Hand And I Blushed But She Started Dragging Me Away " +
                "And My Sister Got Mad And Chased After Us And I Asked Where We Were Going, And She Said She " +
                "Was Taking Us To Grimheart Magic School, Where She Was The School President, And Then I Gasped " +
                "Because I Was Now In A Magical World, And When We Got To The School Which Was A Giant Castle " +
                "I Asked The Girl What Her Name Was And She Said It Was Akane Yuusha, Which I Thought Was A " +
                "Tad Strange Since She Had Blonde Hair And Blue Eyes And The Entire Aesthetic Of The School " +
                "Seemed Very Ancient European, But I Forgot About All Of That When She Told Me We Needed To " +
                "See The Headmaster Because She Had Been Taught That The Mark On My Hand Was The Symbol Of " +
                "The Reincarnation Of The Legendary Dragon Hero Of Legendary Literature, And I Said That Was " +
                "A Cool Thing To Be Taught Because At Our School The Only Book We Learned Was Atlas Shrugged, " +
                "And She Asked What That Was And I Told Her I Was The Book Our Society Based Its Philosophy On " +
                "A Speech From, And She Asked Me To Recite The Speech, Which I Did, And The Speech Went “For " +
                "A Speech From, And She Asked Me To Recite The Speech, Which I Did, And The Speech Went “For " +
                "A Speech From, And She Asked Me To Recite The Speech, Which I Did, And The Speech Went “For " +
                "A Speech From, And She Asked Me To Recite The Speech, Which I Did, And The Speech Went “For " +
                "Twelve Years You Have Been Asking…                                                          "
            };
            var mensagemDeErro = "A sinopse deve ter no máximo 2000 caracteres. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComNumeroDeCapitulosMenorQueUm_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 52,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = -1,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "A obra deve ter pelo menos 1 capítulo. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComValorDaObraNegativo_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 53,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = -1,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "O valor da obra não pode ser negativo. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.NotNull(excecao);
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComInicioDaPublicacaoNulo_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 55,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "A data de início da publicação da obra deve ser informada. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComInicioDaPublicacaoNoFuturo_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 56,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Nov 21, 3000"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "Data inválida. Não é possível colocar uma data futura. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComFormatoInvalido_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 57,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = (Formato)32,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "Formato de obra inválido. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComListaDeGenerosVazia_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 58,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manhwa,
                Generos = new List<Genero>{ },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "O(s) gênero(s) da obra deve(m) ser informado(s). | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComListaDeGenerosMaiorQue10_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 59,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manhwa,
                Generos = new List<Genero> 
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    Genero.Aventura,
                    Genero.Comedia,
                    Genero.Drama,
                    Genero.Romance,
                    Genero.Psicologico,
                    Genero.Historico,
                    Genero.Musical,
                    Genero.Horror,
                    Genero.SciFi,
                    Genero.MahouShoujo
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "O limite de gêneros em uma única obra é 10. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }

        [Fact]
        public void Criar_ComGeneroInvalidoNaListaDeGeneros_DeveRetornarExcecao()
        {
            var novaObra = new Obra
            {
                Id = 57,
                Titulo = "Dragon Ball",
                Autor = "Akira Toriyama",
                FoiFinalizada = false,
                Formato = Formato.Manga,
                Generos = new List<Genero>
                {
                    Genero.Acao,
                    Genero.ArtesMarciais,
                    (Genero)45
                },
                InicioPublicacao = DateTime.Parse("Sep 15, 1991"),
                NumeroCapitulos = 20,
                ValorObra = 0,
                Sinopse = "Sinopse Dragon Ball"
            };
            var mensagemDeErro = "Genero informado inválido. | ";

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal(mensagemDeErro, excecao.Message);
        }
    }
}