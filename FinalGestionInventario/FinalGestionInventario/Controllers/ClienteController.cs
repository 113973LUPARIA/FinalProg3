using FinalGestionInventario.DTOs;
using FinalGestionInventario.Models;
using FinalGestionInventario.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FinalGestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var c = await _clienteService.GetClienteId(id);
            return Ok(c);
        }
        [HttpPost]
        public async Task<IActionResult> PostCliente(ClientePostDto c) 
        {
            return await _clienteService.CrearCliente(c) ? Ok() : BadRequest("Ya existe un Cliente con ese email");
        }
    }
}
