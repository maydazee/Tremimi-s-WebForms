namespace Cliente1.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string FechaRegistro { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string TipoCliente { get; set; } = string.Empty;
    }
}
