using Cod3rsGrowth.Dominio.Classes;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra.ConexaoDeDados
{
    public class DbCodersGrowth : DataConnection
    {
        public DbCodersGrowth() : base("StringConexao") { }

        public ITable<CompraCliente> CompraCliente => this.GetTable<CompraCliente>();
        public ITable<Obra>          Obra          => this.GetTable<Obra>();
    }
}
