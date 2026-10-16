namespace Clientes.Models
{
    public class Vuelo
    {
        public int Id { get; set; }
        public string CodigoVuelo { get; set; } = string.Empty;
        public string Aerolinea { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string FechaSalida { get; set; } = string.Empty;
        public string HoraSalida { get; set; } = string.Empty;
        public string HoraLlegada { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Estado { get; set; } = "Activo"; 
    }
}