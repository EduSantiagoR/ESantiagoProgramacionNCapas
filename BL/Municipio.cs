using DLEF;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int idEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.MunicipioGetByIdEstado(idEstado);
                    if (rowsAffected != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in rowsAffected)
                        {
                            ML.Municipio municipio = new ML.Municipio();
                            municipio.IdMunicipio = registro.IdMunicipio;
                            municipio.Nombre = registro.Nombre;
                            result.Objects.Add(municipio);
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
