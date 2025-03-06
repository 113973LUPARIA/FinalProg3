namespace ApiRecetas.Models
{
    public class Receta
    {
        public Guid Id { get; set; }
        public string Nombre {  get; set; }
        public string Descripcion { get; set; }
        public string Instrucciones { get; set; }
        public string ImagenUrl { get; set; }
        public int TiempoReparacion {  get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Categoria Categoria { get; set; }

        public ICollection<Ingrediente> Ingredientes { get; set; }
    }
}
