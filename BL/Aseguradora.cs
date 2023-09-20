using DLEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var query = context.AseguradoraGetAll();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = row.IdAseguradora;
                            aseguradora.Nombre = row.Nombre;
                            aseguradora.FechaCreacion = row.FechaCreacion.Value;
                            aseguradora.FechaModificacion = row.FechaModificacion.Value;
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = row.IdUsuario.Value;
                            result.Objects.Add(aseguradora);
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
        public static ML.Result GetById(int IdAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.AseguradoraGetById(IdAseguradora);
                    if (rowsAffected != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        foreach (var item in rowsAffected)
                        {
                            aseguradora.IdAseguradora = item.IdAseguradora;
                            aseguradora.Nombre = item.Nombre;
                            aseguradora.FechaCreacion = item.FechaCreacion.Value;
                            aseguradora.FechaModificacion = item.FechaModificacion.Value;
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = item.IdUsuario.Value;
                            result.Object = aseguradora;
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
        public static ML.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.AseguradoraAdd(
                        aseguradora.Nombre,
                        aseguradora.Usuario.IdUsuario);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al registrar la aseguradora";
                    }
                }
            }
            catch( Exception ex )
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.AseguradoraUpdate(
                        aseguradora.IdAseguradora,
                        aseguradora.Nombre,
                        aseguradora.Usuario.IdUsuario);
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar la aseguradora";
                    }
                }
            }
            catch(Exception ex )
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.AseguradoraDelete(aseguradora.IdAseguradora);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al borrar la aseguradora.";
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
