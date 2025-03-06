using ApiTemperaturas.Models;

namespace ApiTemperaturas.Servicios
{
    public interface ITempService
    {
        Task<bool> SaveTemperatura(TempDto temperatura);
    }
}
