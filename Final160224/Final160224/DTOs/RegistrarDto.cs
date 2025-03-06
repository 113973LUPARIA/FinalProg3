using Final160224.Models;

namespace Final160224.DTOs
{
    public class RegistrarDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
