using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        [Required(ErrorMessage ="El campo Calle es requerido.")]
        public string Calle { get; set; }
        [Display(Name ="Número interior")]
        public string NumeroInterior { get; set; }
        [Display(Name ="Número exterior")]
        public string NumeroExterior { get; set; }
        public ML.Colonia Colonia { get; set; }
    }
}
