using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models.Venta;

namespace Sales.Infraestructure.Interfaces
{
    public interface IVentaDb : IDaoBase<Venta>
    {

        public Task<VentaBySellerModel> totalDeVentaBySellerId(int sellerId);

    }
}
