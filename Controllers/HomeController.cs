using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    public class HomeController : Controller
    {
        // Acción para la página de Contacto
        public IActionResult Contacto()
        {
            return View();
        }

        // Acción para la página de Proceso (si también la estás usando)
        public IActionResult    Index()
        {
            return View();
        }

        // Acción para la página de privacidad (si existe)
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
