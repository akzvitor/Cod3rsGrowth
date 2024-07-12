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
        private const int ERRO_LISTA_VAZIA = 0;

        public ObrasController(ServicoObra servicoObra)
        {
            _servicoObra = servicoObra;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery]FiltroObra? filtro) 
        {
            var listaDeObras = _servicoObra.ObterTodos(filtro);

            if (listaDeObras.Count == ERRO_LISTA_VAZIA)
            {
                return NotFound();
            }

            return Ok(listaDeObras);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var obraRequisitada = _servicoObra.ObterPorId(id);

            return Ok(obraRequisitada);
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

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _servicoObra.Remover(id);

            return NoContent();
        }
    }
}
