using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(001)]
    public class AddObras : Migration
    {
        public override void Up()
        {
            Create.Table("Obras")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Título").AsString()
                .WithColumn("Autor").AsString()
                .WithColumn("Sinopse").AsString()
                .WithColumn("Número de capítulos").AsInt32()
                .WithColumn("Valor").AsDecimal()
                .WithColumn("Formato").AsInt32()
                .WithColumn("Foi finalizada").AsBoolean()
                .WithColumn("Início da publicação").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("Obras");
        }
    }
}
