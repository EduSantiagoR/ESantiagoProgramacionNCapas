using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        //Creamos un metodo que nos permita traer la cadena de conexion
        //configurada dentro de App.config en la CAPA DE PRESENTACION = PL
        public static string GetConnectionString()
        {
            //Para que el siguiente codigo funcione se debe agregar la refencia en esta capa
            //Add --> Reference --> Assemblies --> System.con
            return ConfigurationManager.ConnectionStrings["ESantiagoProgramacionNCapas"].ConnectionString.ToString();
        }

    }
}
