using AutoMapper;
using FinalGestionInventario.DTOs;
using FinalGestionInventario.Models;
using FinalGestionInventario.Repositories;

namespace FinalGestionInventario.Servicios.Impl
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<bool> CrearCliente(ClientePostDto c)
        {
             
            Cliente cliente = _mapper.Map<Cliente>(c);
            if (await _clienteRepository.GetClienteEmailAsync(cliente) != null)
            {
                return false;
            }

            cliente.FechaRegistro = DateTime.Now;
            cliente.Estado = true;

            return await _clienteRepository.SaveCliente(cliente);
        }

        public async Task<Cliente> GetClienteId(int id)
        {
            return await _clienteRepository.GetClienteIdAsync(id);
        }
    }
}
