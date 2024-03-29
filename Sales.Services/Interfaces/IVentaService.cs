using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Venta;

namespace Sales.AppServices.Interfaces
{
    public interface IVentaService
    {
        public Task<ServiceResult> GetVentas();
        public Task<ServiceResult> GetVentaById(int id);
        public Task<ServiceResult> Save(AddVentaDto negocio);

    }
}
