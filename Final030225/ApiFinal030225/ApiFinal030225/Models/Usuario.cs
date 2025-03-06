namespace ApiFinal030225.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Guid RolId { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Rol Rol { get; set; }
    }
}
