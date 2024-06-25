using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoDeDados;
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
            var query = Filtrar(_db.ComprasCliente, filtro);
            return query.ToList();
        }

        public CompraCliente ObterPorId(int id)
        {
            var compraRequisitada = _db.ComprasCliente.FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Compra não encontrada.");

            return compraRequisitada;
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
                _db.Update(compra);
             
                //_db.ComprasCliente
                //.Where(c => c.Id == compra.Id)
                //.Set(c => c.Cpf, compra.Cpf)
                //.Set(c => c.Nome, compra.Nome)
                //.Set(c => c.Telefone, compra.Telefone)
                //.Set(c => c.Email, compra.Email)
                //.Set(c => c.Produtos, compra.Produtos)
                //.Set(c => c.ValorCompra, compra.ValorCompra)
                //.Set(c => c.DataCompra, compra.DataCompra)
                //.Update();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível editar a compra.");
            }
            
            return compra;
        }

        public void Remover(int id)
        {
            var compraNoBanco = _db.ComprasCliente.FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Compra não encontrada.");

            try
            {
                _db.ComprasCliente
                    .Where(c => c.Id == id)
                    .Delete();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível remover a compra.");
            }
        }

        public static IQueryable<CompraCliente> Filtrar(IQueryable<CompraCliente> compras, FiltroCompraCliente filtro)
        {
            if (filtro == null)
            {
                return compras;
            }

            if (!string.IsNullOrEmpty(filtro.NomeCliente))
            {
                compras = compras.Where(c => c.Nome.Contains(filtro.NomeCliente));
            }

            if (!string.IsNullOrEmpty(filtro.Cpf))
            {
                compras = compras.Where(c => c.Cpf.Trim().Replace(".", "").Replace("-", "").Contains(filtro.Cpf.Trim().Replace(".", "").Replace("-", "")));
            }

            if (filtro.DataCompra.HasValue && filtro.DataCompra != DateTime.MinValue)
            {
                compras = compras.Where(c => c.DataCompra.DayOfYear == filtro.DataCompra.Value.DayOfYear);
            }

            return compras;
        }
    }
}
