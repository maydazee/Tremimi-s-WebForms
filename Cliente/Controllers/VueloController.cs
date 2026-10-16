using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Controllers
{
    public class VueloController : Controller
    {
        private static List<Clientes.Models.Vuelo> _vuelos = new List<Clientes.Models.Vuelo>
        {
            new Clientes.Models.Vuelo { Id = 1, CodigoVuelo = "AV 101", Aerolinea = "Avianca", LogoUrl = "/imagine/avianca.jpg", Origen = "San Salvador (SAL)", Destino = "Bogotá (BOG)", FechaSalida = "12/09/2026", HoraSalida = "08:15", HoraLlegada = "11:30", Precio = 280, Estado = "Activo" },
            new Clientes.Models.Vuelo { Id = 2, CodigoVuelo = "CM 230", Aerolinea = "Copa Airlines", LogoUrl = "/imagine/Copa.jpg", Origen = "San Salvador (SAL)", Destino = "Ciudad de Panamá (PTY)", FechaSalida = "14/09/2026", HoraSalida = "10:00", HoraLlegada = "13:20", Precio = 320, Estado = "Activo" },
            new Clientes.Models.Vuelo { Id = 3, CodigoVuelo = "AA 312", Aerolinea = "American Airlines", LogoUrl = "/imagine/america.png", Origen = "San Salvador (SAL)", Destino = "Miami (MIA)", FechaSalida = "18/09/2026", HoraSalida = "07:30", HoraLlegada = "12:10", Precio = 450, Estado = "Promoción" },
            new Clientes.Models.Vuelo { Id = 4, CodigoVuelo = "IB 640", Aerolinea = "Iberia", LogoUrl = "/imagine/iberia.png", Origen = "San Salvador (SAL)", Destino = "Madrid (MAD)", FechaSalida = "20/09/2026", HoraSalida = "16:25", HoraLlegada = "09:50 (+1)", Precio = 620, Estado = "Activo" },
            new Clientes.Models.Vuelo { Id = 5, CodigoVuelo = "DL 500", Aerolinea = "Delta Airlines", LogoUrl = "/imagine/delta.png", Origen = "San Salvador (SAL)", Destino = "Nueva York (JFK)", FechaSalida = "25/09/2026", HoraSalida = "14:10", HoraLlegada = "22:45", Precio = 510, Estado = "Activo" }
        };

        public IActionResult Index(string? buscar, string? origen, string? destino, string? estado)
        {
            var consulta = _vuelos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                string termino = buscar.Trim().ToLower();
                consulta = consulta.Where(v => v.CodigoVuelo.ToLower().Contains(termino) ||
                                               v.Aerolinea.ToLower().Contains(termino) ||
                                               v.Origen.ToLower().Contains(termino) ||
                                               v.Destino.ToLower().Contains(termino));
            }

            if (!string.IsNullOrWhiteSpace(origen) && origen != "Todos")
            {
                consulta = consulta.Where(v => v.Origen.Equals(origen, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(destino) && destino != "Todos")
            {
                consulta = consulta.Where(v => v.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                consulta = consulta.Where(v => v.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.TotalVuelos = _vuelos.Count;
            ViewBag.VuelosActivos = _vuelos.Count(v => v.Estado == "Activo");
            ViewBag.EnPromocion = _vuelos.Count(v => v.Estado == "Promoción");
            ViewBag.VuelosInactivos = _vuelos.Count(v => v.Estado == "Inactivo");

            ViewBag.BuscarActual = buscar;
            ViewBag.OrigenActual = origen ?? "Todos";
            ViewBag.DestinoActual = destino ?? "Todos";
            ViewBag.EstadoActual = estado ?? "Todos";

            return View("~/Views/Home/Vuelo.cshtml", consulta.ToList());
        }

        [HttpPost]
        public IActionResult Crear(Clientes.Models.Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                vuelo.Id = _vuelos.Any() ? _vuelos.Max(v => v.Id) + 1 : 1;
                if (string.IsNullOrWhiteSpace(vuelo.LogoUrl))
                {
                    vuelo.LogoUrl = "/imagine/delta.png";
                }
                _vuelos.Insert(0, vuelo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Clientes.Models.Vuelo vueloEditado)
        {
            var vue = _vuelos.FirstOrDefault(v => v.Id == vueloEditado.Id);
            if (vue != null)
            {
                vue.CodigoVuelo = vueloEditado.CodigoVuelo;
                vue.Aerolinea = vueloEditado.Aerolinea;
                vue.Origen = vueloEditado.Origen;
                vue.Destino = vueloEditado.Destino;
                vue.FechaSalida = vueloEditado.FechaSalida;
                vue.HoraSalida = vueloEditado.HoraSalida;
                vue.HoraLlegada = vueloEditado.HoraLlegada;
                vue.Precio = vueloEditado.Precio;
                vue.Estado = vueloEditado.Estado;
                if (!string.IsNullOrWhiteSpace(vueloEditado.LogoUrl))
                {
                    vue.LogoUrl = vueloEditado.LogoUrl;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var vue = _vuelos.FirstOrDefault(v => v.Id == id);
            if (vue != null)
            {
                _vuelos.Remove(vue);
            }
            return RedirectToAction("Index");
        }
    }
}