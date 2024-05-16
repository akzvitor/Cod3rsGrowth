using Cod3rsGrowth.Dominio.Classes;
using Cod3rsGrowth.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioMock : IRepositorio
    {
        
        public List<Obra> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
