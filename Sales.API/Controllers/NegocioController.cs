using Microsoft.AspNetCore.Mvc;
using Sales.API.Extensions;
using Sales.API.Models.Negocio;
using Sales.AppServices.Dtos;
using Sales.AppServices.Interfaces;
using Sales.Infraestructure.Interfaces;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioService negocioService;

        public NegocioController(INegocioService negocioService)
        {
            this.negocioService = negocioService;
        }

        [HttpGet("GetNegocios")]
        public IActionResult GetNeocios()
        {
            var negocios = this.negocioService.GetNegocios();

            return Ok(negocios);
        }


        [HttpPost("GetNegocioByName")]
        public async Task<IActionResult> GetNeocioByName([FromBody] SearchNegocioModel searchNegocio)
        {
            var result = await this.negocioService.GetNeocioByName(searchNegocio.Nombre);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Create([FromBody] NegocioCreateModel createModel)
        {
            var negocio = createModel.ConvertFromNegocioCreateToAddNegocioDto();

            var result = await this.negocioService.Save(negocio);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] NegocioUpdateModel updateModel)
        {
            var negocioDto = new UpdateNegocioDto
            {
                Id = updateModel.NegocioId,
                UrlLogo = updateModel.UrlLogo,
                NombreLogo = updateModel.NombreLogo,
                NumeroDocumento = updateModel.NumeroDocumento,
                Nombre = updateModel.Nombre,
                Correo = updateModel.Correo,
                Direccion = updateModel.Direccion,
                Telefono = updateModel.Telefono,
                PorcentajeImpuesto = updateModel.PorcentajeImpuesto,
                SimboloMoneda = updateModel.SimboloMoneda,
                FechaMod = updateModel.FechaMod,
                IdUsuarioMod = updateModel.IdUsuarioMod
            };

            var result = await this.negocioService.Update(negocioDto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
