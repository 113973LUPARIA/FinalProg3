using FinalGestionInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalGestionInventario.Repositories.Impl
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly InventarioTiendaElectronicaContext _context;
        public ProductoRepository(InventarioTiendaElectronicaContext context) {
            _context = context;
        }
        public async Task<List<Producto>> GetProductos()
        {
            return await _context.Productos.Include(x => x.Categoria).ToListAsync();
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _context.Productos.Include(x => x.Categoria).FirstOrDefaultAsync(y=> y.Id == id);
        }

        public async Task<bool> SaveProducto(Producto p)
        {
            bool a = false;
            try
            {
                await _context.Productos.AddAsync(p);   
                await _context.SaveChangesAsync();
                a = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                a = false;
            }
            return a;
        }

        public async Task<bool> UpdateProducto(Producto p)
        {
            bool a = false;
            try
            {
                _context.Productos.Update(p);
                await _context.SaveChangesAsync();
                a = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                a = false;
            }
            return a;
        }

        public async Task<List<Producto>> GetProductoByCatId(int catId)
        {
            return await _context.Productos.Include(x => x.Categoria).Where(x => x.CategoriaId == catId).ToListAsync();
        }
    }
}
