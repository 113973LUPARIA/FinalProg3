using AutoMapper;
using FinalGestionInventario.DTOs;
using FinalGestionInventario.Models;

namespace FinalGestionInventario.Configuration.AutoMapper
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Producto, ProductoRequestDto>().ReverseMap();
            CreateMap<Cliente, ClientePostDto>().ReverseMap();
        }
    }
}
