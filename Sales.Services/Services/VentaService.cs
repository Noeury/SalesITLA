using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Venta;
using Sales.AppServices.Interfaces;

namespace Sales.AppServices.Services
{
    public class VentaService : IVentaService
    {
        public Task<ServiceResult> GetVentaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetVentas()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Save(AddVentaDto negocio)
        {
            throw new NotImplementedException();
        }
    }
}
