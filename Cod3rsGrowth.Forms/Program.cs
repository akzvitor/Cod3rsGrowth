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
            var host = CriarHostBuilder().Build();
            ServiceProvider = host.Services;
            Application.Run(new Form1());

            using (var serviceProvider = CriarServicos())
            using (var escopo = serviceProvider.CreateScope()) 
            {
                AtualizarBancoDeDados(escopo.ServiceProvider);
            }
        }

        private static ServiceProvider CriarServicos()
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

        public static IServiceProvider ServiceProvider { get; set; }

        static IHostBuilder CriarHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((contexto, servicos) => {

                });
        }
    }
}