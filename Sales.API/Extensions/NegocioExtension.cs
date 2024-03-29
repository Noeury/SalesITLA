using Sales.API.Models.Negocio;
using Sales.AppServices.Dtos.Negocio;
using Sales.Domain.Entities;

namespace Sales.API.Extensions
{
    public static class NegocioExtension
    {
        public static Negocio ConvertFromNegocioCreateToNegocio(this NegocioCreateModel model)
        {
            return new Negocio()
            {
                UrlLogo = model.UrlLogo,
                NombreLogo = model.NombreLogo,
                NumeroDocumento = model.NumeroDocumento,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                PorcentajeImpuesto = model.PorcentajeImpuesto,
                SimboloMoneda = model.SimboloMoneda
            };


        }

        public static AddNegocioDto ConvertFromNegocioCreateToAddNegocioDto(this NegocioCreateModel model)
        {
            return new AddNegocioDto()
            {
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                FechaRegistro = model.FechaRegistro,
                NombreLogo = model.NombreLogo,
                NumeroDocumento = model.NumeroDocumento,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                PorcentajeImpuesto = model.PorcentajeImpuesto,
                SimboloMoneda = model.SimboloMoneda
            };
        }

        public static Negocio ConvertFromNegocioUpdateToNegocio(this NegocioUpdateModel model)
        {

            return new Negocio()
            {
                Id = model.NegocioId,
                UrlLogo = model.UrlLogo,
                NombreLogo = model.NombreLogo,
                NumeroDocumento = model.NumeroDocumento,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                PorcentajeImpuesto = model.PorcentajeImpuesto,
                SimboloMoneda = model.SimboloMoneda,
                FechaMod = model.FechaMod,
                IdUsuarioMod = model.IdUsuarioMod
            };
        }

        public static UpdateNegocioDto ConvertFromNegocioUpdateToUpdateNegocioDto(this NegocioUpdateModel model)
        {

            return new UpdateNegocioDto()
            {
                Id = model.NegocioId,
                UrlLogo = model.UrlLogo,
                NombreLogo = model.NombreLogo,
                NumeroDocumento = model.NumeroDocumento,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                PorcentajeImpuesto = model.PorcentajeImpuesto,
                SimboloMoneda = model.SimboloMoneda,
                FechaMod = model.FechaMod,
                IdUsuarioMod = model.IdUsuarioMod
            };
        }


    }
}
