using Sales.Web.Models.Results;
using Sales.Web.Models.Venta;

namespace Sales.Web.Contracts
{
    public interface IVentaService
    {
        Task<GetEntityResult<List<VentaResponseModel>>> GetVentas();

        Task<GetEntityResult<VentaResponseModel>> GetTotalVetaBySellerId(SearchTotalVentaBySellerId sellerI);
        Task<ServiceResult> CreateVenta(VentaCreateModel venta);
    }
}

