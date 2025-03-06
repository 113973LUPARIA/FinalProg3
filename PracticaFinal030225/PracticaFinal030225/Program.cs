using Microsoft.EntityFrameworkCore;
using PracticaFinal030225.Models;
using PracticaFinal030225.Repositorios;
using PracticaFinal030225.Repositorios.Implementacion;
using PracticaFinal030225.Servicios;
using PracticaFinal030225.Servicios.Implementacion;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PracticaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PracticaConnection")));
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IProductoService, ProductoService>();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
