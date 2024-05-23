using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
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

            foreach (var obra in listaDeObras)
            {
                _servicoObra.ObterTodos().Add(obra);
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
            var obra = _servicoObra.ObterPorId(1);
            var obraMock = _listaMock[0];

            Assert.NotNull(obra);
            Assert.Equivalent(obraMock, obra);
        }

        [Fact]
        public void ObterPorId_InformandoIdInvalido_DeveRetornarExcecaoObjetoNaoEncontrado()
        {
            var idInvalido = 200;
            var obra = _servicoObra.ObterPorId(4);

            var excecao = Assert.Throws<Exception>(() => _servicoObra.ObterPorId(idInvalido));
            Assert.Equal($"O ID informado ({idInvalido}) é inválido. Obra não encontrada.", excecao.Message);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObjetoDoTipoObra()
        {
            var obra = _servicoObra.ObterPorId(5);
            
            Assert.NotNull(obra);
            Assert.IsType<Obra>(obra);
        }
    }
}