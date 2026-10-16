using Microsoft.AspNetCore.Mvc;
using Clientes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Controllers
{
    public class InicioController : Controller
    {
        // 1. Datos del módulo de Clientes
        private static List<Clientes.Models.Cliente> _clientes = new List<Clientes.Models.Cliente>
        {
            new Clientes.Models.Cliente { Id = 1, Nombre = "Carlos", Apellido = "Mendoza", DuiPasaporte = "04829102-3", Correo = "carlos.mendoza@email.com", Telefono = "+503 7812-3456", Nacionalidad = "Salvadoreña", Estado = "Activo", EsNuevo = true },
            new Clientes.Models.Cliente { Id = 2, Nombre = "Ana", Apellido = "Sánchez", DuiPasaporte = "01928374-5", Correo = "ana.sanchez@email.com", Telefono = "+503 7234-5678", Nacionalidad = "Salvadoreña", Estado = "Activo", EsNuevo = false },
            new Clientes.Models.Cliente { Id = 3, Nombre = "Roberto", Apellido = "Gómez", DuiPasaporte = "A12345678", Correo = "roberto.gomez@email.com", Telefono = "+1 305-891-2345", Nacionalidad = "Estadounidense", Estado = "Inactivo", EsNuevo = false }
        };

        // 2. Datos simulados del módulo Paquetes / Reservas
        private static int _totalReservas = 3;

        // 3. Datos simulados del módulo Reportes / Cotizaciones
        private static int _totalCotizaciones = 4;

        public IActionResult Index()
        {
            // Métricas calculadas dinámicamente desde las fuentes de datos reales de cada módulo
            var modelo = new Inicio
            {
                TotalClientes = _clientes.Count,                                      // 3 clientes reales
                TotalReservas = _totalReservas,                                       // Conteos del módulo Paquetes
                TotalCotizaciones = _totalCotizaciones,                               // Conteos del módulo Reportes
                CalificacionPromedio = 4.9,                                           // Promedio global
                ReservasConfirmadasSemana = _clientes.Count(c => c.Estado == "Activo"), // 2 activos
                CotizacionesEnviadasSemana = _totalCotizaciones,
                NuevosClientesSemana = _clientes.Count(c => c.EsNuevo),               // 1 cliente nuevo
                CorreosSinLeer = 2,
                ReservasPorConfirmar = 1,
                PagosPendientes = 1,
                CotizacionesPorPagar = 2
            };

            var pendientes = new List<PendienteImportante>
            {
                new PendienteImportante { Titulo = "Confirmar reserva de Carlos Mendoza", CodigoRef = "Reserva #RES-2026-01", Vencimiento = "Vence hoy", TipoIcono = "plane" },
                new PendienteImportante { Titulo = "Enviar cotización a Ana Sánchez", CodigoRef = "Cotización #COT-2026-02", Vencimiento = "Vence mañana", TipoIcono = "user" },
                new PendienteImportante { Titulo = "Seguimiento de pago de Roberto Gómez", CodigoRef = "Reserva #RES-2026-03", Vencimiento = "Vence en 2 días", TipoIcono = "calendar" }
            };

            ViewBag.Pendientes = pendientes;

            return View("~/Views/Home/Inicio.cshtml", modelo);
        }
    }
}