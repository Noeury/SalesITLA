using Microsoft.Extensions.Logging;
using Sales.AppServices.Core;
using Sales.AppServices.Dtos.Negocio;
using Sales.AppServices.Interfaces;
using Sales.Domain.Entities;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Services
{
    public class NegocioService : INegocioService
    {

        private readonly INegocioDb negocio;
        private readonly ILogger<NegocioService> logger;

        public NegocioService(INegocioDb negocio, ILogger<NegocioService> logger)
        {
            this.negocio = negocio;
            this.logger = logger;
        }
        public async Task<ServiceResult> GetNegocios()
        {
            ServiceResult result = new();

            try
            {

                var query = (from neg in this.negocio.GetAll()
                             where neg.Eliminado == false
                             orderby neg.FechaRegistro descending
                             select new Models.NegocioModel()
                             {
                                 Correo = neg.Correo,
                                 Direccion = neg.Direccion,
                                 FechaRegistro = neg.FechaRegistro,
                                 Nombre = neg.Nombre,
                                 NombreLogo = neg.NombreLogo,
                                 NumeroDocumento = neg.NumeroDocumento,
                                 PorcentajeImpuesto = neg.PorcentajeImpuesto,
                                 SimboloMoneda = neg.SimboloMoneda,
                                 Telefono = neg.Telefono,

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

        public async Task<ServiceResult> GetNeocioByName(string name)
        {
            ServiceResult result = new();

            try
            {
                var query = (from neg in this.negocio.GetAll()
                             where neg.Nombre == name
                             select new Models.NegocioModel()
                             {
                                 Nombre = neg.Nombre,
                                 Correo = neg.Correo,
                                 Direccion = neg.Direccion,
                                 FechaRegistro = neg.FechaRegistro,
                                 NombreLogo = neg.NombreLogo,
                                 NumeroDocumento = neg.NumeroDocumento,
                                 PorcentajeImpuesto = neg.PorcentajeImpuesto,
                                 SimboloMoneda = neg.SimboloMoneda,
                                 Telefono = neg.Telefono,
                                 UrlLogo = neg.UrlLogo

                             });

                result.Data = query;

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());

            }
            return result;

        }

        public async Task<ServiceResult> Save(AddNegocioDto negocio)
        {
            ServiceResult result = new();

            try
            {
                Negocio n = new()
                {
                    UrlLogo = negocio.UrlLogo,
                    NombreLogo = negocio.NombreLogo,
                    NumeroDocumento = negocio.NumeroDocumento,
                    Nombre = negocio.Nombre,
                    Correo = negocio.Correo,
                    Direccion = negocio.Direccion,
                    Telefono = negocio.Telefono,
                    PorcentajeImpuesto = negocio.PorcentajeImpuesto,
                    SimboloMoneda = negocio.SimboloMoneda,
                    IdUsuarioCreacion = negocio.IdUsuarioCreacion,

                };
                result.Data = this.negocio.Save(n);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<ServiceResult> Update(UpdateNegocioDto negocio)
        {
            ServiceResult result = new();

            try
            {
                Negocio n = new()
                {
                    UrlLogo = negocio.UrlLogo,
                    NombreLogo = negocio.NombreLogo,
                    NumeroDocumento = negocio.NumeroDocumento,
                    Nombre = negocio.Nombre,
                    Correo = negocio.Correo,
                    Direccion = negocio.Direccion,
                    Telefono = negocio.Telefono,
                    PorcentajeImpuesto = negocio.PorcentajeImpuesto,
                    SimboloMoneda = negocio.SimboloMoneda,
                    IdUsuarioMod = negocio.IdUsuarioMod,

                };
                result.Data = this.negocio.Update(n);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
