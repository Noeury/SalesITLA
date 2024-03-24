

using Sales.AppServices.Core;
using Sales.Infraestructure.Exceptions;

namespace Sales.AppServices
{
    public class NegocioAppService
    {
        public ServiceResult Save()
        {
            ServiceResult result = new ServiceResult();
            try
            {

            }
            catch (NegocioException nex)
            {
                result.Message = nex.Message;
                result.Success = false;
            }

            return result;
        }
    }
}
