﻿using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioCompraCliente
    {
        List<CompraCliente> ObterTodos();
    }
}