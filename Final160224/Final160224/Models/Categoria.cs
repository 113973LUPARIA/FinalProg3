namespace Final160224.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
