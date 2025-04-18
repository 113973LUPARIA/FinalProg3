﻿using System;
using System.Collections.Generic;

namespace FinalGestionInventario.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool Estado { get; set; }
}
