using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Controllers
{
    public class PaqueteController : Controller
    {
        private static List<Clientes.Models.Paquete> _paquetes = new List<Clientes.Models.Paquete>
        {
            new Clientes.Models.Paquete { Id = 1, Nombre = "Cancún Todo Incluido", Descripcion = "Sol, playas y experiencias únicas frente al mar Caribe.", Destino = "México", Duracion = "5 días", Precio = 899, Tipo = "Playa", Estado = "Promoción", ImagenUrl = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e" },
            new Clientes.Models.Paquete { Id = 2, Nombre = "Escapada a Nueva York", Descripcion = "Disfruta de la ciudad que nunca duerme con tours guiados.", Destino = "EE. UU.", Duracion = "4 días", Precio = 1250, Tipo = "Ciudad", Estado = "Activo", ImagenUrl = "https://images.unsplash.com/photo-1496442226666-8d4d0e62e6e9" },
            new Clientes.Models.Paquete { Id = 3, Nombre = "Aventura en Costa Rica", Descripcion = "Naturaleza, volcanes, tirolesa y playas en un solo viaje.", Destino = "Costa Rica", Duracion = "6 días", Precio = 750, Tipo = "Naturaleza", Estado = "Activo", ImagenUrl = "https://images.unsplash.com/photo-1518638150340-f706e86654de" },
            new Clientes.Models.Paquete { Id = 4, Nombre = "Encantos de París", Descripcion = "Recorre la torre Eiffel, el Museo del Louvre y el Sena.", Destino = "Francia", Duracion = "7 días", Precio = 2100, Tipo = "Cultural", Estado = "Inactivo", ImagenUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34" }
        };

        public IActionResult Index(string? buscar, string? destino, string? estado, string? tipo)
        {
            var consulta = _paquetes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                string termino = buscar.Trim().ToLower();
                consulta = consulta.Where(p => p.Nombre.ToLower().Contains(termino) ||
                                               p.Descripcion.ToLower().Contains(termino) ||
                                               p.Destino.ToLower().Contains(termino));
            }

            if (!string.IsNullOrWhiteSpace(destino) && destino != "Todos")
            {
                consulta = consulta.Where(p => p.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                consulta = consulta.Where(p => p.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(tipo) && tipo != "Todos")
            {
                consulta = consulta.Where(p => p.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.TotalPaquetes = _paquetes.Count;
            ViewBag.PaquetesActivos = _paquetes.Count(p => p.Estado == "Activo");
            ViewBag.PaquetesPromocion = _paquetes.Count(p => p.Estado == "Promoción");
            ViewBag.PaquetesInactivos = _paquetes.Count(p => p.Estado == "Inactivo");

            ViewBag.BuscarActual = buscar;
            ViewBag.DestinoActual = destino ?? "Todos";
            ViewBag.EstadoActual = estado ?? "Todos";
            ViewBag.TipoActual = tipo ?? "Todos";

            return View("~/Views/Home/Paquete.cshtml", consulta.ToList());
        }

        [HttpPost]
        public IActionResult Crear(Clientes.Models.Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                paquete.Id = _paquetes.Any() ? _paquetes.Max(p => p.Id) + 1 : 1;
                if (string.IsNullOrWhiteSpace(paquete.ImagenUrl))
                {
                    paquete.ImagenUrl = "https://images.unsplash.com/photo-1488646953014-85cb44e25828";
                }
                _paquetes.Insert(0, paquete);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Clientes.Models.Paquete paqueteEditado)
        {
            var paq = _paquetes.FirstOrDefault(p => p.Id == paqueteEditado.Id);
            if (paq != null)
            {
                paq.Nombre = paqueteEditado.Nombre;
                paq.Descripcion = paqueteEditado.Descripcion;
                paq.Destino = paqueteEditado.Destino;
                paq.Duracion = paqueteEditado.Duracion;
                paq.Precio = paqueteEditado.Precio;
                paq.Tipo = paqueteEditado.Tipo;
                paq.Estado = paqueteEditado.Estado;
                if (!string.IsNullOrWhiteSpace(paqueteEditado.ImagenUrl))
                {
                    paq.ImagenUrl = paqueteEditado.ImagenUrl;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var paq = _paquetes.FirstOrDefault(p => p.Id == id);
            if (paq != null)
            {
                _paquetes.Remove(paq);
            }
            return RedirectToAction("Index");
        }
    }
}