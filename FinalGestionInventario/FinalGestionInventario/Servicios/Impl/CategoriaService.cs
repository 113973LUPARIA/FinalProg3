using FinalGestionInventario.Models;
using FinalGestionInventario.Repositories;

namespace FinalGestionInventario.Servicios.Impl
{
    public class CategoriaService:ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await _categoriaRepository.GetAll();
        }
    }
}
