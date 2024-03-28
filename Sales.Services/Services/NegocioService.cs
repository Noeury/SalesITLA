using Sales.AppServices.Core;
using Sales.AppServices.Dtos;
using Sales.AppServices.Interfaces;
using Sales.Domain.Entities;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Services
{
    public class NegocioService : INegocioService
    {

        private readonly INegocioDb negocio;

        public NegocioService(INegocioDb negocio)
        {
            this.negocio = negocio;
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
            catch (Exception)
            {

                throw;
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
                    IdUsuarioCreacion = negocio.IdUsuarioCreacion,

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
