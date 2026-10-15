namespace Paquete.Models
{
    public class Paquetes
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Vuelos { get; set; } = string.Empty;
        public string Hotel { get; set; } = string.Empty;
        public string Transportacion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
    }
}