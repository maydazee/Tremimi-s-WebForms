namespace Clientes.Models
{
    public class Promocion
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string AplicaA { get; set; } = "Paquetes turísticos";
        public int DescuentoPorcentaje { get; set; }
        public string FechaInicio { get; set; } = string.Empty;
        public string FechaFin { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activa"; 
        public string ImagenUrl { get; set; } = string.Empty;
    }
}