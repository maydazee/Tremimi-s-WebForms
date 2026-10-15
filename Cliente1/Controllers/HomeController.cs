using Cliente1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Controllers
{
    public class ClienteController : Controller
    {
        private static List<ClienteModel> _clientes = new List<ClienteModel>
        {
            new ClienteModel { Id = 1, Nombre = "Ana Lucía Rodríguez", Correo = "ana.rodriguez@gmail.com", Telefono = "+503 7123 4567", FechaRegistro = "12/09/2026", Estado = "Activo", TipoCliente = "Regular" },
            new ClienteModel { Id = 2, Nombre = "Carlos Eduardo Martínez", Correo = "carlos.martinez@outlook.com", Telefono = "+503 7986 1234", FechaRegistro = "05/09/2026", Estado = "Activo", TipoCliente = "VIP" },
            new ClienteModel { Id = 3, Nombre = "María Fernanda López", Correo = "maria.lopez@gmail.com", Telefono = "+503 7456 9876", FechaRegistro = "01/09/2026", Estado = "Inactivo", TipoCliente = "Regular" },
            new ClienteModel { Id = 4, Nombre = "José Andrés Castillo", Correo = "jose.castillo@hotmail.com", Telefono = "+503 7321 6543", FechaRegistro = "28/08/2026", Estado = "Activo", TipoCliente = "Regular" },
            new ClienteModel { Id = 5, Nombre = "Sofía Valentina Torres", Correo = "sofia.torres@gmail.com", Telefono = "+503 7890 1122", FechaRegistro = "20/08/2026", Estado = "Activo", TipoCliente = "VIP" }
        };

        public IActionResult Index(string? buscar, string? estado, string? tipo)
        {
            var consulta = _clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                string termino = buscar.Trim().ToLower();
                consulta = consulta.Where(c => c.Nombre.ToLower().Contains(termino) ||
                                               c.Correo.ToLower().Contains(termino) ||
                                               c.Telefono.Contains(termino));
            }

            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                consulta = consulta.Where(c => c.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(tipo) && tipo != "Todos")
            {
                consulta = consulta.Where(c => c.TipoCliente.Equals(tipo, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.TotalClientes = _clientes.Count;
            ViewBag.ClientesActivos = _clientes.Count(c => c.Estado == "Activo");
            ViewBag.ClientesInactivos = _clientes.Count(c => c.Estado == "Inactivo");
            ViewBag.NuevosEsteMes = 18;

            ViewBag.BuscarActual = buscar;
            ViewBag.EstadoActual = estado ?? "Todos";
            ViewBag.TipoActual = tipo ?? "Todos";

            return View(consulta.ToList());
        }

        [HttpPost]
        public IActionResult Crear(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = _clientes.Any() ? _clientes.Max(c => c.Id) + 1 : 1;
                cliente.FechaRegistro = DateTime.Now.ToString("dd/MM/yyyy");
                _clientes.Insert(0, cliente);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModificado)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == clienteModificado.Id);
            if (cliente != null)
            {
                cliente.Nombre = clienteModificado.Nombre;
                cliente.Correo = clienteModificado.Correo;
                cliente.Telefono = clienteModificado.Telefono;
                cliente.Estado = clienteModificado.Estado;
                cliente.TipoCliente = clienteModificado.TipoCliente;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
            return RedirectToAction("Index");
        }
    }
}