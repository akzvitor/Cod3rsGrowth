﻿using Cod3rsGrowth.Dominio.Interfaces;
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
        public void Obter_todos_deve_retornar_uma_lista_vazia()
        {
            //arrange

            //act

            //assert
        }
    }
}
