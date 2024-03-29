using Microsoft.Extensions.DependencyInjection;
using Sales.AppServices.Interfaces;
using Sales.AppServices.Services;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;

namespace Sales.IOC.VentaDependency
{
    public static class VentaModuleDependency
    {
        public static void AddVentaModuleDependency(this IServiceCollection service)
        {
            service.AddScoped<IVentaDb, VentaDb>();
            service.AddTransient<IVentaService, VentaService>();
        }
    }
}
