using DLEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int idMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.ColoniaGetByIdMunicipio(idMunicipio);
                    if (rowsAffected != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in rowsAffected)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.IdColonia = registro.IdColonia;
                            colonia.Nombre = registro.Nombre;
                            result.Objects.Add(colonia);
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
