namespace Clientes.Models
{
    public class Paquete
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string Duracion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Tipo { get; set; } = "Playa"; 
        public string Estado { get; set; } = "Activo"; 
        public string ImagenUrl { get; set; } = string.Empty;
    }
}