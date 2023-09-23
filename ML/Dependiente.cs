using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Dependiente
    {
        public int IdDependiente { get; set; }
        public ML.Empleado Empleado { get; set; }

        [Required(ErrorMessage ="El campo nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El campo apellido paterno es requerido.")]
        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage ="La fecha de nacimiento es requerida.")]
        [Display(Name ="Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage ="El campo Estado civil es requerido.")]
        [Display(Name ="Estado civil")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage ="El campo Género es requerido")]
        [Display(Name ="Género")]
        public string Genero { get; set; }

        [Required(ErrorMessage ="El campo Teléfono es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage ="El campo RFC es requerido")]
        [Display(Name ="RFC")]
        public string Rfc { get; set; }

        public List<object> Dependientes { get; set; }
    }
}
