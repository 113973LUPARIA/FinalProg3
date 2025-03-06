using AutoMapper;
using PracticaFinal030225.DTOs;
using PracticaFinal030225.Models;
using PracticaFinal030225.Repositorios;

namespace PracticaFinal030225.Servicios.Implementacion
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public ProductoService(IProductoRepository productoRepository, IMapper mapper) {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> ProcutoByCantidad(int x)
        {
            var pruductoList = await _productoRepository.ProductoCantidad(x);
            if (pruductoList == null) return null;
            List<ProductoDto> lProductoDtos = new List<ProductoDto>();
            foreach (var p in pruductoList)
            {
                CategoriaDto categoriaDto = _mapper.Map<CategoriaDto>(p.Categoria);
                ProductoDto productoDto = _mapper.Map<ProductoDto>(p);
                productoDto.Categoria = categoriaDto;
                lProductoDtos.Add(productoDto);
            }
            return lProductoDtos;
        }

        public async Task<ProductoDto> ProductoById(Guid id)
        {
            var producto = await _productoRepository.ProductoById(id);
            if (producto == null)
            {
                return null;
            }
            CategoriaDto categoriaDto = _mapper.Map<CategoriaDto>(producto.Categoria);
            ProductoDto productoDto = _mapper.Map<ProductoDto>(producto);
            productoDto.Categoria = categoriaDto;
            return productoDto;
        }
    }
}
