using Microsoft.AspNetCore.Mvc;
using Destino1.Models;

namespace Destino1.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Servicio> _destinos = new List<Servicio>
        {
            new Servicio { Id = 1, Nombre = "Bali", Pais = "Indonesia", Region = "Asia", Tipo = "Playas", Descripcion = "Playas paradisíacas, templos milenarios y naturaleza.", MejorEpoca = "May - Sep", Puntuacion = 4.7, Resenas = 245, Precio = 689, ImagenUrl = "~/imagines/bali.jpg" },
            new Servicio { Id = 2, Nombre = "París", Pais = "Francia", Region = "Europa", Tipo = "Ciudad", Descripcion = "La ciudad del amor, la moda y la gastronomía.", MejorEpoca = "Mar - Jun", Puntuacion = 4.9, Resenas = 380, Precio = 998, ImagenUrl = "~/imagines/Paris.png" },
            new Servicio { Id = 3, Nombre = "Nueva York", Pais = "EE.UU", Region = "América", Tipo = "Ciudad", Descripcion = "La ciudad que nunca duerme, llena de opciones para todos.", MejorEpoca = "Mar - Jun", Puntuacion = 4.6, Resenas = 430, Precio = 950, ImagenUrl = "~/imagines/New-York.jpg" },
            new Servicio { Id = 4, Nombre = "Dubái", Pais = "EAU", Region = "Asia", Tipo = "Ciudad", Descripcion = "Descubre una ciudad llena de lujo y arquitectura.", MejorEpoca = "Nov - Mar", Puntuacion = 4.8, Resenas = 280, Precio = 899, ImagenUrl = "~/imagines/dubai.jpg" }
        };

        public IActionResult Index(string? region, string? pais, string? tipo, decimal? precioMax, double? puntuacionMin, string? orden)
        {
            var consulta = _destinos.AsQueryable();

            if (!string.IsNullOrEmpty(region))
            {
                consulta = consulta.Where(d => d.Region.Equals(region, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(pais))
            {
                consulta = consulta.Where(d => d.Pais.Equals(pais, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                consulta = consulta.Where(d => d.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase));
            }

            if (precioMax.HasValue)
            {
                consulta = consulta.Where(d => d.Precio <= precioMax.Value);
            }

            if (puntuacionMin.HasValue)
            {
                consulta = consulta.Where(d => d.Puntuacion >= puntuacionMin.Value);
            }

            if (orden == "PrecioMasBajo")
            {
                consulta = consulta.OrderBy(d => d.Precio);
            }

            ViewBag.Region = region;
            ViewBag.Pais = pais;
            ViewBag.Tipo = tipo;
            ViewBag.PrecioMax = precioMax;
            ViewBag.PuntuacionMin = puntuacionMin;
            ViewBag.Orden = orden;

            return View(consulta.ToList());
        }
    }
}