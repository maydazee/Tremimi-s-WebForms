namespace Clientes.Models
{
    public class Inicio
    {
      
        public int TotalClientes { get; set; } = 128;
        public int TotalReservas { get; set; } = 36;
        public int TotalCotizaciones { get; set; } = 15;
        public double CalificacionPromedio { get; set; } = 4.8;

        public int ReservasConfirmadasSemana { get; set; } = 12;
        public int CotizacionesEnviadasSemana { get; set; } = 8;
        public int NuevosClientesSemana { get; set; } = 3;

        public int CorreosSinLeer { get; set; } = 5;
        public int ReservasPorConfirmar { get; set; } = 2;
        public int PagosPendientes { get; set; } = 1;
        public int CotizacionesPorPagar { get; set; } = 4;
    }

    public class PendienteImportante
    {
        public string Titulo { get; set; } = string.Empty;
        public string CodigoRef { get; set; } = string.Empty;
        public string Vencimiento { get; set; } = string.Empty;
        public string TipoIcono { get; set; } = "plane"; 
    }
}
