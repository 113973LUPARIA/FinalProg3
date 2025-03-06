namespace FinalCodeFirst.Models
{
    public class Provincia
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Sucursal> Sucursales { get; set; }
    }
}
