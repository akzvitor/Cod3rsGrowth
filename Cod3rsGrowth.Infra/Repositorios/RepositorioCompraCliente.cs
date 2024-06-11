using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Entidades;
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

        public List<CompraCliente> ObterTodos(Filtro filtro)
        {
            var query = Filtro(_db.ComprasCliente, filtro);
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

        public static IQueryable<CompraCliente> Filtro(IQueryable<CompraCliente> compras, Filtro filtro)
        {
            if (!string.IsNullOrEmpty(filtro.NomeCliente))
            {
                compras = compras.Where(c => c.Nome.Contains(filtro.NomeCliente));
            }

            if (filtro.DataCompra.HasValue)
            {
                compras = compras.Where(c => c.DataCompra == filtro.DataCompra.Value);
            }

            if(filtro.ValorCompra.HasValue)
            {
                compras = compras.Where(c => c.ValorCompra == filtro.ValorCompra.Value);
            }

            return compras;
        }
    }
}
