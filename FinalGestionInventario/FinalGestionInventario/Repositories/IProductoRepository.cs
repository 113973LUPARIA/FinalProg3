using FinalGestionInventario.Models;

namespace FinalGestionInventario.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetProductos();
        Task<bool> SaveProducto(Producto p);
        Task<bool> UpdateProducto(Producto p);
        Task<Producto> GetProductoById(int id);
        Task<List<Producto>> GetProductoByCatId(int catId);
    }
}
