using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes
{
    public class ServicoObraTestes : TesteBase
    {
        private readonly IServicoObra _servicoObra;

        public ServicoObraTestes()
        {
            _servicoObra = ServiceProvider.GetService<IServicoObra>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoObra)}]");
        }

        [Fact]
        public void Obter_todos_vai_no_banco_de_dados_e_deve_retornar_lista_com_dados()
        {
            //arrange

            //act
            var novaObra = new Obra
            {
                Titulo = "Na Honjaman Level Up",
                Formato = Dominio.Enums.Formato.Manhwa,
                Autor = "Chu-Gong"
            };

            var novaObra2 = new Obra
            {
                Titulo = "Jeonjijeok Dokja Sijeom",
                Formato = Dominio.Enums.Formato.Manhwa,
                Autor = "UMI"
            };

            _servicoObra.ObterTodos().Add(novaObra);
            _servicoObra.ObterTodos().Add(novaObra2);
            var obra1 = _servicoObra.ObterTodos().FirstOrDefault();

            //assert
            Assert.NotNull(obra1);
            Assert.Equal(obra1, novaObra);
        }

        [Fact]
        public void Obter_todos_deve_retornar_uma_lista_da_sua_classe()
        {
            //arrange

            //act
            var obras = _servicoObra.ObterTodos();
            //assert
            Assert.NotNull(obras);
            Assert.IsType <List<Obra>>(obras);
        }
    }
}