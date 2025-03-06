namespace ApiRecetas.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Receta> Recetas { get; set; }
    }
}
