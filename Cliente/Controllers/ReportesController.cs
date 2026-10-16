using Microsoft.AspNetCore.Mvc;
using Clientes.Models;
using System.Collections.Generic;

namespace Clientes.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult Index(string? periodo, string? desde, string? hasta)
        {
            var model = new ReporteViewModel
            {
                Periodo = string.IsNullOrEmpty(periodo) ? "Este mes" : periodo,
                FechaDesde = string.IsNullOrEmpty(desde) ? "01/10/2026" : desde,
                FechaHasta = string.IsNullOrEmpty(hasta) ? "31/10/2026" : hasta
            };

            if (model.Periodo == "Mes anterior")
            {
                model.TotalVentas = 43000;
                model.PaquetesVendidos = 30;
                model.ClientesAtendidos = 110;
                model.DestinosVisitados = 10;
            }
            else if (model.Periodo == "Año actual")
            {
                model.TotalVentas = 385000;
                model.PaquetesVendidos = 290;
                model.ClientesAtendidos = 950;
                model.DestinosVisitados = 24;
            }

            model.DetalleReporte = new List<DetalleReporteItem>
            {
                new DetalleReporteItem { Concepto = "Venta total de paquetes turísticos", Valor = "$ 32,400", Icono = "fa-suitcase" },
                new DetalleReporteItem { Concepto = "Venta de boletos aéreos independientes", Valor = "$ 12,850", Icono = "fa-plane" },
                new DetalleReporteItem { Concepto = "Reservas hoteleras directas", Valor = "$ 3,000", Icono = "fa-hotel" },
                new DetalleReporteItem { Concepto = "Comisiones netas generadas", Valor = "$ 6,210", Icono = "fa-percentage" }
            };

            model.ReportesRecientes = new List<ReporteRecienteItem>
            {
                new ReporteRecienteItem { Nombre = "Reporte Mensual de Ventas Octubre", Tipo = "Consolidado Ventas", FechaGeneracion = "15/10/2026", Estado = "Completado" },
                new ReporteRecienteItem { Nombre = "Análisis de Destinos Preferidos Q3", Tipo = "Métricas de Destinos", FechaGeneracion = "01/10/2026", Estado = "Completado" },
                new ReporteRecienteItem { Nombre = "Rendimiento de Promociones de Verano", Tipo = "Marketing & Promociones", FechaGeneracion = "28/09/2026", Estado = "Completado" }
            };

            // Apunta exactamente al archivo Reporte.cshtml dentro de Views/Home
            return View("~/Views/Home/Reporte.cshtml", model);
        }
    }
}