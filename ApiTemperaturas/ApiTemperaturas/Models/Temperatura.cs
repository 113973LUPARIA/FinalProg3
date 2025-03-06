namespace ApiTemperaturas.Models
{
    public class Temperatura
    {
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public decimal Temp {  get; set; }
        public decimal SenTermica { get; set; }
        public string Cielo {  get; set; }
        public string Descripcion {  get; set; }
        //public DateTime FechaMedicion {  get; set; }

    }
}
