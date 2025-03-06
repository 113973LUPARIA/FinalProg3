using FinalGestionInventario.DTOs;
using FinalGestionInventario.Models;


namespace FinalGestionInventario.Servicios
{
    public interface IProductoService
    {
        Task<bool> CreateProducto(ProductoRequestDto p);
        Task<List<ProductoDto>> GetProductos();
        Task<bool> UpdateProducto(ProductoUpdateDto p);
        Task<ProductoDto> GetById(int id);
        Task<List<ProductoDto>> GetByCatId(int catId);
    }
}
