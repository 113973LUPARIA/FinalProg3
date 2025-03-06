using Final160224.DTOs;
using Final160224.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final160224.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductoController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public ProductoController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos([FromHeader(Name = "Autorizacion")] string token, [FromQuery] int cantidad)
        {

            // Buscar el token en la base de datos
            var tokenValido = await _context.Tokens
                .FirstOrDefaultAsync(t => t.Token == token && t.DateTimeValid > DateTime.UtcNow);

            if (tokenValido == null)
            {
                return Unauthorized(new { message = "Token inválido o expirado." });
            }

            List<Producto> productos = await _context.Productos
                .Include(p => p.Categoria)
                .Take(cantidad)
                .ToListAsync();

            List<ProductoDto> pdto = new List<ProductoDto>();

            foreach (var producto in productos)
            {
                ProductoDto pd = new ProductoDto();
                CategoriaDto categoria = new CategoriaDto();
                pd.Nombre = producto.Nombre;
                pd.FechaCreacion = producto.FechaCreacion;
                pd.FechaModificacion = producto.FechaModificacion;
                pd.Id = producto.Id;
                pd.Descripción = producto.Descripción;
                categoria.Nombre = producto.Categoria.Nombre;
                categoria.Id = producto.Categoria.Id;
                pd.Categoria = categoria;
                pdto.Add(pd);
            }

            return Ok(pdto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(Guid id)
        {
            var producto = await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null) return NotFound("Producto no encontrado.");

            ProductoDto pd = new ProductoDto();
            CategoriaDto categoria = new CategoriaDto();
            pd.Nombre = producto.Nombre;
            pd.FechaCreacion = producto.FechaCreacion;
            pd.FechaModificacion = producto.FechaModificacion;
            pd.Id = producto.Id;
            pd.Descripción = producto.Descripción;
            categoria.Nombre = producto.Categoria.Nombre;
            categoria.Id = producto.Categoria.Id;
            pd.Categoria = categoria;

            return Ok(pd);
        }


    }
}
