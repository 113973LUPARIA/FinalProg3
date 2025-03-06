using Microsoft.EntityFrameworkCore;

namespace ApiTemperaturas.Models
{
    public class TemperaturaDbContext:DbContext
    {
        public TemperaturaDbContext(DbContextOptions<TemperaturaDbContext> options) : base(options) { }

        public DbSet<Temperatura> Temperaturas { get; set; }
    }
}
