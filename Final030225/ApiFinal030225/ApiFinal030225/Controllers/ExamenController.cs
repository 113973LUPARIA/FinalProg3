using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinal030225.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        static HttpClient client = new HttpClient();

        [HttpGet("GetUsuarios")]
        public async Task<string> GetUsuarios()
        {
            return await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
        }

        [HttpGet("GetAlbums")]
        public async Task<string> GetAlbums()
        {
            return await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums");
        }
        [HttpGet("GetFotos")]
        public async Task<string> GetFotos()
        {
            return await client.GetStringAsync("https://jsonplaceholder.typicode.com/photos");
        }
    }
}
