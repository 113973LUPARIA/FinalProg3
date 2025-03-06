using PracticaFinal030225.Models;

namespace PracticaFinal030225.Repositorios
{
    public interface IUsuarioRepository
    {
        Task<Usuario> UsuarioByEmail(string email);
        Task<Usuario> LogIn(string email, string password);
        Task<Usuario> UsuarioById(Guid id);
        Task<Usuario> UsuarioByLogin(string email, string password);
        Task<bool> SaveToken(TokenXUsuario token);
        Task<Rol> DefaultRol();
        Task<bool> SaveUser(Usuario usuarioNew);
    }
}
