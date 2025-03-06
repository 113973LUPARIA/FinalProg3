using PracticaFinal030225.Models;
using PracticaFinal030225.Repositorios;

namespace PracticaFinal030225.Servicios.Implementacion
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        public TokenService(ITokenRepository tokenRepository) {
            _tokenRepository = tokenRepository;
        }
        public async Task<TokenXUsuario> ValidarToken(string token)
        {
            return await _tokenRepository.ValidarToken(token);
        }
    }
}
