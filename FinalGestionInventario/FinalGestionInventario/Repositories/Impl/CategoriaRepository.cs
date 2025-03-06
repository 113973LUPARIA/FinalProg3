using FinalGestionInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalGestionInventario.Repositories.Impl
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly InventarioTiendaElectronicaContext _context;
        public CategoriaRepository(InventarioTiendaElectronicaContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
