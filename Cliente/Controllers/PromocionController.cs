using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Controllers
{
    public class PromocionController : Controller
    {
        private static List<Clientes.Models.Promocion> _promociones = new List<Clientes.Models.Promocion>
        {
            new Clientes.Models.Promocion { Id = 1, Codigo = "PR-001", Titulo = "Verano en Cancún", Descripcion = "Sol, playas y experiencias únicas.", AplicaA = "Paquetes turísticos", DescuentoPorcentaje = 20, FechaInicio = "01/10/2026", FechaFin = "31/10/2026", Estado = "Activa", ImagenUrl = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e" },
            new Clientes.Models.Promocion { Id = 2, Codigo = "PR-002", Titulo = "Escapada a Nueva York", Descripcion = "La ciudad que nunca duerme.", AplicaA = "Vuelos", DescuentoPorcentaje = 15, FechaInicio = "05/10/2026", FechaFin = "25/10/2026", Estado = "Activa", ImagenUrl = "https://images.unsplash.com/photo-1496442226666-8d4d0e62e6e9" },
            new Clientes.Models.Promocion { Id = 3, Codigo = "PR-003", Titulo = "Ecoturismo Costa Rica", Descripcion = "Aventura y naturaleza al máximo.", AplicaA = "Paquetes turísticos", DescuentoPorcentaje = 10, FechaInicio = "10/10/2026", FechaFin = "20/10/2026", Estado = "Por vencer", ImagenUrl = "https://images.unsplash.com/photo-1518638150340-f706e86654de" },
            new Clientes.Models.Promocion { Id = 4, Codigo = "PR-004", Titulo = "Otoño en París", Descripcion = "Descuento en vuelos seleccionados.", AplicaA = "Vuelos", DescuentoPorcentaje = 25, FechaInicio = "01/08/2026", FechaFin = "31/08/2026", Estado = "Inactiva", ImagenUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34" }
        };

        public IActionResult Index(string? buscar, string? estado, string? tipo)
        {
            var consulta = _promociones.AsQueryable();

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                string termino = buscar.Trim().ToLower();
                consulta = consulta.Where(p => p.Titulo.ToLower().Contains(termino) ||
                                               p.Descripcion.ToLower().Contains(termino) ||
                                               p.Codigo.ToLower().Contains(termino));
            }

            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todas")
            {
                consulta = consulta.Where(p => p.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(tipo) && tipo != "Todas")
            {
                consulta = consulta.Where(p => p.AplicaA.Equals(tipo, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.TotalPromociones = _promociones.Count;
            ViewBag.PromocionesActivas = _promociones.Count(p => p.Estado == "Activa");
            ViewBag.PorVencer = _promociones.Count(p => p.Estado == "Por vencer");
            ViewBag.PromocionesInactivas = _promociones.Count(p => p.Estado == "Inactiva");

            ViewBag.BuscarActual = buscar;
            ViewBag.EstadoActual = estado ?? "Todas";
            ViewBag.TipoActual = tipo ?? "Todas";

            return View("~/Views/Home/Promocion.cshtml", consulta.ToList());
        }

        [HttpPost]
        public IActionResult Crear(Clientes.Models.Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                promocion.Id = _promociones.Any() ? _promociones.Max(p => p.Id) + 1 : 1;
                promocion.Codigo = $"PR-{promocion.Id:D3}";
                if (string.IsNullOrWhiteSpace(promocion.ImagenUrl))
                {
                    promocion.ImagenUrl = "https://images.unsplash.com/photo-1488646953014-85cb44e25828";
                }
                _promociones.Insert(0, promocion);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Clientes.Models.Promocion promocionEditada)
        {
            var promo = _promociones.FirstOrDefault(p => p.Id == promocionEditada.Id);
            if (promo != null)
            {
                promo.Titulo = promocionEditada.Titulo;
                promo.Descripcion = promocionEditada.Descripcion;
                promo.AplicaA = promocionEditada.AplicaA;
                promo.DescuentoPorcentaje = promocionEditada.DescuentoPorcentaje;
                promo.FechaInicio = promocionEditada.FechaInicio;
                promo.FechaFin = promocionEditada.FechaFin;
                promo.Estado = promocionEditada.Estado;
                if (!string.IsNullOrWhiteSpace(promocionEditada.ImagenUrl))
                {
                    promo.ImagenUrl = promocionEditada.ImagenUrl;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var promo = _promociones.FirstOrDefault(p => p.Id == id);
            if (promo != null)
            {
                _promociones.Remove(promo);
            }
            return RedirectToAction("Index");
        }
    }
}