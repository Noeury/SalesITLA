using Microsoft.AspNetCore.Mvc;

namespace Sales.Web.Controllers
{
    public class NegocioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
