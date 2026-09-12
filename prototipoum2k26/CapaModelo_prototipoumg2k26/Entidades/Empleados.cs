using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_prototipoumg2k26.Entidades
{
    public class Empleados
    {
        public int IdEmpleado { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int IdEstadoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string DpiEmpleado { get; set; }
        public string NitEmpleado { get; set; }
        public string TelefonoEmpleado { get; set; }
        public string DireccionEmpleado { get; set; }
        public DateTime? FechaNacimientoEmpleado { get; set; }
        public DateTime? FechaContratacionEmpleado { get; set; }
    }
}