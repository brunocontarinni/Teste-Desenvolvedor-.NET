using Microsoft.AspNetCore.Mvc;

namespace Teste.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
