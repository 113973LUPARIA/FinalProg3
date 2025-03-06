using FinalGestionInventario.Models;
using FinalGestionInventario.Repositories;
using FinalGestionInventario.Repositories.Impl;
using FinalGestionInventario.Servicios;
using FinalGestionInventario.Servicios.Impl;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventarioTiendaElectronicaContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<IProductoService, ProductoService>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IHistorialAccionesRepository, HistorialAccionesRepository>();
builder.Services.AddTransient<IHistorialAccionesService, HistorialAccionesService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options=>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
