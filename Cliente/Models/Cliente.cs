namespace Clientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string DuiPasaporte { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";
        public bool EsNuevo { get; set; } = false;
    }
}