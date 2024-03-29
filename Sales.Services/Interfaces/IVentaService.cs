using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Venta;

namespace Sales.AppServices.Interfaces
{
    public interface IVentaService
    {
        public Task<ServiceResult> GetTotalVentasBySellerId(int selleId);

        public ServiceResult GetVentas();


        public Task<ServiceResult> Save(AddVentaDto venta);


    }
}
