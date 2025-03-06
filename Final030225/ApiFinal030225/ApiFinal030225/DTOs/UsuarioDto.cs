using ApiFinal030225.Models;

namespace ApiFinal030225.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Guid RolId { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public RolDto Rol { get; set; }
    }
}
