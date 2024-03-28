using Sales.API.Models.Negocio;
using Sales.AppServices.Dtos;
using Sales.Domain.Entities;
using Sales.Infraestructure.Dao;

namespace Sales.API.Extensions
{
    public static class NegocioExtension
    {
        public static Negocio ConvertFromNegocioCreateToNegocio(this NegocioCreateModel model)
        {
            return new Negocio()
            {
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Correo = model.Correo,
                Direccion = model.Direccion,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                UrlLogo = model.UrlLogo,
                NombreLogo = model.NombreLogo,
                NumeroDocumento = model.NumeroDocumento,
                PorcentajeImpuesto = model.PorcentajeImpuesto,
                SimboloMoneda = model.SimboloMoneda,
                FechaRegistro = model.FechaRegistro
            };


        //            public string? UrlLogo { get; set; }
        //public string? NombreLogo { get; set; }
        //public string? NumeroDocumento { get; set; }
        //public string? Nombre { get; set; }
        //public string? Correo { get; set; }
        //public string? Direccion { get; set; }
        //public string? Telefono { get; set; }
        //public decimal? PorcentajeImpuesto { get; set; }
        //public string? SimboloMoneda { get; set; }
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


    }
}
