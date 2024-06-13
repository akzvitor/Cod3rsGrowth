using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(20241306110300)]
    public class AdicionaTabelaComprasCliente : Migration
    {
        public override void Up()
        {
            Create.Table("Compras Cliente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CPF").AsString()
                .WithColumn("Nome").AsString()
                .WithColumn("Telefone").AsString()
                .WithColumn("E-mail").AsString()
                //.WithColumn("Produtos")
                .WithColumn("Valor").AsDecimal()
                .WithColumn("Data da compra").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("Compras Cliente");
        }
    }
}
