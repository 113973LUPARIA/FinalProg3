using FinalGestionInventario.Models;

namespace FinalGestionInventario.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAll();
    }
}
