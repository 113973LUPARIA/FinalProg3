﻿namespace ApiRecetas.DTOs
{
    public class IngredienteDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
    }
}
