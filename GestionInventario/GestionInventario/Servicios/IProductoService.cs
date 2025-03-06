using GestionInventario.Models;

namespace GestionInventario.Servicios
{
    public interface IProductoService
    {
        Task<List<Producto>> GetProductos();
        Task<List<Categorium>> GetCategorias();
    }
}
