﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoDeDados;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioObra : IRepositorioObra
    {
        private readonly DbCodersGrowth _db;

        public RepositorioObra(DbCodersGrowth conexaoComBancoDeDados) 
        {
            _db = conexaoComBancoDeDados;
        }

        public List<Obra> ObterTodos(FiltroObra filtro)
        {
            var query = Filtrar(_db.Obras, filtro);
            var obrasFiltradas = query.ToList();

            return obrasFiltradas;
        }

        public Obra ObterPorId(int id)
        {
            var obraRequisitada = _db.Obras.FirstOrDefault(o => o.Id == id)
                ?? throw new Exception("Obra não encontrada.");

            return obraRequisitada;
        }

        public Obra Criar(Obra obra)
        {
            obra.Id = _db.InsertWithInt32Identity(obra);
            SalvarGeneros(obra.Id, obra.GenerosParaCriacao);

            return obra;
        }

        public Obra Editar(Obra obra)
        {
            var obraNoBanco = _db.Obras.FirstOrDefault(o => o.Id == obra.Id)
                ?? throw new Exception("Obra não encontrada.");

            try   
            {
                _db.Update(obra);
            }
            catch (Exception ex) 
            {
                throw new Exception("Não foi possível editar a obra.");            
            }

            return obra;
        }

        public void Remover(int id)
        {
            var obraNoBanco = _db.Obras.FirstOrDefault(o => o.Id == id)
                ?? throw new Exception("Obra não encontrada.");

            try
            {
                _db.Obras
                    .Where(o => o.Id == id)
                    .Delete();

                RemoverComprasVinculadas();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível remover a obra selecionada.");
            }
        }

        private void SalvarGeneros(int idObra, List<string> generos)
        {
            foreach (var item in generos)
            {
                _db.Execute(
                    $"INSERT INTO GenerosObras (ObraId, Genero) VALUES (@idObra, @item)",
                    new DataParameter("@idObra", idObra),
                    new DataParameter("@item", @item)
                );
            }
        }

        private void RemoverComprasVinculadas()
        {
            _db.Execute($"DELETE FROM ComprasObras Where ObraId = NULL");
        }

        public static IQueryable<Obra> Filtrar(IQueryable<Obra> obras, FiltroObra filtro) 
        {
            if (filtro == null)
            {
                return obras;
            }

            if (!string.IsNullOrEmpty(filtro.AutorObra))
            {
                obras = obras.Where(o => o.Autor.Contains(filtro.AutorObra));
            }

            if (!string.IsNullOrEmpty(filtro.TituloObra))
            {
                obras = obras.Where(o => o.Titulo.Contains(filtro.TituloObra));
            }

            if (filtro.FormatoObra.HasValue)
            {
                obras = obras.Where(o => o.Formato == filtro.FormatoObra.Value);
            }

            if (filtro.ObraFoiFinalizada.HasValue)
            {
                obras = obras.Where(o => o.FoiFinalizada ==  filtro.ObraFoiFinalizada.Value);
            }
            
            if (filtro.ListaDeGenerosObra != null && filtro.ListaDeGenerosObra.Any())
            {
                obras = obras.Where(o => o.Generos.Any(g => filtro.ListaDeGenerosObra.Contains(g)));
            }

            if (!string.IsNullOrEmpty(filtro.AnoDaPublicacao))
            {
                obras = obras.Where(o => o.InicioPublicacao.Year.ToString() == filtro.AnoDaPublicacao);
            }

            return obras;
        }
    }
}
