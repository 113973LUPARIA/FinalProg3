using FinalGestionInventario.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FinalGestionInventario.Repositories.Impl
{
    public class HistorialAccionesRepository:IHistorialAccionesRepository
    {
        private readonly InventarioTiendaElectronicaContext _context;

        public HistorialAccionesRepository(InventarioTiendaElectronicaContext context)
        {
            _context = context;
        }

        public async Task<List<HistorialAccione>> GetHistorialAcciones(string usuarioId, string entidadAfectada)
        {
            if (usuarioId == null && entidadAfectada == null)
            {
                return await _context.HistorialAcciones.ToListAsync();
            }

            if (usuarioId == null)
            {
                return await _context.HistorialAcciones.Where(x=> x.EntidadAfectada == entidadAfectada).ToListAsync();
            }

            int a = int.Parse(usuarioId);
            if (entidadAfectada == null)
            {
                
                return await _context.HistorialAcciones.Where(x=> x.UsuarioId == a).ToListAsync();
            }

            return await _context.HistorialAcciones.Where(x => x.EntidadAfectada == entidadAfectada && x.UsuarioId == a).ToListAsync();
        }
    }
}
