using ApiRecetas.DTOs;
using ApiRecetas.Models;
using AutoMapper;

namespace ApiRecetas.Configs.AutoMapper
{
    public class AutoMapper: Profile
    {
        public AutoMapper() { 
            CreateMap<Receta, RecetaDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Ingrediente, IngredienteDto>().ReverseMap();
        }
    }
}
