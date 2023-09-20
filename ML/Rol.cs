using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Rol
    {
        [Required(ErrorMessage ="El campo Rol asignado es requerido.")]
        [Display(Name ="Rol asignado")]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public List<object> Roles { get; set; }
    }
}
