using FinalGestionInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalGestionInventario.Repositories.Impl
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly InventarioTiendaElectronicaContext _context;
        public ClienteRepository(InventarioTiendaElectronicaContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetClienteEmailAsync(Cliente cliente)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == cliente.Email);
        }

        public async Task<Cliente> GetClienteIdAsync(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> SaveCliente(Cliente cliente)
        {
            bool a = false;
            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
                a = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                a = false;
            }
            return a;
        }
    }
}
