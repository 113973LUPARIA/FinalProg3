namespace ApiTemperaturas.Models
{
    public class TempDto
    {
        public string Ciudad { get; set; }
        public decimal Temp { get; set; }
        public decimal SenTermica { get; set; }
        public string Cielo { get; set; }
        public string Descripcion { get; set; }
    }
}
