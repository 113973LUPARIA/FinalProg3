using Microsoft.EntityFrameworkCore;

namespace PracticaFinal030225.Models
{
    public class PracticaDbContext:DbContext
    {
        public PracticaDbContext(DbContextOptions<PracticaDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TokenXUsuario> TokenXUsuarios { get;set; }
    }
}
