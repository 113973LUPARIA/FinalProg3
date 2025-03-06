
using PracticaFinal030225.Models;

namespace PracticaFinal030225.Repositorios
{
    public interface ITokenRepository
    {
        Task<TokenXUsuario> ValidarToken(string token);
    }
}
