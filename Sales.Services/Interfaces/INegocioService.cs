

using Sales.AppServices.Core;
using Sales.AppServices.Dtos;
using Sales.Infraestructure.Models;

namespace Sales.AppServices.Interfaces
{
    public interface INegocioService
    {
        public Task<ServiceResult> GetNegocios();

        public Task<ServiceResult> Save(AddNegocioDto negocio);

        public Task<ServiceResult> Update(UpdateNegocioDto negocio);
    }
}
