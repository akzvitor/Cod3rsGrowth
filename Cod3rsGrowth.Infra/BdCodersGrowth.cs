using Cod3rsGrowth.Dominio.Classes;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra
{
    public class BdCodersGrowth : DataConnection 
    {
        public BdCodersGrowth() : base("StringConexao") { }

        public ITable<CompraCliente> CompraCliente => this.GetTable<CompraCliente>();
        public ITable<Obra>          Obra          => this.GetTable<Obra>();
    }
}
