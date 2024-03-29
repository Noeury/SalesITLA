using Sales.API.Models.Venta;
using Sales.AppServices.Dtos.Venta;

namespace Sales.API.Extensions
{
    public static class VentaExtension
    {
        public static AddVentaDto ConvertFromVentaToAddVentaDto(this VentaCreateModel model)
        {
            return new AddVentaDto()
            {
                CocumentoCliente = model.CocumentoCliente,
                FechaRegistro = model.FechaRegistro,
                IdTipoDocumentoVenta = model.IdTipoDocumentoVenta,
                IdUsuario = model.IdUsuario,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                ImpuestoTotal = model.ImpuestoTotal,
                NombreCliente = model.NombreCliente,
                NumeroVenta = model.NumeroVenta,
                SubTotal = model.SubTotal,
                Total = model.SubTotal
            };
        }
    }
}
