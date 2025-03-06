using Microsoft.EntityFrameworkCore;
using PracticaFinal030225.Models;

namespace PracticaFinal030225.Repositorios.Implementacion
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PracticaDbContext _context;
        public UsuarioRepository(PracticaDbContext context)
        {
            _context = context;
        }

        public Task<Usuario> LogIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> UsuarioByEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> SaveToken(TokenXUsuario token)
        {
            try
            {
                var tokenExistente = await _context.TokenXUsuarios.FirstOrDefaultAsync(x => x.UserId == token.UserId);
                if (tokenExistente != null) _context.TokenXUsuarios.Remove(tokenExistente);
                await _context.TokenXUsuarios.AddAsync(token);
                await _context.SaveChangesAsync();
                return true;
                
            } catch 
            {
                return false;
            }
        }

        public async Task<Usuario> UsuarioById(Guid id)
        {
            return await _context.Usuarios.Include(x => x.Rol).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> UsuarioByLogin(string email, string password)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x=> x.Email == email && x.Password == password);
            
        }

        public async Task<Rol> DefaultRol()
        {
            return await _context.Roles.FirstOrDefaultAsync(x=> x.Nombre == "User");
        }

        public async Task<bool> SaveUser(Usuario usuarioNew)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuarioNew);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
