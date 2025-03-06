using GestionInventario.Models;
using GestionInventario.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("Productos")]
        public async Task<List<Producto>> GetProductos()
        {
            return await _productoService.GetProductos();
        }

        [HttpGet("Categorias")]
        public async Task<List<Categorium>> GetCategorias()
        {
            return await _productoService.GetCategorias();
        }
    }
}
