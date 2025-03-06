
using Microsoft.EntityFrameworkCore;
using PracticaFinal030225.Models;

namespace PracticaFinal030225.Repositorios.Implementacion
{
    public class TokenRepository : ITokenRepository
    {
        private readonly PracticaDbContext _context;
        public TokenRepository(PracticaDbContext context)
        {
            _context = context;
        }
        public async Task<TokenXUsuario> ValidarToken(string token)
        {
            return await _context.TokenXUsuarios.FirstOrDefaultAsync(t => t.Token == token && t.DateTimeValid > DateTime.UtcNow);
        }
    }
}
