using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cod3rsGrowth.Testes
{
    public class ServicoCompraClienteTestes : TesteBase
    {
        private readonly IServicoCompraCliente _servicoCompraCliente;

        public ServicoCompraClienteTestes()
        {
            _servicoCompraCliente = ServiceProvider.GetService<IServicoCompraCliente>() 
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoCompraCliente)}]");
        }

        [Fact]
        public void Obter_todos_vai_no_banco_de_dados_e_deve_retornar_lista_com_dados()
        {
            //arrange

            //act
            var novaCompra = new CompraCliente
            {
                Nome = "Vitor",
                Produtos = new List<Obra>
                {
                    new()
                    {
                        Titulo = "Jujutsu Kaisen",
                    },
                    new()
                    {
                        Titulo = "Dorohedoro"
                    }
                }
            };

            _servicoCompraCliente.ObterTodos().Add(novaCompra);
            var compra1 = _servicoCompraCliente.ObterTodos().FirstOrDefault();

            //assert
            Assert.NotNull(compra1);
            Assert.Equal(novaCompra, compra1);
        }

        [Fact]
        public void Obter_todos_deve_retornar_uma_lista_da_sua_classe()
        {
            //arrange

            //act
            var compras = _servicoCompraCliente.ObterTodos();
            //assert
            Assert.NotNull(compras);
            Assert.IsType<List<CompraCliente>>(compras);
        }
    }
}
