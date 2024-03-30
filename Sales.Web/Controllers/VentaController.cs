using Microsoft.AspNetCore.Mvc;

namespace Sales.Web.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
