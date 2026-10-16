using System;

namespace Clientes.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }
        public string FechaIngreso { get; set; }
        public string Estado { get; set; } // "Activo" o "Inactivo"
    }
}