using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Servico.Servicos;
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
        }

        private void CarregarServico()
        {
            _servicoObra = ServiceProvider.GetService<IServicoObra>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoObra)}]");
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarAListaDeObras()
        {
            //arrange

            //act
            var novaObra1 = new Obra
            {
                Id = 1,
                Titulo = "Na Honjaman Level Up",
                Formato = Formato.Manhwa,
                Autor = "Chu-Gong"
            };

            _servicoObra.ObterTodos().Add(novaObra1);
            var listaDoBanco = _servicoObra.ObterTodos();

            List<Obra> listaMock = new()
            {
                novaObra1
            };

            //assert
            Assert.NotNull(listaDoBanco);
            Assert.Equivalent(listaMock, listaDoBanco);
        }

        [Fact]
        public void ObterTodos_EmQualquerCenario_DeveRetornarListaDoTipoObra()
        {
            //arrange

            //act
            var obras = _servicoObra.ObterTodos();
            //assert
            Assert.NotNull(obras);
            Assert.IsType <List<Obra>>(obras);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObraCorreta()
        {
            //arrange
            var novaObra2 = new Obra
            {
                Id = 2,
                Titulo = "Berserk",
                Formato = Formato.Manga,
                Autor = "Kento Miura"
            };

            var novaObra3 = new Obra
            {
                Id = 3,
                Titulo = "Jeonjijeok Dokja Sijeom",
                Formato = Formato.Manhwa,
                Autor = "UMI"
            };

            //act
            _servicoObra.ObterTodos().Add(novaObra2);
            _servicoObra.ObterTodos().Add(novaObra3);
            var berserk = _servicoObra.ObterPorId(2);
            var omniscientReaders = _servicoObra.ObterPorId(3);

            //assert
            Assert.NotNull(berserk);
            Assert.Equal(novaObra2, berserk);
            Assert.NotNull(omniscientReaders);
            Assert.Equal(novaObra3, omniscientReaders);
        }

        [Fact]
        public void ObterPorId_InformandoIdInvalido_DeveRetornarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            var novaObra4 = new Obra
            {
                Id = 4
            };

            //act
            _servicoObra.ObterTodos().Add(novaObra4);

            //assert
            var excecao = Assert.Throws<Exception>(() => _servicoObra.ObterPorId(100));
            Assert.Equal("ID inválido. Obra não encontrada.", excecao.Message);
        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObjetoDoTipoObra()
        {
            //arrange
            var novaObra5 = new Obra
            {
                Id = 5
            };
            //act
            _servicoObra.ObterTodos().Add(novaObra5);
            var obra = _servicoObra.ObterPorId(5);
            //assert
            Assert.NotNull(obra);
            Assert.IsType<Obra>(obra);
        }
    }
}