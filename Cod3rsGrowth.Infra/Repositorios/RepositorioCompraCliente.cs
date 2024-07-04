using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoDeDados;
using LinqToDB;
using LinqToDB.Data;

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
            AdicionarProdutos(compraCliente.Id, compraCliente.listaIdDosProdutos);

            return compraCliente;
        }

        public CompraCliente Editar(CompraCliente compra)
        {
            var compraNoBanco = _db.ComprasCliente.FirstOrDefault(c => c.Id == compra.Id)
                ?? throw new Exception("Compra não encontrada.");

            var produtosAnteriores = ObterProdutosVinculados(compra.Id);
            var produtosAtualizados = compra.listaIdDosProdutos;

            var hashSetAnteriores = new HashSet<int>(produtosAnteriores);
            var hashSetAtualizados = new HashSet<int>(produtosAtualizados);

            List<int> produtosParaRemover = new();
            List<int> produtosParaAdicionar = new();

            produtosAnteriores.ForEach(item =>
            {
                if (!hashSetAtualizados.Contains(item))
                {
                    produtosParaRemover.Add(item);
                }
            });

            produtosAtualizados.ForEach(item =>
            {
                if (!hashSetAnteriores.Contains(item))
                {
                    produtosParaAdicionar.Add(item);
                }
            });

            try
            {
                _db.Update(compra);
                RemoverProdutos(produtosParaRemover);
                AdicionarProdutos(compra.Id, produtosParaAdicionar);
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

        private void AdicionarProdutos(int compraId, List<int> idProdutos)
        {
            idProdutos.ForEach(id =>
            {
                _db.Execute(
                    "INSERT INTO ComprasObras (CompraId, ObraId) VALUES (@compraId, @item)",
                    new DataParameter("@compraId", compraId),
                    new DataParameter("@item", id)
                );
            });
        }

        private void RemoverProdutos(List<int> idsDosProdutos)
        {
            idsDosProdutos.ForEach(id =>
            {
                _db.Execute(
                    $"DELETE FROM ComprasObras WHERE ObraId = @id",
                    new DataParameter("@id", id)    
                );
            });
        }

        public List<int> ObterProdutosVinculados(int compraId)
        {
            List<int> produtosVinculados = _db.Query<int>($"SELECT ObraId FROM ComprasObras " +
                                                          $"WHERE CompraId = @compraId", new { compraId }).ToList();

            return produtosVinculados;
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
