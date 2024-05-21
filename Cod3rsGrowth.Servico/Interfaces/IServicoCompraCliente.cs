﻿using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoCompraCliente
    {
        List<CompraCliente> ObterTodos();
        void Criar(CompraCliente novaCompraCliente);
        void Editar(CompraCliente compraCliente);
        void Remover(CompraCliente compraCliente);
        void ObterPorId();
    }
}
