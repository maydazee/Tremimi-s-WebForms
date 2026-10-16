using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Controllers
{
    public class HomeController : Controller
    {
        private static List<Clientes.Models.Cliente> _clientes = new List<Clientes.Models.Cliente>
        {
            new Clientes.Models.Cliente { Id = 1, Nombre = "Carlos", Apellido = "Mendoza", DuiPasaporte = "04829102-3", Correo = "carlos.mendoza@email.com", Telefono = "+503 7812-3456", Nacionalidad = "Salvadoreña", Estado = "Activo", EsNuevo = true },
            new Clientes.Models.Cliente { Id = 2, Nombre = "Ana", Apellido = "Sánchez", DuiPasaporte = "01928374-5", Correo = "ana.sanchez@email.com", Telefono = "+503 7234-5678", Nacionalidad = "Salvadoreña", Estado = "Activo", EsNuevo = false },
            new Clientes.Models.Cliente { Id = 3, Nombre = "Roberto", Apellido = "Gómez", DuiPasaporte = "A12345678", Correo = "roberto.gomez@email.com", Telefono = "+1 305-891-2345", Nacionalidad = "Estadounidense", Estado = "Inactivo", EsNuevo = false }
        };

        public IActionResult Index(string? buscar, string? estado, string? tipo, string? fecha)
        {
            // Métricas calculadas dinámicamente sobre la lista real
            ViewBag.TotalClientes = _clientes.Count;
            ViewBag.ClientesActivos = _clientes.Count(c => c.Estado == "Activo");
            ViewBag.NuevosEsteMes = _clientes.Count(c => c.EsNuevo);
            ViewBag.ClientesInactivos = _clientes.Count(c => c.Estado == "Inactivo");

            var consulta = _clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                string termino = buscar.Trim().ToLower();
                consulta = consulta.Where(c => c.Nombre.ToLower().Contains(termino) ||
                                               c.Apellido.ToLower().Contains(termino) ||
                                               c.DuiPasaporte.ToLower().Contains(termino) ||
                                               c.Correo.ToLower().Contains(termino));
            }

            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                consulta = consulta.Where(c => c.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.BuscarActual = buscar;
            ViewBag.EstadoActual = estado ?? "Todos";
            ViewBag.TipoActual = tipo ?? "Todos";
            ViewBag.FechaActual = fecha ?? "Todas";

            return View(consulta.ToList());
        }
    }
}