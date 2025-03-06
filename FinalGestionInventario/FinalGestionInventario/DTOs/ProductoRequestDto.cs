namespace FinalGestionInventario.DTOs
{
    public class ProductoRequestDto
    {

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int CategoriaId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
