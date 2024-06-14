using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(006)]
    public class AddChavesEstrangeiras : Migration
    {
        public override void Up()
        {
            Create.ForeignKey("chave_obra_generos")
                .FromTable("GenerosObras").ForeignColumn("IdObra")
                .ToTable("Obras").PrimaryColumn("Id");

            Create.ForeignKey("chave_genero_generos")
                .FromTable("GenerosObras").ForeignColumn("IdGenero")
                .ToTable("Generos").PrimaryColumn("Id");

            Create.ForeignKey("chave_compra_compras")
                .FromTable("ComprasObras").ForeignColumn("IdCompra")
                .ToTable("ComprasCliente").PrimaryColumn("Id");

            Create.ForeignKey("chave_obra_compras")
                .FromTable("ComprasObras").ForeignColumn("IdObra")
                .ToTable("Obras").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("chave_obra_generos");
            Delete.ForeignKey("chave_obra_compras");
            Delete.ForeignKey("chave_genero_generos");
            Delete.ForeignKey("chave_compra_compras");
        }
    }
}
