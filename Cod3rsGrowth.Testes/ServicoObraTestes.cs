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
        }

        private void CarregarServico()
        {
            _servicoObra = ServiceProvider.GetService<IServicoObra>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoObra)}]");
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaDeObras()
        {
            //arrange

            //act
            var novaObra = new Obra
            {
                Titulo = "Na Honjaman Level Up",
                Formato = Formato.Manhwa,
                Autor = "Chu-Gong"
            };

            _servicoObra.ObterTodos().Add(novaObra);
            var listaDoBanco = _servicoObra.ObterTodos();

            List<Obra> listaMock = new()
            {
                novaObra
            };

            //assert
            Assert.NotNull(listaDoBanco);
            Assert.Equal(listaMock, listaDoBanco);
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
        public void ObterPorId_InformandoIdInvalido_DeveRetornarMensagemDeErro()
        {

        }

        [Fact]
        public void ObterPorId_InformandoIdValido_DeveRetornarObraCorreta()
        {
            //arrange
            var novaObra = new Obra
            {
                Id = 1, 
                Titulo = "Na Honjaman Level Up",
                Formato = Formato.Manhwa,
                Autor = "Chu-Gong"
            };

            var novaObra2 = new Obra
            {
                Id = 2,
                Titulo = "Jeonjijeok Dokja Sijeom",
                Formato = Formato.Manhwa,
                Autor = "UMI"
            };

            //act
            _servicoObra.ObterTodos().Add(novaObra);
            _servicoObra.ObterTodos().Add(novaObra2);
            var soloLeveling = _servicoObra.ObterPorId(1);
            var omniscientReaders = _servicoObra.ObterPorId(2);
            
            //assert
            Assert.NotNull(soloLeveling);
            Assert.Equal(novaObra, soloLeveling);
            Assert.NotNull(omniscientReaders);
            Assert.Equal(novaObra2, omniscientReaders);
        }
    }
}