using AutoMapper;
using PracticaFinal030225.DTOs;
using PracticaFinal030225.Models;

namespace PracticaFinal030225.Configs.AutoMapper
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
        }
    }
}
