using Microsoft.AspNetCore.Mvc;
using Sales.API.Extensions;
using Sales.API.Models.Negocio;
using Sales.AppServices.Core;
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
            ServiceResult result = new();

            var negocios = this.negocioService.GetNegocios();

            result.Data = negocios;

            if (!result.Success)
                return BadRequest(result);

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
            var negocio = updateModel.ConvertFromNegocioUpdateToUpdateNegocioDto();

            var result = await this.negocioService.Update(negocio);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
