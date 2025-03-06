using AutoMapper;
using PracticaFinal030225.DTOs;
using PracticaFinal030225.Models;
using PracticaFinal030225.Repositorios;

namespace PracticaFinal030225.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<string> LogIn(LoginDto loginDto)
        {
            var usuario = await _usuarioRepository.UsuarioByLogin(loginDto.Email, loginDto.Password);
            if (usuario == null) {
                return null;
            }
            TokenXUsuario token = new TokenXUsuario();
            token.Id = Guid.NewGuid();
            token.Token = tokenGenerator();
            token.UserId = usuario.Id;
            token.DateTimeValid = DateTime.UtcNow.AddMinutes(15);
            token.Usuario = usuario;
            if(await _usuarioRepository.SaveToken(token)) return token.Token.ToString();
            return null;

        }

        public async Task<bool> Registrar(RegistrarDto registrarDto)
        {
            var usuario = await _usuarioRepository.UsuarioByEmail(registrarDto.Email);
            if (usuario != null) { return false; }
            Usuario usuarioNew = new Usuario();
            Rol rol = await _usuarioRepository.DefaultRol();
            usuarioNew.Id = Guid.NewGuid();
            usuarioNew.RolId = rol.Id;
            usuarioNew.Email = registrarDto.Email;
            usuarioNew.Password = registrarDto.Password;
            usuarioNew.FechaNacimiento = registrarDto.FechaNacimiento;
            usuarioNew.Nombre = registrarDto.Nombre;
            usuarioNew.Apellido = registrarDto.Apellido;
            usuarioNew.Activo = true;
            usuarioNew.FechaAlta = DateTime.Now.AddSeconds(1);
            usuarioNew.FechaModificacion = null;
            usuarioNew.Rol = rol;
            if (await _usuarioRepository.SaveUser(usuarioNew)) { return true; }
            return false;
        }

        public async Task<UsuarioDto> UsuarioById(Guid id)
        {
            var usuario = await _usuarioRepository.UsuarioById(id);
            if(usuario == null)
            {
                return null;
            }
            RolDto rolDto = _mapper.Map<RolDto>(usuario.Rol);
            UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            usuarioDto.Rol = rolDto;
            return usuarioDto;
        }

        private string tokenGenerator()
        {
            return (Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() +
            Guid.NewGuid().ToString() 
           ).Substring(0, 400);
        }
    }
}
