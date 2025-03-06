namespace ApiRecetas.DTOs
{
    public class RecetaDtoRequest
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int TiempoReparacion { get; set; }
        public Guid CategoriaId { get; set; }

        public ICollection<IngredienteDto>? Ingredientes { get; set; }
    }
}
