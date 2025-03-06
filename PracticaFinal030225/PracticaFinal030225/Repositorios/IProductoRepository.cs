using PracticaFinal030225.Models;

namespace PracticaFinal030225.Repositorios
{
    public interface IProductoRepository
    {
        Task<Producto> ProductoById(Guid id);
        Task<List<Producto>> ProductoCantidad(int x);
    }
}
