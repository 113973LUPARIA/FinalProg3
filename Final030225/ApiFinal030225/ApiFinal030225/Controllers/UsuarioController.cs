using ApiFinal030225.DTOs;
using ApiFinal030225.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFinal030225.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public UsuarioController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpPost("/Login")]
        public async Task<ActionResult<LoginDto>> Login([FromBody]LoginDto login)
        {
            var usuario = await _context.Usuarios.Include(x=> x.Rol).FirstOrDefaultAsync(x=> x.Email == login.Email && x.Password == login.Password);
            if (usuario == null || usuario.Rol.Nombre != "Administrador") 
            {
                return BadRequest("Email o Password incorrecto, o no es Admin");
            }
            return Ok(login);
        }
    }
}
