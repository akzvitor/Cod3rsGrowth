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

        public ServicoObraTestes()
        {
            CarregarServico();
            InicializarDadosMockados();
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
            var listaDoBanco = _servicoObra.ObterTodos();
            List<Obra> listaMock = InicializarDadosMockados();

            Assert.NotNull(listaDoBanco);
            Assert.Equivalent(listaMock, listaDoBanco);
        }

        [Fact]
        public void ObterTodos_EmQualquerCenario_DeveRetornarUmaListaDoTipoObra()
        {
            var listaDoBanco = _servicoObra.ObterTodos();

            Assert.NotNull(listaDoBanco);
            Assert.IsType <List<Obra>>(listaDoBanco);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObraCorreta()
        {
            var listaMock = InicializarDadosMockados();
            var obra = _servicoObra.ObterPorId(1);

            Assert.NotNull(obra);
            Assert.Equivalent(listaMock[0], obra);
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