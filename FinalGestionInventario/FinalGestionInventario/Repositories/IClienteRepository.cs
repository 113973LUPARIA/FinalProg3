using FinalGestionInventario.Models;

namespace FinalGestionInventario.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteEmailAsync(Cliente c);
        Task<Cliente> GetClienteIdAsync(int id);
        Task<bool> SaveCliente(Cliente cliente);
    }
}
