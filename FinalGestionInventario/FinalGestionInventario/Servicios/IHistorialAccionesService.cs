

using FinalGestionInventario.Models;

namespace FinalGestionInventario.Servicios
{
    public interface IHistorialAccionesService
    {
        Task<List<HistorialAccione>> GetHistorial(string usuarioId, string entidadAfectada);
    }
}
