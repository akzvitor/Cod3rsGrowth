using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasController : ControllerBase
    {
        private readonly ServicoObra _servicoObra;
        private readonly ServicoCompraCliente _servicoCompraCliente;

        public ObrasController(ServicoObra servicoObra, ServicoCompraCliente servicoCompraCliente)
        {
            _servicoObra = servicoObra;
            _servicoCompraCliente = servicoCompraCliente;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery]FiltroObra? filtro) 
        {
            var listaDeObras = _servicoObra.ObterTodos(filtro);

            return Ok(listaDeObras);
        }

        [HttpGet("formatos")]
        public IActionResult ObterFormatos() {
            var formatos = ExtensaoEnums.ObterListaDescricoesEnum<Formato>();

            return Ok(formatos);
        }

        [HttpGet("generos")]
        public IActionResult ObterGeneros() {
            var generos = ExtensaoEnums.ObterListaDescricoesEnum<Genero>();

            return Ok(generos);
        }

        [HttpGet("Compra/{id}")]
        public IActionResult ObterObrasVinculadas(int id)
        {
            var listaDeObras = _servicoObra.ObterObrasVinculadas(id);

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
