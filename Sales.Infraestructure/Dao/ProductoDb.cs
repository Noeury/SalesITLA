

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;
using Sales.Infraestructure.Models.Producto;

namespace Sales.Infraestructure.Dao
{
    public class ProductoDb : DaoBase<Producto>, IProductoDb
    {
        private readonly SalesContext context;
        private readonly ILogger<ProductoDb> logger;
        private readonly IConfiguration configuration;


        public ProductoDb(SalesContext context, ILogger<ProductoDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public List<ProductByCategoryModel> GetProductosPorCategoria(int categoriaId)
        {
            List<ProductByCategoryModel> productos = new List<ProductByCategoryModel>();

            try
            {
                productos = (from prod in context.Producto
                             join cat in context.Categoria on prod.IdCategoria equals cat.Id
                             where cat.Id == categoriaId

                             select new ProductByCategoryModel()
                             {
                                 Id = prod.Id,
                                 CodigoBarra = prod.CodigoBarra,
                                 Marca = prod.Marca,
                                 Stock = prod.Stock,
                                 NombreCategoria = cat.Descripcion


                             }
                     ).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error cargando los productos.", ex.ToString());
            }

            return productos;
        }


    }
}
