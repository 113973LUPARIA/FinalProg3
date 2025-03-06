using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal030225.DTOs;
using PracticaFinal030225.Servicios;

namespace PracticaFinal030225.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly ITokenService _tokenService;
        public ProductoController(IProductoService productoService, ITokenService tokenService)
        {
            _productoService = productoService;
        }

        [HttpGet("/ProductoById")]
        public async Task<ActionResult<ProductoDto>> GetProductoById([FromHeader] string token, Guid id)
        {
            var tokenValido = _tokenService.ValidarToken(token);
            if (tokenValido != null)
            {
                var producto = await _productoService.ProductoById(id);
                if (producto == null)
                {
                    return BadRequest("Producto no existente");
                }
                return Ok(producto);
            }
            return Unauthorized("Token inválido o expirado.");
        }

        [HttpGet("/ProductoCantidad")]
        public async Task<ActionResult<List<ProductoDto>>> GetProductoByCantidad([FromHeader(Name = "Authorization")]string token, [FromBody]int x)
        {
            var tokenValido = _tokenService.ValidarToken(token);
            if (tokenValido != null)
            {
                var listProductos = await _productoService.ProcutoByCantidad(x);
                if (listProductos == null)
                {
                    return BadRequest("No se encontraron Productos");
                }
                return Ok(listProductos);
            }
            return Unauthorized("Token inválido o expirado.");
        }
    }
}
