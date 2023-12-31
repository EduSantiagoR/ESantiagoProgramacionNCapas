﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pais
    {
        [Required(ErrorMessage ="El campo País es requerido.")]
        [Display(Name ="País")]
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public List<object> Paises { get; set; }
        public Pais()
        {

        }
        public Pais(int idPais, string nombre)
        {
            IdPais = idPais;
            Nombre = nombre;
        }
    }
}
