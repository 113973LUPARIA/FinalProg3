namespace ApiRecetas.Models
{
    public class Ingrediente
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public Guid RecetaId { get; set; }

        public Receta Receta { get; set; }
    }
}
