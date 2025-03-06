namespace FinalGestionInventario.DTOs
{
    public class ClientePostDto
    {
        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }
    }
}
