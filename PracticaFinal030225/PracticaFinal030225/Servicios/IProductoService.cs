using PracticaFinal030225.DTOs;

namespace PracticaFinal030225.Servicios
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> ProcutoByCantidad(int x);
        Task<ProductoDto> ProductoById(Guid id);
    }
}
