using FinalGestionInventario.DTOs;
using FinalGestionInventario.Models;
using FinalGestionInventario.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;

namespace FinalGestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService) {
        _productoService = productoService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProductoDto>>> GetAllProductos() {
            var p = await _productoService.GetProductos();
            return Ok(p);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetProductoById(int id)
        {
            var p = await _productoService.GetById(id);
            return Ok(p);
        }

        [HttpGet("GetByCategoryId")]
        public async Task<ActionResult<List<ProductoDto>>> GetProductoByCatId(int id)
        {
            var p = await _productoService.GetByCatId(id);
            return Ok(p);
        }

        [HttpPost]
        public async Task<ActionResult> PostProducto(ProductoRequestDto p) {
            var a = await _productoService.CreateProducto(p);
            if (a)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProducto(ProductoUpdateDto p) 
        {
            var a = await _productoService.UpdateProducto(p);
            if (a)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
