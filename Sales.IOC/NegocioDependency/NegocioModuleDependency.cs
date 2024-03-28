
using Microsoft.Extensions.DependencyInjection;
using Sales.AppServices.Interfaces;
using Sales.AppServices.Services;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;

namespace Sales.IOC.NegocioDependency
{
    public static class NegocioModuleDependency
    {
        public static void AddNegocioModuleDependency(this IServiceCollection service)
        {
            service.AddScoped<INegocioDb, NegocioDb>();
            service.AddTransient<INegocioService, NegocioService>();
        }

    }
}
