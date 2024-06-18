using Cod3rsGrowth.Dominio.Migracoes;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace Cod3rsGrowth.Forms
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            using (var serviceProvider = CriarServicosDeMigracao())
            using (var escopo = serviceProvider.CreateScope())
            {
                AtualizarBancoDeDados(escopo.ServiceProvider);
            }

            var host = CriarHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        public static IServiceProvider ServiceProvider { get; set; }

        private static ServiceProvider CriarServicosDeMigracao()
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["StringConexao"].ToString();

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionstring)
                    .ScanIn(typeof(AddObras).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void AtualizarBancoDeDados(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

        static IHostBuilder CriarHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((contexto, servicos) => {
                    servicos.AddTransient<Form1>();
                });
        }
    }
}