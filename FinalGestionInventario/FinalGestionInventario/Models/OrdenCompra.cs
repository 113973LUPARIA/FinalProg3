using System;
using System.Collections.Generic;

namespace FinalGestionInventario.Models;

public partial class OrdenCompra
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? FechaEntrega { get; set; }
}
