using PracticaFinal030225.Models;

namespace PracticaFinal030225.DTOs
{
    public class ProductoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public CategoriaDto Categoria { get; set; }
    }
}
