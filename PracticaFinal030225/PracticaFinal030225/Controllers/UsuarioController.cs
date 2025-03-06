using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal030225.DTOs;
using PracticaFinal030225.Servicios;

namespace PracticaFinal030225.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _userService;
        public UsuarioController(IUsuarioService userService)
        {
            _userService = userService;
        }

        [HttpGet("/UserById")]
        public async Task<ActionResult<UsuarioDto>> GetUserById(Guid id)
        {
            var usuario = await _userService.UsuarioById(id);
            if (usuario == null)
            {
                return BadRequest("Usuario no existente");
            }
            return Ok(usuario);
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] RegistrarDto registrarDto)
        {
            if (!await _userService.Registrar(registrarDto)) {
                return BadRequest("Usuario ya existente");
            }
            return Ok("Usuario Registrado con Exito!");
        }

        [HttpPost("/Login")]
        public async Task<ActionResult<string>> LoginUsuario([FromBody] LoginDto loginDto)
        {
            var token = await _userService.LogIn(loginDto);
            if (token == null)
            {
                return Unauthorized("Email o Password Incorrectos");
            }
            return Ok(token);
        }
    }
}
