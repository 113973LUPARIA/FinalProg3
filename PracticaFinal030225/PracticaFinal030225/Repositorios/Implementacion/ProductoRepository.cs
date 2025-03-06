using Microsoft.EntityFrameworkCore;
using PracticaFinal030225.Models;

namespace PracticaFinal030225.Repositorios.Implementacion
{
    public class ProductoRepository:IProductoRepository
    {
        private readonly PracticaDbContext _context;
        public ProductoRepository(PracticaDbContext context) {
            _context = context;
        }

        public async Task<Producto> ProductoById(Guid id)
        {
            return await _context.Productos.Include(x => x.Categoria).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Producto>> ProductoCantidad(int cantidad)
        {
            return await _context.Productos.Include(x => x.Categoria).Take(cantidad).ToListAsync();
        }
    }
}
