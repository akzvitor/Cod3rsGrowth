﻿namespace Cod3rsGrowth.Dominio.Classes
{
    public class CompraCliente
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public List<Obra> Produtos { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime DataCompra { get; set; }

    }
}