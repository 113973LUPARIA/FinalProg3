using System;
using System.Collections.Generic;

namespace FinalGestionInventario.Models;

public partial class HistorialAccione
{
    public int Id { get; set; }

    public string Accion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int UsuarioId { get; set; }

    public string? Descripcion { get; set; }

    public string EntidadAfectada { get; set; } = null!;
}
