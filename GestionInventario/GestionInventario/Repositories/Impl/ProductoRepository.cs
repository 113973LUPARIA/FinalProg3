using GestionInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Repositories.Impl
{
    public class ProductoRepository:IProductoRepository
    {
        private readonly InventarioTiendaElectronicaContext _context;
        public ProductoRepository(InventarioTiendaElectronicaContext context)
        {
            _context = context;
        }

        public async Task<List<Categorium>> GetCategorias()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await _context.Productos.ToListAsync();

        }
    }
}
