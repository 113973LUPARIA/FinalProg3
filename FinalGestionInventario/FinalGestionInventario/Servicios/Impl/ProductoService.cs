using AutoMapper;
using FinalGestionInventario.DTOs;
using FinalGestionInventario.Models;
using FinalGestionInventario.Repositories;

namespace FinalGestionInventario.Servicios.Impl
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public ProductoService(IProductoRepository productoRepository, IMapper mapper) {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public Task<bool> CreateProducto(ProductoRequestDto pdto)
        {
            Producto p = _mapper.Map<Producto>(pdto);
            return _productoRepository.SaveProducto(p);            
        }

        public async Task<List<ProductoDto>> GetProductos()
        {
            List<Producto> l = await _productoRepository.GetProductos();
            List<ProductoDto> ldto = new List<ProductoDto>();
            foreach (Producto p in l)
            {
                ProductoDto productoDto = _mapper.Map<ProductoDto>(p);
                CategoriaDto categoriaDto = _mapper.Map<CategoriaDto>(p.Categoria);
                productoDto.Categoria = categoriaDto;
                ldto.Add(productoDto);
            }
            return ldto;
        }

        public async Task<ProductoDto> GetById(int id)
        {
            Producto p = await _productoRepository.GetProductoById(id);
            ProductoDto pdto = _mapper.Map<ProductoDto>(p);
            CategoriaDto categoriaDto = _mapper.Map<CategoriaDto>(p.Categoria);
            pdto.Categoria = categoriaDto;            
            return pdto;
        }

        public async Task<bool> UpdateProducto(ProductoUpdateDto p)
        {
            
            Producto pr = await _productoRepository.GetProductoById(p.Id);
            if (pr == null)
            {
                return false;
            }
            pr.Nombre = p.Nombre;
            pr.Descripcion = p.Descripcion;
            pr.Precio = p.Precio;
            pr.Stock = p.Stock;
            pr.CategoriaId = p.CategoriaId;
            pr.FechaModificacion = DateTime.Now;
            return await _productoRepository.UpdateProducto(pr);
            

        }

        public async Task<List<ProductoDto>> GetByCatId(int catId)
        {
            List<Producto> l = await _productoRepository.GetProductoByCatId(catId);
            List<ProductoDto> ldto = new List<ProductoDto>();
            foreach (Producto p in l)
            {
                ProductoDto productoDto = _mapper.Map<ProductoDto>(p);
                CategoriaDto categoriaDto = _mapper.Map<CategoriaDto>(p.Categoria);
                productoDto.Categoria = categoriaDto;
                ldto.Add(productoDto);
            }
            return ldto;
        }
    }
}
