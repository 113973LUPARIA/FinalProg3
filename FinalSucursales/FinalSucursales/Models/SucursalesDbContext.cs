using Microsoft.EntityFrameworkCore;

namespace FinalSucursales.Models
{
    public class SucursalesDbContext: DbContext
    {
        public SucursalesDbContext(DbContextOptions<SucursalesDbContext> options) : base(options) { }


        DbSet<Tipo> Tipos { get; set; }
        DbSet<Provincia> Provincias { get; set; }
        DbSet<Configuracion> Configuraciones { get; set; }
        DbSet<Sucursal> Sucursales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Sucursal -> Provincia
            modelBuilder.Entity<Sucursal>()
                .HasOne(s => s.Provincia)
                .WithMany(p => p.Sucursales)
                .HasForeignKey(s => s.IdProvincia);

            // Relación Sucursal -> Tipo
            modelBuilder.Entity<Sucursal>()
                .HasOne(s => s.Tipo)
                .WithMany(t => t.Sucursales)
                .HasForeignKey(s => s.IdTipo);

            var cordoba = Guid.NewGuid();
            var buenosAires = Guid.NewGuid();
            var salta = Guid.NewGuid();

            var pequena = Guid.NewGuid();
            var grande = Guid.NewGuid();

            modelBuilder.Entity<Configuracion>().HasData(
            new Configuracion { Id = Guid.NewGuid(), Nombre = "padding-top", Valor = "50px" },
            new Configuracion { Id = Guid.NewGuid(), Nombre = "padding-left", Valor = "100px" });

            modelBuilder.Entity<Provincia>().HasData(
                new Provincia { Id = cordoba, Nombre = "Córdoba" },
                new Provincia { Id = buenosAires, Nombre = "Buenos Aires" },
                new Provincia { Id = salta, Nombre = "Salta" });

            modelBuilder.Entity<Tipo>().HasData(
                new Tipo { Id = pequena, Nombre = "Pequeña" },
                new Tipo { Id = grande, Nombre = "Grande" });


            modelBuilder.Entity<Sucursal>().HasData(
        new Sucursal
        {
            Id = Guid.NewGuid(),
            Nombre = "Sucursal 1",
            IdCiudad = "Córdoba Capital",
            IdTipo = pequena,
            IdProvincia = cordoba,
            Telefono = "351-1234567",
            NombreTitular = "Juan",
            ApellidoTitular = "Pérez",
            FechaAlta = DateTime.Now.AddDays(-10)
        },
        new Sucursal
        {
            Id = Guid.NewGuid(),
            Nombre = "Sucursal 2",
            IdCiudad = "Villa María",
            IdTipo = grande,
            IdProvincia = cordoba,
            Telefono = "353-7654321",
            NombreTitular = "María",
            ApellidoTitular = "Gómez",
            FechaAlta = DateTime.Now.AddDays(-8)
        },
        new Sucursal
        {
            Id = Guid.NewGuid(),
            Nombre = "Sucursal 3",
            IdCiudad = "Río Cuarto",
            IdTipo = pequena,
            IdProvincia = cordoba,
            Telefono = "358-9876543",
            NombreTitular = "Carlos",
            ApellidoTitular = "López",
            FechaAlta = DateTime.Now.AddDays(-6)
        },
        new Sucursal
        {
            Id = Guid.NewGuid(),
            Nombre = "Sucursal 4",
            IdCiudad = "San Francisco",
            IdTipo = grande,
            IdProvincia = cordoba,
            Telefono = "3564-4567890",
            NombreTitular = "Ana",
            ApellidoTitular = "Martínez",
            FechaAlta = DateTime.Now.AddDays(-4)
        },
        new Sucursal
        {
            Id = Guid.NewGuid(),
            Nombre = "Sucursal 5",
            IdCiudad = "Buenos Aires",
            IdTipo = pequena,
            IdProvincia = buenosAires,
            Telefono = "11-12345678",
            NombreTitular = "Lucía",
            ApellidoTitular = "Fernández",
            FechaAlta = DateTime.Now.AddDays(-12)
        },
        new Sucursal
        {
            Id = Guid.NewGuid(),
            Nombre = "Sucursal 6",
            IdCiudad = "Salta Capital",
            IdTipo = grande,
            IdProvincia = salta,
            Telefono = "387-1234567",
            NombreTitular = "Ricardo",
            ApellidoTitular = "Ramírez",
            FechaAlta = DateTime.Now.AddDays(-3)
        },
        new Sucursal
        {
            Id = Guid.NewGuid(),
            Nombre = "Sucursal 7",
            IdCiudad = "Cafayate",
            IdTipo = pequena,
            IdProvincia = salta,
            Telefono = "3868-9876543",
            NombreTitular = "Elena",
            ApellidoTitular = "Torres",
            FechaAlta = DateTime.Now.AddDays(-2)
        });

            base.OnModelCreating(modelBuilder);
        }
    }
}
