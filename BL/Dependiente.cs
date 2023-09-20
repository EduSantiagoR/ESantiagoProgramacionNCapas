using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dependiente
    {
        public static ML.Result GetByNumeroEmpleado(string numeroEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var query = context.DependienteGetByNumeroEmpleado(numeroEmpleado);
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var registro in query)
                        {
                            ML.Dependiente dependiente = new ML.Dependiente();
                            dependiente.IdDependiente = registro.IdDependiente;
                            dependiente.Empleado = new ML.Empleado();
                            dependiente.Empleado.NumeroEmpleado = registro.NumeroEmpleado;
                            dependiente.Nombre = registro.Nombre;
                            dependiente.ApellidoPaterno = registro.ApellidoPaterno;
                            dependiente.ApellidoMaterno = registro.ApellidoMaterno;
                            dependiente.FechaNacimiento = DateTime.Parse(registro.FechaNacimiento.ToString());
                            dependiente.EstadoCivil = registro.EstadoCivil;
                            dependiente.Genero = registro.Genero;
                            dependiente.Telefono = registro.Telefono;
                            dependiente.Rfc = registro.RFC;
                            result.Objects.Add(dependiente);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al obtener el dependiente.";
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
        public static ML.Result GetById(int idDependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var query = context.DependienteGetById(idDependiente);
                    if(query != null)
                    {
                        foreach(var dato in query)
                        {
                            result.Object = new object();
                            ML.Dependiente dependiente = new ML.Dependiente();
                            dependiente.IdDependiente = dato.IdDependiente;
                            dependiente.Empleado = new ML.Empleado();
                            dependiente.Empleado.NumeroEmpleado = dato.NumeroEmpleado;
                            dependiente.Nombre = dato.Nombre;
                            dependiente.ApellidoPaterno = dato.ApellidoPaterno;
                            dependiente.ApellidoMaterno = dato.ApellidoMaterno;
                            dependiente.FechaNacimiento = DateTime.Parse(dato.FechaNacimiento.ToString());
                            dependiente.EstadoCivil = dato.EstadoCivil;
                            dependiente.Genero = dato.Genero;
                            dependiente.Telefono = dato.Telefono;
                            dependiente.Rfc = dato.RFC;
                            result.Object = dependiente;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido encontrar el dependiente.";
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
        public static ML.Result Delete(int idDependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.DependienteDelete(idDependiente);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al borrar el dependiente.";
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
        public static ML.Result Update(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.DependienteUpdate(
                        dependiente.IdDependiente,
                        dependiente.Empleado.NumeroEmpleado,
                        dependiente.Nombre,
                        dependiente.ApellidoPaterno,
                        dependiente.ApellidoMaterno,
                        dependiente.FechaNacimiento,
                        dependiente.EstadoCivil,
                        dependiente.Genero,
                        dependiente.Telefono,
                        dependiente.Rfc);
                    if (rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar el dependiente";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.DependienteAdd(
                        dependiente.Empleado.NumeroEmpleado,
                        dependiente.Nombre,
                        dependiente.ApellidoPaterno,
                        dependiente.ApellidoMaterno,
                        dependiente.FechaNacimiento,
                        dependiente.EstadoCivil,
                        dependiente.Genero,
                        dependiente.Telefono,
                        dependiente.Rfc);
                    if(rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar dependiente.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
