using Microsoft.AspNetCore.Mvc;
using Sales.API.Extensions;
using Sales.API.Models.Venta;
using Sales.AppServices.Interfaces;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        private readonly IVentaService ventaService;

        public VentaController(IVentaService ventaService)
        {
            this.ventaService = ventaService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetVentas()
        {

            var result = this.ventaService.GetVentas();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("TotalDeVentaBySellerId")]
        public async Task<IActionResult> GetTotalDeVentaBySellerId([FromBody] SearchVentaBySeller sellerId)
        {

            var result = await this.ventaService.GetTotalVentasBySellerId(sellerId.SellerId);

            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Create([FromBody] VentaCreateModel createModel)
        {
            var venta = createModel.ConvertFromVentaToAddVentaDto();

            var result = await this.ventaService.Save(venta);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
