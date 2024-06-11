using Cod3rsGrowth.Dominio.Classes;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra.ConexaoDeDados
{
    public class DbCodersGrowth : DataConnection
    {
        public DbCodersGrowth() : base("StringConexao") { }

        public ITable<CompraCliente> ComprasCliente => this.GetTable<CompraCliente>();
        public ITable<Obra>          Obras          => this.GetTable<Obra>();
    }
}
