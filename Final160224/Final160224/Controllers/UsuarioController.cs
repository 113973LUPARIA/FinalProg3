using Final160224.DTOs;
using Final160224.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final160224.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public UsuarioController(ApiDbContext apiDbContext)
        {
            _context = apiDbContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(Guid id)
        {
            var usuario = await _context.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null) return NotFound("Usuario no encontrado.");
            return Ok(usuario);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (usuario == null || usuario.Password != loginDto.Password) return Unauthorized("Credenciales inválidas.");

            // Generar token
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            var tokenValido = new TokenXUsuario
            {
                Id = Guid.NewGuid(),
                Token = token,
                DateTimeValid = DateTime.UtcNow.AddMinutes(15),
                UsuarioId = usuario.Id
            };

            // Eliminar tokens anteriores
            _context.Tokens.RemoveRange(_context.Tokens.Where(t => t.UsuarioId == usuario.Id));
            await _context.Tokens.AddAsync(tokenValido);
            await _context.SaveChangesAsync();

            return Ok(token.ToString());
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrarDto dto)
        {
            // Validar que el email no esté ya registrado
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest(new { message = "El correo electrónico ya está registrado." });
            }

            var rol = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == "Usuario");
            if (rol == null)
            {
                throw new Exception("El rol por defecto no está configurado.");
            }

            // Crear el nuevo usuario
            var nuevoUsuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                Password = dto.Password,
                FechaNacimiento = dto.FechaNacimiento,
                RolId = rol.Id,
                Activo = true,
                FechaAlta = DateTime.UtcNow,
                FechaModificacion = null
            };

            // Guardar el usuario en la base de datos
            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuario registrado con éxito." });
        }
    }
}
