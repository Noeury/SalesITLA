

using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Negocio;

namespace Sales.AppServices.Interfaces
{
    public interface INegocioService
    {
        public Task<ServiceResult> GetNegocios();

        public Task<ServiceResult> GetNeocioByName(string name);
        public Task<ServiceResult> Save(AddNegocioDto negocio);

        public Task<ServiceResult> Update(UpdateNegocioDto negocio);
    }
}
