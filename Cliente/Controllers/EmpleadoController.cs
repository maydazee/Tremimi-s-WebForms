using Microsoft.AspNetCore.Mvc;
using Clientes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Controllers
{
    public class EmpleadoController : Controller
    {
        // Lista simulada en memoria
        private static List<Empleado> _empleados = new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Ana López García", Correo = "ana.lopez@amayaway.com", Telefono = "+503 7012 3456", Departamento = "Ventas", FechaIngreso = "10/01/2025", Estado = "Activo" },
            new Empleado { Id = 2, Nombre = "Luis Martínez Pérez", Correo = "luis.martinez@amayaway.com", Telefono = "+503 7123 7890", Departamento = "Reservas", FechaIngreso = "15/02/2025", Estado = "Activo" },
            new Empleado { Id = 3, Nombre = "Claudia Fernández Ruiz", Correo = "claudia.fernandez@amayaway.com", Telefono = "+503 7432 5567", Departamento = "Atención al cliente", FechaIngreso = "03/03/2025", Estado = "Activo" },
            new Empleado { Id = 4, Nombre = "Jorge Ramírez Castillo", Correo = "jorge.ramirez@amayaway.com", Telefono = "+503 7889 1122", Departamento = "Operaciones", FechaIngreso = "20/04/2025", Estado = "Activo" },
            new Empleado { Id = 5, Nombre = "Valentina Torres Silva", Correo = "valentina.torres@amayaway.com", Telefono = "+503 7011 6677", Departamento = "Marketing", FechaIngreso = "12/06/2025", Estado = "Inactivo" },
            new Empleado { Id = 6, Nombre = "Carlos Méndez López", Correo = "carlos.mendez@amayaway.com", Telefono = "+503 7654 3210", Departamento = "Finanzas", FechaIngreso = "18/08/2025", Estado = "Activo" }
        };

        // GET: Empleado/Index
        public IActionResult Index(string buscar, string estado, string departamento)
        {
            var query = _empleados.AsEnumerable();

            // Filtro por texto de búsqueda
            if (!string.IsNullOrEmpty(buscar))
            {
                query = query.Where(e => e.Nombre.Contains(buscar, System.StringComparison.OrdinalIgnoreCase) ||
                                         e.Correo.Contains(buscar, System.StringComparison.OrdinalIgnoreCase) ||
                                         e.Departamento.Contains(buscar, System.StringComparison.OrdinalIgnoreCase));
            }

            // Filtro por estado
            if (!string.IsNullOrEmpty(estado) && estado != "Todos")
            {
                query = query.Where(e => e.Estado.Equals(estado, System.StringComparison.OrdinalIgnoreCase));
            }

            // Filtro por departamento
            if (!string.IsNullOrEmpty(departamento) && departamento != "Todos")
            {
                query = query.Where(e => e.Departamento.Equals(departamento, System.StringComparison.OrdinalIgnoreCase));
            }

            // Métricas para las tarjetas superiores
            ViewBag.TotalEmpleados = _empleados.Count;
            ViewBag.EmpleadosActivos = _empleados.Count(e => e.Estado == "Activo");
            ViewBag.EmpleadosInactivos = _empleados.Count(e => e.Estado == "Inactivo");
            ViewBag.NuevosMes = 6;

            // Mantener valores actuales en la vista
            ViewBag.BuscarActual = buscar;
            ViewBag.EstadoActual = estado ?? "Todos";
            ViewBag.DeptoActual = departamento ?? "Todos";

            // Retorna directamente a la ruta donde tienes tu archivo actual
            return View("~/Views/Home/Empleado.cshtml", query.ToList());
        }

        // POST: Empleado/Crear
        [HttpPost]
        public IActionResult Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Id = _empleados.Any() ? _empleados.Max(e => e.Id) + 1 : 1;
                empleado.FechaIngreso = System.DateTime.Now.ToString("dd/MM/yyyy");
                _empleados.Add(empleado);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Empleado/Editar
        [HttpPost]
        public IActionResult Editar(Empleado empleado)
        {
            var empExistente = _empleados.FirstOrDefault(e => e.Id == empleado.Id);
            if (empExistente != null)
            {
                empExistente.Nombre = empleado.Nombre;
                empExistente.Correo = empleado.Correo;
                empExistente.Telefono = empleado.Telefono;
                empExistente.Departamento = empleado.Departamento;
                empExistente.Estado = empleado.Estado;
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Empleado/Eliminar
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var emp = _empleados.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _empleados.Remove(emp);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}