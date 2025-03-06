using GestionInventario.Models;
using GestionInventario.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Servicios.Impl
{
    public class ProductoImpl : IProductoService
    {
        private readonly IProductoRepository _repository;
        public ProductoImpl(IProductoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Producto>> GetProductos()
        {
            return await _repository.GetProductos();

        }

        public async Task<List<Categorium>> GetCategorias()
        {
            return await _repository.GetCategorias();

        }
    }
}
