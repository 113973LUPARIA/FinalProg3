namespace Final160224.Models
{
    public class Rol
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
