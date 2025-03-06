using FinalGestionInventario.Models;

namespace FinalGestionInventario.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual CategoriaDto Categoria { get; set; } = null!;
    }
}
