namespace PracticaFinal030225.Models
{
    public class Producto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Categoria Categoria { get; set; }
    }
}
