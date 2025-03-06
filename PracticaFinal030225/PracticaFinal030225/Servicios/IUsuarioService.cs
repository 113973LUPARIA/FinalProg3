using PracticaFinal030225.DTOs;

namespace PracticaFinal030225.Servicios
{
    public interface IUsuarioService
    {
        Task<bool> Registrar(RegistrarDto registrarDto);
        Task<string> LogIn(LoginDto loginDto);
        Task<UsuarioDto> UsuarioById(Guid id);
    }
}
