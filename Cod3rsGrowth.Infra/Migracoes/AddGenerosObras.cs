using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(004)]
    public class AddGenerosObras : Migration
    {
        public override void Up()
        {
            Create.Table("GenerosObras")
                .WithColumn("IdObra").AsInt32().ForeignKey("Obras", "Id")
                .WithColumn("IdGenero").AsInt32().ForeignKey("Generos", "Id");
        }

        public override void Down()
        {
            Delete.Table("GenerosObras");
        }
    }
}
