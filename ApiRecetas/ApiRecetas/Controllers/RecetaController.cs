using ApiRecetas.DTOs;
using ApiRecetas.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ApiRecetas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        private readonly RecetasDbContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public RecetaController(RecetasDbContext context, IMapper mapper, HttpClient httpClient)
        {
            _context = context;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        [HttpGet("AllRecetas")]
        public async Task<ActionResult> GetAllRecetas()
        {
            var recetas = await _context.Recetas.Include(x => x.Categoria).ToListAsync();
            if (recetas is null)
            {
                return NotFound();
            }
            List<RecetaDto> recetasDto = new List<RecetaDto>();
            foreach (var rec in recetas) { 
                CategoriaDto c = _mapper.Map<CategoriaDto>(rec.Categoria);
                RecetaDto recDto = _mapper.Map<RecetaDto>(rec);
                var ingredientes = await _context.Ingredientes.Where(x=> x.RecetaId == rec.Id).ToListAsync();
                List<IngredienteDto> lstIng = new List<IngredienteDto>();
                foreach (var ing in ingredientes) { 
                    IngredienteDto i = _mapper.Map<IngredienteDto>(ing);
                    lstIng.Add(i);
                }
                recDto.Categoria = c;
                recDto.Ingredientes = lstIng;
            }
            return Ok(recetas);
        }

        [HttpGet("GetRecetaById")]
        public async Task<ActionResult> GetRecetaById([FromBody] Guid id)
        {
            var recetas = await _context.Recetas.Include(x => x.Ingredientes).FirstOrDefaultAsync(x => x.Id == id);
            if (recetas is null)
            {
                return NotFound();
            }
            List<RecetaDto> recetasDto = new List<RecetaDto>();
            
            CategoriaDto c = _mapper.Map<CategoriaDto>(recetas.Categoria);
            RecetaDto recDto = _mapper.Map<RecetaDto>(recetas);
            var ingredientes = await _context.Ingredientes.Where(x => x.RecetaId == recetas.Id).ToListAsync();
            List<IngredienteDto> lstIng = new List<IngredienteDto>();
            foreach (var ing in ingredientes)
            {
                IngredienteDto i = _mapper.Map<IngredienteDto>(ing);
                lstIng.Add(i);
            }
            recDto.Categoria = c;
            recDto.Ingredientes = lstIng;
            
            return Ok(recetas);
        }
        [HttpPost]
        public async Task<ActionResult> CrearReceta(RecetaDtoRequest receta)
        {
            Receta recetaN = await _context.Recetas.FirstOrDefaultAsync(x=> x.Nombre == receta.Nombre);
            string url = "https://www.themealdb.com/api/json/v1/1/search.php?s=" + receta.Nombre.ToString();
            var response = await _httpClient.GetStringAsync(url);
            
            var mealResponse = JsonSerializer.Deserialize<MealResponse>(response);
            var rsp = true;
            if (mealResponse.meals != null)
            {
                foreach (var item in mealResponse.meals)
                {
                    if (item.strMeal == receta.Nombre)
                    {
                        rsp = false; break;
                    }
                }
            }
            if (recetaN != null || !rsp) {
                return BadRequest("Ya existe una Receta con ese nombre");
            }            
                
            Receta r = new Receta();
            r.Id = Guid.NewGuid();
            r.Nombre = receta.Nombre;
            r.Descripcion = receta.Descripcion;
            r.Instrucciones = mealResponse.meals[0].strInstructions;
            r.ImagenUrl = mealResponse.meals[0].strMealThumb;
            r.TiempoReparacion = receta.TiempoReparacion;
            r.CategoriaId = receta.CategoriaId;
            r.FechaCreacion = DateTime.UtcNow;
            List<Ingrediente> li = new List<Ingrediente>();
            foreach (var i in receta.Ingredientes)
            {
                Ingrediente ingrediente = _mapper.Map<Ingrediente>(i);
                ingrediente.RecetaId = r.Id;
                li.Add(ingrediente);
            }
            r.Ingredientes = li;

            await _context.Recetas.AddAsync(r);
            await _context.SaveChangesAsync();

            
            return Ok(r);

        }
    }
}
