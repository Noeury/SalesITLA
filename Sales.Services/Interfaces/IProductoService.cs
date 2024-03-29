using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Producto;

namespace Sales.AppServices.Interfaces
{
    public interface IProductoService
    {
        public Task<ServiceResult> GetProductos();
        public Task<ServiceResult> GetProductoByName(string name);
        public Task<ServiceResult> Save(AddProductoDto negocio);
        public Task<ServiceResult> Update(UpdateProductoDto negocio);
    }
}
