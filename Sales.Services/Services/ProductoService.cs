using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Producto;
using Sales.AppServices.Interfaces;

namespace Sales.AppServices.Services
{
    public class ProductoService : IProductoService
    {
        public Task<ServiceResult> GetProductoByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetProductos()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Save(AddProductoDto negocio)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Update(UpdateProductoDto negocio)
        {
            throw new NotImplementedException();
        }
    }
}
