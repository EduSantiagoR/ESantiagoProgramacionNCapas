using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CAPA DE MODELO = ML
namespace ML
{
    public class Usuario
    {
        //Propiedades
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage ="El campo Nombre es requerido.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido paterno es requerido.")]
        [StringLength(50)]
        [Display(Name="Apellido paterno")]
        public string ApellidoPaterno { get; set; }
        [StringLength(50)]
        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El campo Fecha de nacimiento es requerido.")]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{O:mm-dd-aaaa}",ApplyFormatInEditMode =true)]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo Email es requerido.")]
        [StringLength(50)]
        public string Email { get; set; }
        public ML.Rol Rol { get; set; }
        [Required(ErrorMessage = "El campo Nombre de usuario es requerido.")]
        [StringLength(50)]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es requerido.")]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El campo Sexo es requerido.")]
        [StringLength(2)]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "El número telefónico no es válido.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo Celular es requerido.")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "El número de célular no es válido.")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El campo Curp es requerido.")]
        [StringLength(18)]
        public string Curp { get; set; }
        public List<object> Usuarios { get; set; }
        public ML.Direccion Direccion { get; set; }
        public string Imagen { get; set; }
        public bool Status { get; set; }
    }
}
