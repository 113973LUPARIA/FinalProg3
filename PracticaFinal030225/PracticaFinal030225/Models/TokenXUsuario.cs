namespace PracticaFinal030225.Models
{
    public class TokenXUsuario
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime DateTimeValid { get; set; }
        public Guid UserId { get; set; }// Tiene que ser UsuarioId!!!!

        public Usuario Usuario { get; set; }
    }
}
