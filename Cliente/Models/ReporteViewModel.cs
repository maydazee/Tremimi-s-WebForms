using System.Collections.Generic;

namespace Clientes.Models
{
    public class ReporteViewModel
    {
        public string Periodo { get; set; } = "Este mes";
        public string FechaDesde { get; set; } = "01/10/2026";
        public string FechaHasta { get; set; } = "31/10/2026";

        public decimal TotalVentas { get; set; } = 48250;
        public string PorcentajeVentas { get; set; } = "+12% vs mes anterior";

        public int PaquetesVendidos { get; set; } = 34;
        public string PorcentajePaquetes { get; set; } = "+8% vs mes anterior";

        public int ClientesAtendidos { get; set; } = 128;
        public string PorcentajeClientes { get; set; } = "+15% vs mes anterior";

        public int DestinosVisitados { get; set; } = 12;
        public string PorcentajeDestinos { get; set; } = "+5% vs mes anterior";

       
        public List<DetalleReporteItem> DetalleReporte { get; set; } = new List<DetalleReporteItem>();
        public List<ReporteRecienteItem> ReportesRecientes { get; set; } = new List<ReporteRecienteItem>();
    }

    public class DetalleReporteItem
    {
        public string Concepto { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public string Icono { get; set; } = "fa-chart-line";
    }

    public class ReporteRecienteItem
    {
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string FechaGeneracion { get; set; } = string.Empty;
        public string Estado { get; set; } = "Completado";
    }
}
