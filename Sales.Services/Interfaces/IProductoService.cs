using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Producto;

namespace Sales.AppServices.Interfaces
{
    public interface IProductoService
    {
        public Task<ServiceResult> GetProductos();
        public Task<ServiceResult> GetProductoByDescripcion(string descripcion);
        public Task<ServiceResult> Save(AddProductoDto prducto);
        public Task<ServiceResult> Update(UpdateProductoDto producto);
    }
}
