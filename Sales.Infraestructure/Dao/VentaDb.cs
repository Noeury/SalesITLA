using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;
using Sales.Infraestructure.Models.Venta;

namespace Sales.Infraestructure.Dao
{
    public class VentaDb : DaoBase<Venta>, IVentaDb
    {
        private readonly SalesContext context;
        private readonly ILogger<VentaDb> logger;
        private readonly IConfiguration configuration;


        public VentaDb(SalesContext context, ILogger<VentaDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override DataResult Save(Venta entity)
        {
            return base.Save(entity);
        }

        public async Task<VentaBySellerModel> totalDeVentaBySellerId(int sellerId)
        {
            VentaBySellerModel ventas = new VentaBySellerModel();
            try
            {
                ventas = (from ven in this.context.Venta
                          join user in this.context.Usuario on ven.IdUsuario equals user.Id
                          where user.Id == sellerId
                          group ven by new { user.Id, user.Nombre } into groupedSales
                          select new VentaBySellerModel()
                          {
                              Seller = groupedSales.Key.Nombre,
                              SellerId = groupedSales.Key.Id,
                              TotalVentas = groupedSales.Sum(ven => ven.Total)
                          }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error cargando el total de venta.", ex.ToString());

                throw;
            }

            return ventas;
        }
    }
}
