using ApiFinalMarzo.Models;

namespace ApiFinalMarzo.Repositorios.Implementacion
{
    public class ModeloRepository:IModeloRepository
    {
        private readonly AppDbContext _context;
        public ModeloRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
