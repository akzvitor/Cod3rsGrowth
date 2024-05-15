using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes
{
    public class TesteBase : IDisposable
    {

        protected IServiceProvider ServiceProvider { get; set; }
        public void Dispose()
        {
        }
    }
}
