﻿using Final160224.Models;

namespace Final160224.DTOs
{
    public class ProductoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public CategoriaDto Categoria { get; set; }
    }
}
