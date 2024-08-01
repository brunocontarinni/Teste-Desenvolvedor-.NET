using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API_CRM.Controllers
{

    [Route("")]
    [Route("Index")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
            
        }

        [Route("Processo")]
        public IActionResult Processo()
        {

            ViewData["titulo"] = "Processo";
            return View("Processo");

        }
        
        [Route("Curso")]
        public IActionResult Curso()
        {

            ViewData["titulo"] = "Curso";
            return View("Curso");

        }
        
        [Route("Candidato")]
        public IActionResult Candidato()
        {

            ViewData["titulo"] = "Candidato";
            return View("Candidato");

        }
        
        [Route("Inscricao")]
        public IActionResult Inscricao()
        {

            ViewData["titulo"] = "Inscrição";
            return View("Inscricao");

        }

    }
}
