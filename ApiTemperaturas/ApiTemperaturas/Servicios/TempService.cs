using ApiTemperaturas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTemperaturas.Servicios
{
    public class TempService : ITempService
    {
        private readonly TemperaturaDbContext _context;
        public TempService(TemperaturaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveTemperatura(TempDto temperatura)
        {
            Temperatura temp = new Temperatura();
            temp.Descripcion = temperatura.Descripcion;
            temp.SenTermica = temperatura.SenTermica;
            temp.Ciudad = temperatura.Ciudad;
            temp.Temp = temperatura.Temp;
            temp.Cielo = temperatura.Cielo;

            //var temp = await _context.Temperaturas.FirstOrDefaultAsync(x=>x.FechaMedici);
            bool result = false;
            try
            {
                await _context.Temperaturas.AddAsync(temp);
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
