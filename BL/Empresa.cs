using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var query = context.EmpresaGetAll().ToList();
                    if(query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach(var registro in  query)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = registro.IdEmpresa;
                            empresa.Nombre = registro.Nombre;
                            empresa.Telefono = registro.Telefono;
                            result.Objects.Add(empresa);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            } 
            return result;
        }
    }
}
