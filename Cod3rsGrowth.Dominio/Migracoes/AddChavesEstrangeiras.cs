using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240617082500)]
    public class AddChavesEstrangeiras : Migration
    {
        public override void Up()
        {
            Create.ForeignKey("FK_GenerosObras_IdObra")
                .FromTable("GenerosObras").ForeignColumn("IdObra")
                .ToTable("Obras").PrimaryColumn("Id");

            Create.ForeignKey("FK_GenerosObras_IdGenero")
                .FromTable("GenerosObras").ForeignColumn("IdGenero")
                .ToTable("Generos").PrimaryColumn("Id");

            Create.ForeignKey("FK_ComprasObras_IdCompra")
                .FromTable("ComprasObras").ForeignColumn("IdCompra")
                .ToTable("ComprasCliente").PrimaryColumn("Id");

            Create.ForeignKey("FK_ComprasObras_IdObra")
                .FromTable("ComprasObras").ForeignColumn("IdObra")
                .ToTable("Obras").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_GenerosObras_IdObra");
            Delete.ForeignKey("FK_GenerosObras_IdGenero");
            Delete.ForeignKey("FK_ComprasObras_IdCompra");
            Delete.ForeignKey("FK_ComprasObras_IdObra");
        }
    }
}
