using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Testes.Repositorios;
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
        }
    }
}
