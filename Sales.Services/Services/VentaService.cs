using Microsoft.Extensions.Logging;
using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Venta;
using Sales.AppServices.Interfaces;
using Sales.Domain.Entities;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaDb venta;
        private readonly ILogger<VentaService> logger;


        public VentaService(IVentaDb venta, ILogger<VentaService> logger)
        {
            this.venta = venta;
            this.logger = logger;

        }
        public async Task<ServiceResult> GetTotalVentasBySellerId(int selleId)
        {
            ServiceResult result = new();

            result.Data = await this.venta.totalDeVentaBySellerId(selleId);

            return result;

        }

        public ServiceResult GetVentaById(int id)
        {
            ServiceResult result = new();

            result.Data = this.venta.GetById(id);

            return result;
        }

        public ServiceResult GetVentas()
        {
            ServiceResult result = new();

            result.Data = this.venta.GetAll();

            return result;
        }

        public async Task<ServiceResult> Save(AddVentaDto venta)
        {
            ServiceResult result = new();
            try
            {
                Venta v = new()
                {
                    CocumentoCliente = venta.CocumentoCliente,
                    FechaRegistro = venta.FechaRegistro,
                    SubTotal = venta.SubTotal,
                    Total = venta.Total,
                    IdTipoDocumentoVenta = venta.IdTipoDocumentoVenta,
                    IdUsuario = venta.IdUsuario,
                    IdUsuarioCreacion = venta.IdUsuarioCreacion,
                    ImpuestoTotal = venta.ImpuestoTotal,
                    NombreCliente = venta.NombreCliente,
                    NumeroVenta = venta.NumeroVenta
                };

                result.Data = this.venta.Save(v);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
