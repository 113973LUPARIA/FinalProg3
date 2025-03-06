using FinalGestionInventario.Models;
using FinalGestionInventario.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalGestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialAccionesController : ControllerBase
    {
        private readonly IHistorialAccionesService _historialAccionesService;

        public HistorialAccionesController(IHistorialAccionesService historialAccionesService)
        {
            _historialAccionesService = historialAccionesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistorialAccione>>> GetHistorialAcciones([FromQuery] string? usuarioId, [FromQuery] string? entidadAfectada)
        {
            var a = await _historialAccionesService.GetHistorial(usuarioId, entidadAfectada);
            if (a == null) 
            {
                return BadRequest();
            }
            return Ok(a);
        }       
    }
}
