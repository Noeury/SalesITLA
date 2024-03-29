using Sales.API.Models.Producto;
using Sales.AppServices.Dtos.Producto;
using Sales.AppServices.Models;

namespace Sales.API.Extensions
{
    public static class ProductoExtension
    {

        public static AddProductoDto ConverFromProductoToAddProductoDto(this ProductoCreateModel model)
        {
            return new AddProductoDto()
            {
                CodigoBarra = model.CodigoBarra,
                IdCategoria = model.IdCategoria,
                Descripcion = model.Descripcion,
                FechaRegistro = model.FechaRegistro,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                Marca = model.Marca,
                NombreImagen = model.NombreImagen,
                Precio = model.Precio,
                Stock = model.Stock,
                UrlImagen = model.UrlImagen,
            };
        }

        public static UpdateProductoDto ConverFromProductoToUpdateDto(this ProductoUpdateModel model)
        {
            return new UpdateProductoDto()
            {
                Id = model.ProductoId,
                CodigoBarra = model.CodigoBarra,
                IdCategoria = model.IdCategoria,
                Descripcion = model.Descripcion,
                FechaMod = model.FechaMod,
                IdUsuarioMod = model.IdUsuarioMod,
                Marca = model.Marca,
                NombreImagen = model.NombreImagen,
                Precio = model.Precio,
                Stock = model.Stock,
                UrlImagen = model.UrlImagen,
            };
        }

    }
}
