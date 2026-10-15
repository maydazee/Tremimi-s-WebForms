using Microsoft.AspNetCore.Mvc;
using Paquete.Models;
using System.Diagnostics;

namespace Paquete.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Paquetes> _paquetes = new List<Paquetes>
        {
            new Paquetes
            {
                Id = 1,
                Nombre = "Escapada a las Maldivas",
                Descripcion = "Disfruta de villas sobre el agua, aguas cristalinas y atardeceres inolvidables en el archipiélago más exclusivo del océano Índico.",
                Vuelos = "Vuelos incluidos",
                Hotel = "Hotel 5 estrellas",
                Transportacion = "Transportación incluida",
                Precio = 1400,
                ImagenUrl = "~/imagines/maldivas.jpg"
            },
            new Paquetes
            {
                Id = 2,
                Nombre = "Italia Clásica",
                Descripcion = "Recorre Roma, Florencia y Venecia disfrutando de la historia, arquitectura renacentista y la mejor gastronomía mediterránea.",
                Vuelos = "Vuelos incluidos",
                Hotel = "Hotel 4 estrellas",
                Transportacion = "Tours incluidos",
                Precio = 1119,
                ImagenUrl = "~/imagines/italia.jpg"
            },
            new Paquetes
            {
                Id = 3,
                Nombre = "Japón Esencial",
                Descripcion = "Explora la mezcla entre la modernidad de Tokio y la tradición de Kioto, templos antiguos y la icónica vista del Monte Fuji.",
                Vuelos = "Vuelos incluidos",
                Hotel = "Hotel 4 estrellas",
                Transportacion = "Transportación incluida",
                Precio = 1699,
                ImagenUrl = "~/imagines/japon.jpg"
            }
        };

        public IActionResult Index()
        {
            return View(_paquetes);
        }

        public IActionResult Detalle(int id)
        {
            var paquete = _paquetes.FirstOrDefault(p => p.Id == id);
            if (paquete == null)
            {
                return RedirectToAction("Index");
            }
            return View(paquete);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}