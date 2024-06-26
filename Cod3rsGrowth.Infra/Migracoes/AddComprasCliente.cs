﻿using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(20240617082200)]
    public class AddComprasCliente : Migration
    {
        public override void Up()
        {
            Create.Table("ComprasCliente")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CPF").AsString()
                .WithColumn("Nome").AsString(100)
                .WithColumn("Telefone").AsString()
                .WithColumn("E-mail").AsString()
                .WithColumn("Valor").AsDecimal()
                .WithColumn("Data da compra").AsDateTime();
        }
 
        public override void Down()
        {
            Delete.Table("ComprasCliente");
        }
    }
}
