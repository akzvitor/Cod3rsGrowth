using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.ConexaoDeDados;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioCompraCliente : IRepositorioCompraCliente
    {
        private readonly DbCodersGrowth _db;

        public RepositorioCompraCliente(DbCodersGrowth conexaoComBancoDeDados) 
        {
            _db = conexaoComBancoDeDados;
        }

        public List<CompraCliente> ObterTodos(FiltroCompraCliente filtro)
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
            compraCliente.Id = _db.InsertWithInt32Identity(compraCliente);

            return compraCliente;
        }

        public CompraCliente Editar(CompraCliente compra)
        {
            var compraNoBanco = _db.ComprasCliente.FirstOrDefault(c => c.Id == compra.Id)
                ?? throw new Exception("Compra não encontrada.");
            
            try
            {
                _db.ComprasCliente
                .Where(c => c.Id == compra.Id)
                .Set(c => c.Cpf, compra.Cpf)
                .Set(c => c.Nome, compra.Nome)
                .Set(c => c.Telefone, compra.Telefone)
                .Set(c => c.Email, compra.Email)
                .Set(c => c.Produtos, compra.Produtos)
                .Set(c => c.ValorCompra, compra.ValorCompra)
                .Set(c => c.DataCompra, compra.DataCompra)
                .Update();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível editar a compra.");
            }
            
            return compra;
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<CompraCliente> Filtro(IQueryable<CompraCliente> compras, FiltroCompraCliente filtro)
        {
            if (filtro == null)
            {
                return compras;
            }

            if (!string.IsNullOrEmpty(filtro.NomeCliente))
            {
                compras = compras.Where(c => c.Nome.Contains(filtro.NomeCliente));
            }

            if (filtro.DataCompra.HasValue)
            {
                compras = compras.Where(c => c.DataCompra == filtro.DataCompra.Value);
            }

            if (filtro.ValorCompra.HasValue)
            {
                compras = compras.Where(c => c.ValorCompra == filtro.ValorCompra.Value);
            }

            return compras;
        }
    }
}
