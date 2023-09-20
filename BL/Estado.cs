using DLEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(int idPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.EstadoGetByIdPais(idPais);
                    if (rowsAffected != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in rowsAffected)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = registro.IdEstado;
                            estado.Nombre = registro.Nombre;
                            result.Objects.Add(estado);
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
                result.Correct=false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
