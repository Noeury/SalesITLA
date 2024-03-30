using Microsoft.AspNetCore.Mvc;
using Sales.Web.Contracts;
using Sales.Web.Models.Negocio;
using Sales.Web.Models.Producto;

namespace Sales.Web.Controllers
{
    public class NegocioController : Controller
    {

        private readonly INegocioService negocioService;

        public NegocioController(INegocioService negocioService)
        {
            this.negocioService = negocioService;

        }
        public async Task<IActionResult> Index()
        {
            var result = await this.negocioService.GetNeocios();

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var productos = result.data;

            return View(productos);
        }

        public async Task<IActionResult> Edit(NegocioSearchModel search)
        {

            var result = await this.negocioService.GetNeocioByName(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var producto = result.data;

            return View(producto);
        }

        public async Task<IActionResult> Details(NegocioSearchModel search)
        {
            var result = await this.negocioService.GetNeocioByName(search);

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
        public async Task<IActionResult> Create(NegocioCreateModel negocioCreateModel)
        {
            negocioCreateModel.FechaRegistro = DateTime.Now;
            negocioCreateModel.IdUsuarioCreacion = 1;
            var result = await this.negocioService.CreateNegocio(negocioCreateModel);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return RedirectToAction("Index");

        }
    }
}
