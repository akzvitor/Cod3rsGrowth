﻿using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioObra
    {
        List<Obra> ObterTodos();
        Obra ObterPorId(int idInformado);
        void Criar(Obra novaObra);
    }
}
