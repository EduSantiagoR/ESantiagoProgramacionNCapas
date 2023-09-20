using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var query = context.EmpleadoGetAll(empleado.Empresa.IdEmpresa,empleado.Nombre).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var registro in query)
                        {
                            ML.Empleado empleadoObj = new ML.Empleado();
                            empleadoObj.NumeroEmpleado = registro.NumeroEmpleado;
                            empleadoObj.Rfc = registro.RFC;
                            empleadoObj.Nombre = registro.Nombre;
                            empleadoObj.ApellidoPaterno = registro.ApellidoPaterno;
                            empleadoObj.ApellidoMaterno = registro.ApellidoMaterno;
                            empleadoObj.Email = registro.Email;
                            empleadoObj.Telefono = registro.Telefono;
                            empleadoObj.FechaNacimiento = DateTime.Parse(registro.FechaNacimiento.ToString());
                            empleadoObj.Nss = registro.NSS;
                            empleadoObj.FechaIngreso = DateTime.Parse(registro.FechaIngreso.ToString());
                            empleadoObj.Foto = registro.Foto;
                            empleadoObj.Empresa = new ML.Empresa();
                            empleadoObj.Empresa.IdEmpresa = registro.IdEmpresa;
                            empleadoObj.Empresa.Nombre = registro.NombreEmpresa;
                            empleadoObj.Empresa.Telefono = registro.TelefonoEmpresa;
                            result.Objects.Add(empleadoObj);
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
        public static ML.Result Delete(string numeroEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.EmpleadoDelete(numeroEmpleado);
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar.";
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
        public static ML.Result GetById(string numeroEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var query = context.EmpleadoGetById(numeroEmpleado);
                    if(query != null)
                    {
                        foreach( var row in query)
                        {
                            result.Object = new object();
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.NumeroEmpleado = row.NumeroEmpleado;
                            empleado.Rfc = row.RFC;
                            empleado.Nombre = row.Nombre;
                            empleado.ApellidoPaterno = row.ApellidoPaterno;
                            empleado.ApellidoMaterno = row.ApellidoMaterno;
                            empleado.Email = row.Email;
                            empleado.Telefono = row.Telefono;
                            empleado.FechaNacimiento = DateTime.Parse(row.FechaNacimiento.ToString());
                            empleado.Nss = row.NSS;
                            empleado.FechaIngreso = DateTime.Parse(row.FechaIngreso.ToString());
                            empleado.Foto = row.Foto;
                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.IdEmpresa = row.IdEmpresa;
                            empleado.Empresa.Nombre = row.NombreEmpresa;
                            empleado.Empresa.Telefono = row.TelefonoEmpresa;
                            result.Object = empleado;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar este empleado";
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
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.EmpleadoAdd(
                        empleado.NumeroEmpleado,
                        empleado.Rfc,
                        empleado.Nombre,
                        empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno,
                        empleado.Email,
                        empleado.Telefono,
                        empleado.FechaNacimiento,
                        empleado.Nss,
                        empleado.FechaIngreso,
                        empleado.Foto,
                        empleado.Empresa.IdEmpresa);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar al empleado";
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
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new DLEF.ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.EmpleadoUpdate(
                        empleado.NumeroEmpleado,
                        empleado.Rfc,
                        empleado.Nombre,
                        empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno,
                        empleado.Email,
                        empleado.Telefono,
                        empleado.FechaNacimiento,
                        empleado.Nss,
                        empleado.FechaIngreso,
                        empleado.Foto,
                        empleado.Empresa.IdEmpresa);
                    if( rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar.";
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
    }
}
