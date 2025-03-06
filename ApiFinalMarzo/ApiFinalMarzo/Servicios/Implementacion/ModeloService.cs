using ApiFinalMarzo.Models;
using ApiFinalMarzo.Repositorios;
using AutoMapper;

namespace ApiFinalMarzo.Servicios.Implementacion
{
    public class ModeloService:IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ModeloService(IModeloRepository modeloRepository, IMapper mapper, HttpClient httpClient)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
            _httpClient = httpClient;
        }
    }
}
