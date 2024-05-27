using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using FluentValidation;
using FluentValidation.Validators;
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
            Assert.IsType <List<Obra>>(_listaDoBanco);
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

        [Fact]
        public void Criar_InformandoDadoInvalido_DeveRetornarExcecaoComMensagemCorreta()
        {
            var novaObra = new Obra
            {
                Id = 50,
                Titulo = "Dragon Ball Z",
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
                ValorObra = -4,
                Sinopse = "aaaaaaaaaaaaaaa"
            };

            var excecao = Assert.Throws<ValidationException>(() => _servicoObra.Criar(novaObra));
            Assert.Equal($"aaa", excecao.Message);
        }
    }
}