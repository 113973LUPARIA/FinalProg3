using ApiFinalMarzo.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinalMarzo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;
        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }
    }
}
