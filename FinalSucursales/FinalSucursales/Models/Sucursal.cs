using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalSucursales.Models
{
    public class Sucursal
    {
        [Key]
        public Guid Id { get; set; }

        public string Nombre { get; set; }
        public string IdCiudad { get; set; }

        // Propiedad de clave foránea para Provincia
        public Guid IdProvincia { get; set; }

        [ForeignKey("IdProvincia")]
        public Provincia Provincia { get; set; } // Navegación

        // Propiedad de clave foránea para Tipo
        public Guid IdTipo { get; set; }

        [ForeignKey("IdTipo")]
        public Tipo Tipo { get; set; } // Navegación

        public string Telefono { get; set; }
        public string NombreTitular { get; set; }
        public string ApellidoTitular { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
