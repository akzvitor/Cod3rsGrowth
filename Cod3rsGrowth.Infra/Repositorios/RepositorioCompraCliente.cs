using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoDeDados;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioCompraCliente : IRepositorio<CompraCliente>
    {
        private readonly DbCodersGrowth _db;

        public RepositorioCompraCliente(DbCodersGrowth conexaoComBancoDeDados) 
        {
            _db = conexaoComBancoDeDados;
        }

        public List<CompraCliente> ObterTodos()
        {
            var query = Filtro(_db.ComprasCliente, nome: "Vitor");
            var comprasFiltradas = query.ToList();

            return comprasFiltradas;
        }

        public CompraCliente ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public CompraCliente Criar(CompraCliente compraCliente)
        {
            throw new NotImplementedException();
        }

        public CompraCliente Editar(CompraCliente compraCliente)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<CompraCliente> Filtro(IQueryable<CompraCliente> compras, string? nome = null, 
                                                        DateTime? dataDaCompra = null, decimal? valorDaCompra = null)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                compras = compras.Where(c => c.Nome.Contains(nome));
            }

            if (dataDaCompra.HasValue)
            {
                compras = compras.Where(c => c.DataCompra == dataDaCompra.Value);
            }

            if(valorDaCompra.HasValue)
            {
                compras = compras.Where(c => c.ValorCompra == valorDaCompra.Value);
            }

            return compras;
        }
    }
}
