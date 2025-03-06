using PracticaFinal030225.Models;

namespace PracticaFinal030225.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Guid RolId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public RolDto Rol { get; set; }
    }
}
