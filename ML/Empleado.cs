using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public string NumeroEmpleado { get; set; }
        public string Rfc { get; set; }
        [Display(Name ="Nombre del empleado")]
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nss { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Foto { get; set; }
        public ML.Empresa Empresa { get; set; }
        public List<object> Empleados { get; set; }
        public string Accion { get; set; }
    }
}
