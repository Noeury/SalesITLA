using Microsoft.AspNetCore.Mvc;
using Sales.Web.Contracts;
using Sales.Web.Models.Producto;

namespace Sales.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;

        }

        public async Task<IActionResult> IndexAsync()
        {
            var result = await this.productoService.GetProductos();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var productos = result.Data;

            return View(productos);
        }

        public async Task<IActionResult> Edit(ProductoSearchModel search)
        {

            var result = await this.productoService.GetProductoByDescripcion(search);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var producto = result.Data;

            return View(producto);
        }
    }
}
