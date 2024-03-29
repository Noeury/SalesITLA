using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models.Producto;

namespace Sales.Infraestructure.Interfaces
{
    public interface IProductoDb : IDaoBase<Producto>
    {

        public List<ProductByCategoryModel> GetProductosPorCategoria(int categoriaId);


    }
}
