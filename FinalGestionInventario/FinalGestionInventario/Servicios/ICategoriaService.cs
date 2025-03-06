using FinalGestionInventario.Models;

namespace FinalGestionInventario.Servicios
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetCategorias();
    }
}
