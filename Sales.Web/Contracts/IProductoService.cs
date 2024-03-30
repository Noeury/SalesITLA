using Sales.Web.Models.Producto;
using Sales.Web.Models.Results;

namespace Sales.Web.Contracts
{
    public interface IProductoService
    {
        Task<GetEntityResult<List<ProductoResponseModel>>> GetProductos();

        Task<GetEntityResult<ProductoResponseModel>> GetProductoByDescripcion(ProductoSearchModel producto);
        Task<ServiceResult> CreateProducto(ProductoCreateModel producto);
        Task<ServiceResult> UpdateProducto(ProductoUpdateModel producto);
    }
}
