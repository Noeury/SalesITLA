using Sales.Web.Models.Negocio;
using Sales.Web.Models.Results;

namespace Sales.Web.Contracts
{
    public interface INegocioService
    {

        Task<GetEntityResult<List<NegocioResponseModel>>> GetNeocios();

        Task<GetEntityResult<NegocioResponseModel>> GetNeocioByName(NegocioSearchModel negocio);
        Task<ServiceResult> CreateNegocio(NegocioCreateModel negocio);
        Task<ServiceResult> UpdateNeocios(NegocioUpdateModel negocio);

    }
}
