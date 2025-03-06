namespace Final160224.Models
{
    public class TokenXUsuario
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime DateTimeValid { get; set; }
        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
