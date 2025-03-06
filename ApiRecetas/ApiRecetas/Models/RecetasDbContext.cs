using Microsoft.EntityFrameworkCore;
namespace ApiRecetas.Models
{
    public class RecetasDbContext:DbContext
    {
        public RecetasDbContext(DbContextOptions<RecetasDbContext> options) : base(options) { }

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Receta> Recetas { get; set; }
    }
}
