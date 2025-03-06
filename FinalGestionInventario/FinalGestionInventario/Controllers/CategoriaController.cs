using FinalGestionInventario.DTOs;
using FinalGestionInventario.Models;
using FinalGestionInventario.Servicios;
using FinalGestionInventario.Servicios.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalGestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<List<Categoria>> GetAllProductos()
        {
            return await _categoriaService.GetCategorias();
        }
    }
}
