using Microsoft.Extensions.DependencyInjection;
using Sales.AppServices.Interfaces;
using Sales.AppServices.Services;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;

namespace Sales.IOC.ProductoDependency
{
    public static class ProductoModuleDependency
    {
        public static void AddProductoModuleDependency(this IServiceCollection service)
        {
            service.AddScoped<IProductoDb, ProductoDb>();
            service.AddTransient<IProductoService, ProductoService>();
        }
    }
}
