using Cod3rsGrowth.Dominio.Enums;
using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(20240617082100)]
    public class AddGeneros : Migration
    {
        public override void Up()
        {
            Create.Table("Generos")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Nome").AsString(50).NotNullable();

            InserirValoresNaTabela();
        }

        private void InserirValoresNaTabela()
        {
            foreach (Genero genero in Enum.GetValues(typeof(Genero)))
            {
                Insert.IntoTable("Generos").Row(new { Id = (int)genero, Nome = genero.ToString() });
            }
        }

        public override void Down()
        {
            Delete.Table("Generos");
        }
    }
}
