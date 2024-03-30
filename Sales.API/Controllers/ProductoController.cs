using Microsoft.AspNetCore.Mvc;
using Sales.API.Extensions;
using Sales.API.Models.Producto;
using Sales.AppServices.Interfaces;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet("GetProductos")]
        public async Task<IActionResult> GetProductos()
        {
            var result = await this.productoService.GetProductos();


            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("GetProductoByDescipcion")]
        public async Task<IActionResult> GetProductoByDescipcion([FromBody] SearchProductoModel searchProductoModel)
        {
            var result = await this.productoService.GetProductoByDescripcion(searchProductoModel.Descripcion);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPost("Save")]
        public async Task<IActionResult> Create([FromBody] ProductoCreateModel createModel)
        {
            var producto = createModel.ConverFromProductoToAddProductoDto();

            var result = await this.productoService.Save(producto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ProductoUpdateModel updateModel)
        {
            var producto = updateModel.ConverFromProductoToUpdateDto();

            var result = await this.productoService.Update(producto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }


    }
}
