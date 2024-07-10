using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasController : ControllerBase
    {
        private readonly ServicoObra _servicoObra;
        public ObrasController(ServicoObra servicoObra)
        {
            _servicoObra = servicoObra;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Obra obra)
        {
            if (obra == null)
            {
                return BadRequest();
            }

            var novaObra = _servicoObra.Criar(obra);

            return Created($"obra/{novaObra.Id}", novaObra);
        }

        [HttpPut]
        public IActionResult Editar([FromBody]Obra obra)
        {
            if (obra == null)
            {
                return BadRequest();
            }

            var obraEditada = _servicoObra.Editar(obra);

            return Ok(obraEditada);
        }
    }
}
