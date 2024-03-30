using Microsoft.Extensions.Logging;
using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Producto;
using Sales.AppServices.Interfaces;
using Sales.AppServices.Models;
using Sales.Domain.Entities;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoDb producto;
        private readonly ILogger<ProductoService> logger;

        public ProductoService(IProductoDb producto, ILogger<ProductoService> logger)
        {
            this.producto = producto;
            this.logger = logger;
        }

        public async Task<ServiceResult> GetProductoByDescripcion(string descripcion)
        {
            ServiceResult result = new();

            try
            {
                var query = (from prod in this.producto.GetAll()
                             where prod.Descripcion == descripcion
                             select new Models.ProductoModel()
                             {
                                 Id = prod.Id,
                                 Descripcion = prod.Descripcion,
                                 CodigoBarra = prod.CodigoBarra,
                                 IdCategoria = prod.IdCategoria,
                                 Marca = prod.Marca,
                                 NombreImagen = prod.NombreImagen,
                                 Precio = prod.Precio,
                                 Stock = prod.Stock,
                                 UrlImagen = prod.UrlImagen

                             }).ToList();

                result.Data = query;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());

            }
            return result;
        }

        public async Task<ServiceResult> GetProductos()
        {
            ServiceResult result = new();

            try
            {
                var query = (from prod in this.producto.GetAll()
                             where !prod.Eliminado
                             orderby prod.FechaRegistro descending
                             select new ProductoModel()
                             {
                                 Descripcion = prod.Descripcion,
                                 CodigoBarra = prod.CodigoBarra,
                                 IdCategoria = prod.IdCategoria,
                                 Marca = prod.Marca,
                                 NombreImagen = prod.NombreImagen,
                                 Precio = prod.Precio,
                                 Stock = prod.Stock,
                                 UrlImagen = prod.UrlImagen
                             }).ToList();

                result.Data = query;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());

                throw;
            }
            return result;
        }

        public async Task<ServiceResult> Save(AddProductoDto producto)
        {
            ServiceResult result = new();

            try
            {
                Producto p = new()
                {
                    CodigoBarra = producto.CodigoBarra,
                    FechaRegistro = producto.FechaRegistro,
                    IdCategoria = producto.IdCategoria,
                    IdUsuarioCreacion = producto.IdUsuarioCreacion,
                    Descripcion = producto.Descripcion,
                    Marca = producto.Marca,
                    NombreImagen = producto.NombreImagen,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    UrlImagen = producto.UrlImagen
                };

                result.Data = this.producto.Save(p);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<ServiceResult> Update(UpdateProductoDto producto)
        {
            ServiceResult result = new();

            try
            {
                Producto p = new()
                {
                    CodigoBarra = producto.CodigoBarra,
                    FechaMod = producto.FechaMod,
                    IdCategoria = producto.IdCategoria,
                    IdUsuarioMod = producto.IdUsuarioMod,
                    Descripcion = producto.Descripcion,
                    Marca = producto.Marca,
                    NombreImagen = producto.NombreImagen,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    UrlImagen = producto.UrlImagen
                };

                result.Data = this.producto.Update(p);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
