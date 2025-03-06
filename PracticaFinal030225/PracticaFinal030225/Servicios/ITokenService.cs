using PracticaFinal030225.Models;

namespace PracticaFinal030225.Servicios
{
    public interface ITokenService
    {
        Task<TokenXUsuario> ValidarToken(string token);
    }
}
