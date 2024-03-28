using Microsoft.EntityFrameworkCore;
using Sales.AppServices.Interfaces;
using Sales.AppServices.Services;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;
using Sales.IOC.NegocioDependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding DbContext
builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));

//Addind Negocio Dependency
builder.Services.AddNegocioModuleDependency();


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
