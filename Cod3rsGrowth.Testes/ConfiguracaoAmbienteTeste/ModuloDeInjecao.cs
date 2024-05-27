using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validadores;
using Cod3rsGrowth.Testes.Repositorios;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste
{
    public static class ModuloDeInjecao
    {
        public static void BindService(ServiceCollection servicos)
        {
            servicos.AddScoped<IServicoObra, ServicoObra>();
            servicos.AddScoped<IServicoCompraCliente, ServicoCompraCliente>();

            servicos.AddScoped<IRepositorioObra, RepositorioObraMock>();
            servicos.AddScoped<IRepositorioCompraCliente, RepositorioCompraClienteMock>();

            servicos.AddScoped<ObraValidador>();
        }
    }
}