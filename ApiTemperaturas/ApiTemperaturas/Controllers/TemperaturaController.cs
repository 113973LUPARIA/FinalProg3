using ApiTemperaturas.Models;
using ApiTemperaturas.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemperaturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private readonly ITempService _tempService;

        public TemperaturaController(ITempService tempService)
        {
            _tempService = tempService;
        }

        [HttpPost]
        public async Task<ActionResult> GuardarTemp([FromBody] TempDto temperatura) {
            if (temperatura == null) { return BadRequest("no llego bien"); }
            bool t = await _tempService.SaveTemperatura(temperatura);
            if (t)
            {
                return Ok();
            }
            else {
                return BadRequest("algo salio mal");
            }

            }
    }
}
