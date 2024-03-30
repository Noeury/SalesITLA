using Microsoft.AspNetCore.Mvc;
using Sales.Web.Contracts;
using Sales.Web.Models.Venta;

namespace Sales.Web.Controllers
{
    public class VentaController : Controller
    {

        private readonly IVentaService ventaService;

        public VentaController(IVentaService ventaService)
        {
            this.ventaService = ventaService;

        }
        public async Task<IActionResult> Index()
        {
            var result = await this.ventaService.GetVentas();

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var productos = result.data;

            return View(productos);
        }

        

        public async Task<IActionResult> Details(SearchTotalVentaBySellerId search)
        {
            var result = await this.ventaService.GetTotalVetaBySellerId(search);

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
        public async Task<IActionResult> Create(VentaCreateModel ventaCreateModel)
        {
            ventaCreateModel.FechaRegistro = DateTime.Now;
            ventaCreateModel.IdUsuario = 2;
            var result = await this.ventaService.CreateVenta(ventaCreateModel);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return RedirectToAction("Index");

        }
    }
}
