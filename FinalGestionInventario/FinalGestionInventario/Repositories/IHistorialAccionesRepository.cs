using FinalGestionInventario.Models;

namespace FinalGestionInventario.Repositories
{
    public interface IHistorialAccionesRepository
    {
        Task<List<HistorialAccione>> GetHistorialAcciones(string usuarioId, string entidadAfectada);
    }
}
