using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240617082300)]
    public class AddGenerosObras : Migration
    {
        public override void Up()
        {
            Create.Table("GenerosObras")
                .WithColumn("ObraId").AsInt32().ForeignKey("Obras", "Id")
                .WithColumn("GeneroId").AsInt32().ForeignKey("Generos", "Id");
        }

        public override void Down()
        {
            Delete.Table("GenerosObras");
        }
    }
}
