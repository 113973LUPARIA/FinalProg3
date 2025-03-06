using GestionInventario.Models;
using GestionInventario.Repositories;
using GestionInventario.Repositories.Impl;
using GestionInventario.Servicios;
using GestionInventario.Servicios.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventarioTiendaElectronicaContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<IProductoService, ProductoImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
options.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
