using Microsoft.EntityFrameworkCore;

namespace ApiFinalMarzo.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
