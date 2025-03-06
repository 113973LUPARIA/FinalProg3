using GestionInventario.Models;

namespace GestionInventario.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetProductos();
        Task<List<Categorium>> GetCategorias();
    }
}
