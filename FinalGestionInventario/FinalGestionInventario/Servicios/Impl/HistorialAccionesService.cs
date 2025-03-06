using FinalGestionInventario.Models;
using FinalGestionInventario.Repositories;

namespace FinalGestionInventario.Servicios.Impl
{
    public class HistorialAccionesService:IHistorialAccionesService
    {
        private readonly IHistorialAccionesRepository _historialAccionesRepository;

        public HistorialAccionesService(IHistorialAccionesRepository historialAccionesRepository)
        {
            _historialAccionesRepository = historialAccionesRepository;
        }

        public Task<List<HistorialAccione>> GetHistorial(string usuarioId, string entidadAfectada)
        {
            return _historialAccionesRepository.GetHistorialAcciones(usuarioId, entidadAfectada);
        }
    }
}
