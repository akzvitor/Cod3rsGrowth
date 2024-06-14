using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(005)]
    public class AddComprasObras : Migration
    {
        public override void Up()
        {
            Create.Table("ComprasObras")
                .WithColumn("IdCompra").AsInt32().ForeignKey("ComprasCliente", "Id")
                .WithColumn("IdObra").AsInt32().ForeignKey("Obras", "Id");
        }

        public override void Down()
        {
            Delete.Table("ComprasObras");
        }
    }
}
