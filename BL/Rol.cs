using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.RolGetAll();
                    if (rowsAffected != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in rowsAffected)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = registro.IdRol;
                            rol.Nombre = registro.Nombre;
                            result.Objects.Add(rol);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex) 
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
