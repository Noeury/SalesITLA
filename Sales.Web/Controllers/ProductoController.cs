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

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var productos = result.data;

            return View(productos);
        }

        public async Task<IActionResult> Edit(ProductoSearchModel search)
        {

            var result = await this.productoService.GetProductoByDescripcion(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var producto = result.data;

            return View(producto);
        }

        public async Task<IActionResult> Details(ProductoSearchModel search)
        {
            var result = await this.productoService.GetProductoByDescripcion(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var producto = result.data;

            return View(producto);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoCreateModel productoModel)
        {
            productoModel.FechaRegistro = DateTime.Now;
            productoModel.IdUsuarioCreacion = 1;
            var result =  await this.productoService.CreateProducto(productoModel);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
