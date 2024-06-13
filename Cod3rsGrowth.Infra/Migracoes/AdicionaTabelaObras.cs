using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(20240613104400)]
    public class AdicionaTabelaObras : Migration
    {
        public override void Up()
        {
            Create.Table("Obras")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Título").AsString()
                .WithColumn("Autor").AsString()
                //.WithColumn("Generos")
                .WithColumn("Sinopse").AsString()
                .WithColumn("Número de capítulos").AsInt32()
                .WithColumn("Valor").AsDecimal()
                //.WithColumn("Formato")
                .WithColumn("Foi finalizada").AsBoolean()
                .WithColumn("Início da publicação").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("Obras");
        }
    }
}
