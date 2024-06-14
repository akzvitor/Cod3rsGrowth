using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(002)]
    public class AddGeneros : Migration
    {
        public override void Up()
        {
            Create.Table("Generos")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsInt32();
        }

        public override void Down()
        {
            Delete.Table("Generos");
        }
    }
}
