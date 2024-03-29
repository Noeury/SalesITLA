using Microsoft.EntityFrameworkCore;
using Sales.AppServices.Interfaces;
using Sales.AppServices.Services;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;
using Sales.IOC.NegocioDependency;
using Sales.IOC.ProductoDependency;
using Sales.IOC.VentaDependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding DbContext
builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));

//Adding Negocio Dependency
builder.Services.AddNegocioModuleDependency();

//Adding Producto Dependency
builder.Services.AddProductoModuleDependency();

//Adding Venta Dependency
builder.Services.AddVentaModuleDependency();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
