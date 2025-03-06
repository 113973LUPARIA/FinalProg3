using FinalGestionInventario.DTOs;
using FinalGestionInventario.Models;

namespace FinalGestionInventario.Servicios
{
    public interface IClienteService
    {
        Task<bool> CrearCliente(ClientePostDto c);
        Task<Cliente> GetClienteId(int id);
    }
}
