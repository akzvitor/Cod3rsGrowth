using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ServicoCompraCliente _servicoCompraCliente;

        public ComprasController(ServicoCompraCliente servicoCompraCliente)
        {
            _servicoCompraCliente = servicoCompraCliente;
        }

        [HttpGet("Compra")]
        public IActionResult ObterTodos([FromQuery]FiltroCompraCliente? filtro)
        {
            var listaDeCompras = _servicoCompraCliente.ObterTodos(filtro);

            if (listaDeCompras == null)
            {
                return NotFound();
            }

            return Ok(listaDeCompras);
        }

        [HttpPost]
        public IActionResult Criar([FromBody]CompraCliente compra)
        {
            if (compra == null)
            {
                return BadRequest();
            }

            var novaCompra = _servicoCompraCliente.Criar(compra);

            return Created($"compra/{novaCompra.Id}", novaCompra);
        }

        [HttpPut]
        public IActionResult Editar([FromBody]CompraCliente compra)
        {
            if (compra == null)
            {
                return BadRequest();
            }

            var compraEditada = _servicoCompraCliente.Editar(compra);

            return Ok(compraEditada);
        }
    }
}
