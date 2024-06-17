using Cod3rsGrowth.Infra.Migracoes;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Cod3rsGrowth.Forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            using (var serviceProvider = CriarServicos())
            using (var escopo = serviceProvider.CreateScope()) 
            {
                AtualizarBancoDeDados(escopo.ServiceProvider);
            }
        }

        private static ServiceProvider CriarServicos()
        {
            var stringDeConexao = "Data Source=DESKTOP-PUMGKOJ\\SQLEXPRESS;Initial Catalog=CodersGrowth;Persist Security Info=True;User ID=sa;Password=sap@123;Trust Server Certificate=True";

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(stringDeConexao)
                    .ScanIn(typeof(AddObras).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void AtualizarBancoDeDados(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}