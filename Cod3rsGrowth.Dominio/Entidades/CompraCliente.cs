namespace Cod3rsGrowth.Dominio.Entidades
{
    public class CompraCliente
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<int> Produtos { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
