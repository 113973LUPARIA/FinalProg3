using ApiRecetas.Models;

namespace ApiRecetas.DTOs
{
    public class RecetaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Instrucciones { get; set; }
        public string ImagenUrl { get; set; }
        public int TiempoReparacion { get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime FechaCreacion { get; set; }

        public CategoriaDto Categoria { get; set; }

        public ICollection<IngredienteDto> Ingredientes { get; set; }
    }
}
