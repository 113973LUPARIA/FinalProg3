using Microsoft.EntityFrameworkCore;

namespace FinalCodeFirst.Models
{
    public class Tipo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Sucursal> Sucursales { get; set; }
    }
}
