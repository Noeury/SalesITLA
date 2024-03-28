using Microsoft.AspNetCore.Mvc;

namespace Sales.API.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
