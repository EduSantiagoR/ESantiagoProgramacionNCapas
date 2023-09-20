using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DLEF;
using System.ComponentModel.DataAnnotations;
using Microsoft.Win32;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Data.OleDb;

//CAPA DE NEGOCIO = BL
namespace BL
{
    public class Usuario
    {
        //Creamos un método para agragar el nuevo registro. Este contendrá todas las sentencias SQL necesarias, así como la conexión.
        public static ML.Result Add(ML.Usuario usuario)
        {
            //Esta variable servirá para mostrar un mensaje de exito o error al usuario.
            ML.Result result = new ML.Result();

            try
            {
                //Todo lo que se ejecute dentro de using se libera al final.
                //Creamos un objeto para acceder a los metodos de SqlConnection
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //Creamos un string que contengan las instrucciones que deseamos que se ejecuten
                    string query = "INSERT INTO Usuario VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Correo, @Altura, @Peso)";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlParameter[] collection = new SqlParameter[7];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    collection[3].Value = usuario.FechaNacimiento;
                    collection[4] = new SqlParameter("@Correo", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("@Altura", SqlDbType.Float);


                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int filasAfectaddas = cmd.ExecuteNonQuery();
                    if(filasAfectaddas > 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Datos agregados de manera exitosa.";
                    }
                    else
                    {
                        result.Correct= false;
                        result.ErrorMessage = "Error al agregar el usuario.";
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
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string queryUpdate = "UPDATE Usuario SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno ,[ApellidoMaterno] = @ApellidoMaterno, [FechaNacimiento] = @FechaNacimiento,[Correo] = @Correo, [Altura] = @Altura, [Peso] = @Peso WHERE [IdUsuario] = @IdUsuario";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = queryUpdate;

                    SqlParameter[] collection = new SqlParameter[8];
                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    collection[3].Value = usuario.FechaNacimiento;
                    collection[4] = new SqlParameter("@Correo", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("@Altura", SqlDbType.Float);

                    collection[7] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[7].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Acualización correcta.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar.";
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
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string queryDelete = "DELETE FROM Usuario WHERE [IdUsuario] = @IdUsuario";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = queryDelete;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el registro.";
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
        public static ML.Result GetAll()
        {
            //Mensaje para el usuario
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se ejecute dentro de using se libera al final.
                //Creamos un objeto para acceder a los metodos de SqlConnection
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //Creamos un string que contengan las instrucciones que deseamos que se ejecuten
                    string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Correo, Altura, Peso FROM Usuario";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable tablaUsuario = new DataTable();

                    adapter.Fill(tablaUsuario);

                    
                    if (tablaUsuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach(DataRow row in  tablaUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = DateTime.Parse(row[4].ToString());
                            usuario.Email = row[5].ToString();


                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
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
        public static ML.Result GetById(ML.Usuario usuario)
        {
            //Mensaje para el usuario.
            ML.Result result = new ML.Result();

            try
            {
                //Todo lo que se ejecute dentro de using se libera al final.
                //Creamos un objeto para acceder a los metodos de SqlConnection
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //Creamos un string que contengan las instrucciones que deseamos que se ejecuten
                    string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Correo, Altura, Peso from Usuario WHERE [IdUsuario] = @IdUsuario";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable tablaUsuario = new DataTable();

                    adapter.Fill(tablaUsuario);


                    if (tablaUsuario.Rows.Count > 0)
                    {
                        DataRow row = tablaUsuario.Rows[0];

                        ML.Usuario usuarioResult = new ML.Usuario();

                        usuarioResult.IdUsuario = int.Parse(row[0].ToString());
                        usuarioResult.Nombre = row[1].ToString();
                        usuarioResult.ApellidoPaterno = row[2].ToString();
                        usuarioResult.ApellidoMaterno = row[3].ToString();
                        usuarioResult.FechaNacimiento = DateTime.Parse(row[4].ToString());
                        usuarioResult.Email = row[5].ToString();


                        //boxing
                        result.Object = usuarioResult;

                        result.Correct = true;
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
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                //Todo lo que se ejecute dentro de using se libera al final.
                //Creamos un objeto para acceder a los metodos de SqlConnection
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //Para el uso de Stored Procedures solo se declara el nombre del procedimiento
                    string query = "UsuarioAdd";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[8];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    collection[3].Value = usuario.FechaNacimiento;
                    collection[4] = new SqlParameter("@Correo", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("@Altura", SqlDbType.Float);

                    collection[7] = new SqlParameter("@IdRol", SqlDbType.Int);
                    collection[7].Value = usuario.Rol.IdRol;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int filasAfectaddas = cmd.ExecuteNonQuery();
                    if (filasAfectaddas > 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Datos agregados de manera exitosa.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar el usuario.";
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
        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string queryUpdate = "UsuarioUpdate";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = queryUpdate;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[9];
                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    collection[3].Value = usuario.FechaNacimiento;
                    collection[4] = new SqlParameter("@Correo", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;

                    collection[7] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[7].Value = usuario.IdUsuario;
                    collection[8] = new SqlParameter("@IdRol", SqlDbType.Int);
                    collection[8].Value = usuario.Rol.IdRol;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Acualización correcta.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar.";
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
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string queryDelete = "UsuarioDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = queryDelete;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el registro.";
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
        public static ML.Result GetAllSP()
        {
            //Mensaje para el usuario
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //Declaramos el procedimiento almacenado
                    string query = "UsuarioGetAll";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable tablaUsuario = new DataTable();

                    adapter.Fill(tablaUsuario);


                    if (tablaUsuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in tablaUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = DateTime.Parse(row[4].ToString());
                            usuario.Email = row[5].ToString();

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = int.Parse(row[8].ToString());

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
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
        public static ML.Result GetByIdSP(ML.Usuario usuario)
        {
            //Mensaje para el usuario.
            ML.Result result = new ML.Result();

            try
            {
                //Todo lo que se ejecute dentro de using se libera al final.
                //Creamos un objeto para acceder a los metodos de SqlConnection
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //Procedimiento almacenado
                    string query = "UsuarioGetById";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable tablaUsuario = new DataTable();

                    adapter.Fill(tablaUsuario);


                    if (tablaUsuario.Rows.Count > 0)
                    {
                        DataRow row = tablaUsuario.Rows[0];

                        ML.Usuario usuarioResult = new ML.Usuario();

                        usuarioResult.IdUsuario = int.Parse(row[0].ToString());
                        usuarioResult.Nombre = row[1].ToString();
                        usuarioResult.ApellidoPaterno = row[2].ToString();
                        usuarioResult.ApellidoMaterno = row[3].ToString();
                        usuarioResult.FechaNacimiento = DateTime.Parse(row[4].ToString());
                        usuarioResult.Email = row[5].ToString();
                        
                        usuarioResult.Rol = new ML.Rol();
                        usuarioResult.Rol.IdRol = int.Parse(row[8].ToString());

                        //boxing
                        result.Object = usuarioResult;

                        result.Correct = true;
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
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int));
                    int rowAffected = context.UsuarioAdd(
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.FechaNacimiento,
                        usuario.Email,
                        usuario.Rol.IdRol,
                        usuario.UserName,
                        usuario.Password,
                        usuario.Sexo,
                        usuario.Telefono,
                        usuario.Celular,
                        usuario.Curp,
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia,
                        usuario.Imagen,
                        filasAfectadas);
                   
                    if(rowAffected > 0)
                    {
                        result.Correct =true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Usuario no agregado.";
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
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int));
                    int rowAffected = context.UsuarioUpdate(
                        usuario.IdUsuario, 
                        usuario.Nombre, 
                        usuario.ApellidoPaterno, 
                        usuario.ApellidoMaterno, 
                        usuario.FechaNacimiento, 
                        usuario.Email, 
                        usuario.Rol.IdRol, 
                        usuario.UserName, 
                        usuario.Password, 
                        usuario.Sexo, 
                        usuario.Telefono, 
                        usuario.Celular, 
                        usuario.Curp,
                        usuario.Imagen,
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia,
                        filasAfectadas);
                    if (rowAffected > 0)
                    {
                        result.Correct =true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Usuario no actualizado.";
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
        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int));
                    int rowAffected = context.UsuarioDelete(usuario.IdUsuario, filasAfectadas);
                    if(rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct =false;
                        result.ErrorMessage = "Error al eliminar.";
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
        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.UsuarioGetAll(usuario.Nombre,usuario.ApellidoPaterno).ToList();
                    if (rowsAffected != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var registro in rowsAffected)
                        {
                            ML.Usuario usuarioObj = new ML.Usuario();
                            usuarioObj.IdUsuario = registro.IdUsuario;
                            usuarioObj.Nombre = registro.Nombre;
                            usuarioObj.ApellidoPaterno = registro.ApellidoPaterno;
                            usuarioObj.ApellidoMaterno = registro.ApellidoMaterno;
                            usuarioObj.FechaNacimiento = (DateTime)registro.FechaNacimiento;
                            usuarioObj.Email = registro.Email;
                            usuarioObj.UserName = registro.UserName;
                            usuarioObj.Password = registro.Password;
                            usuarioObj.Sexo = registro.Sexo;
                            usuarioObj.Telefono = registro.Telefono;
                            usuarioObj.Celular = registro.Celular;
                            usuarioObj.Curp = registro.CURP;
                            usuarioObj.Imagen = registro.Imagen;
                            usuarioObj.Rol = new ML.Rol();
                            usuarioObj.Rol.IdRol = registro.IdRol;
                            usuarioObj.Rol.Nombre = registro.NombreRol;
                            usuarioObj.Status = registro.Status;
                            usuarioObj.Direccion = new ML.Direccion();
                            usuarioObj.Direccion.IdDireccion = registro.IdDirección;
                            usuarioObj.Direccion.Calle = registro.Calle;
                            usuarioObj.Direccion.NumeroExterior = registro.NumeroExterior;
                            usuarioObj.Direccion.NumeroInterior = registro.NumeroInterior;
                            usuarioObj.Direccion.Colonia = new ML.Colonia();
                            usuarioObj.Direccion.Colonia.IdColonia = registro.IdColonia;
                            usuarioObj.Direccion.Colonia.Nombre = registro.NombreColonia;
                            usuarioObj.Direccion.Colonia.CodigoPostal = registro.CodigoPostal;
                            usuarioObj.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioObj.Direccion.Colonia.Municipio.IdMunicipio = registro.IdMunicipio;
                            usuarioObj.Direccion.Colonia.Municipio.Nombre = registro.NombreMunicipio;
                            usuarioObj.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.IdEstado = registro.IdEstado;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Nombre = registro.NombreEstado;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.IdPais = registro.IdPais;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.Nombre = registro.NombrePais;
                            result.Objects.Add(usuarioObj);
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
        public static ML.Result GetByIdEF(int Idusuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.IdUsuario = Idusuario;
                    var query = context.UsuarioGetById(usuario.IdUsuario);

                    if(query != null)
                    {
                        result.Object = new object();
                        foreach(var item in query)
                        {
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.FechaNacimiento = DateTime.Parse(item.FechaNacimiento.ToString());
                            usuario.Email = item.Email;
                            usuario.Sexo = item.Sexo;
                            usuario.Telefono = item.Telefono;
                            usuario.Celular = item.Celular;
                            usuario.Curp = item.CURP;
                            usuario.UserName = item.UserName;
                            usuario.Password = item.Password;
                            usuario.Imagen = item.Imagen;
                            usuario.Status = item.Status;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = item.IdRol;
                            usuario.Rol.Nombre = item.NombreRol;
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = item.IdDirección;
                            usuario.Direccion.Calle = item.Calle;
                            usuario.Direccion.NumeroExterior = item.NumeroExterior;
                            usuario.Direccion.NumeroInterior = item.NumeroInterior;
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = item.IdColonia;
                            usuario.Direccion.Colonia.Nombre = item.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = item.CodigoPostal;
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = item.NombreMunicipio;
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = item.NombreEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = item.NombrePais;
                            result.Object = usuario;
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Error al consultar este ID.");
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
        public static ML.Result ChangeStatus(int idUsuario, bool status)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var rowsAffected = context.UsuarioChangeStatus(idUsuario,status);
                    if (rowsAffected > 0)
                    {
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
        public static ML.Result ValidarUsuario(string userName, string password)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var query = context.UsuarioGetByUserName(userName,password).ToList();
                    if(query.Count() > 0)
                    {
                        result.Correct=true;
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
        public static void CargaMasivaTxt()
        {
            ML.Result result = new ML.Result();
            try
            {
                string file = @"C:\Users\ALIEN 15\Documents\Eduardo Santiago Ramírez\ESantiagoProgramacionNCapas\PL_MVC\Files\CargaMasivaUsuario.txt";
                if (File.Exists(file))
                {
                    StreamReader streamReader = new StreamReader(file);
                    string line = streamReader.ReadLine();
                    while((line = streamReader.ReadLine()) != null)
                    {
                        string[] row = line.Split('|');
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Nombre = row[0];
                        usuario.ApellidoPaterno = row[1];
                        if (row[2] == "null")
                        {
                            usuario.ApellidoMaterno = null;
                        }
                        else
                        {
                            usuario.ApellidoMaterno = row[2];
                        }
                        usuario.FechaNacimiento = DateTime.Parse(row[3]);
                        usuario.Email = row[4];
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = int.Parse(row[5]);
                        usuario.UserName = row[6];
                        usuario.Password = row[7];
                        usuario.Sexo = row[8];
                        usuario.Telefono = row[9];
                        usuario.Celular = row[10];
                        usuario.Curp = row[11];
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Calle = row[12];
                        usuario.Direccion.NumeroInterior = row[13];
                        usuario.Direccion.NumeroExterior = row[14];
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = int.Parse(row[15]);
                        if (row[16] == "null")
                        {
                            usuario.Imagen = null;
                        }
                        else
                        {
                            usuario.Imagen = row[16];
                        }
                        BL.Usuario.AddEF(usuario);
                        Console.WriteLine("Registro agregado");
                    }
                    result.Correct = true;
                }
                else
                {
                    result.ErrorMessage = "No se ha encontrado el archivo.";
                    result.Correct = false;
                }
            }
            catch( Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
        }
        public static ML.Result LeerExcel(string connectionString)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using(OleDbCommand cmd = new OleDbCommand()) //Probable error
                    {
                        cmd.CommandText = query; //Query
                        cmd.Connection = context; //conexion

                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = cmd;

                        DataTable tablaUsurio = new DataTable();
                        adapter.Fill(tablaUsurio);

                        if(tablaUsurio.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach(DataRow row in tablaUsurio.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.Nombre = row[0].ToString();
                                usuario.ApellidoPaterno = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();
                                usuario.FechaNacimiento = DateTime.Parse(row[3].ToString());
                                usuario.Email = row[4].ToString();
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[5].ToString());
                                usuario.UserName = row[6].ToString();
                                usuario.Password = row[7].ToString();
                                usuario.Sexo = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.Curp = row[11].ToString();
                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle = row[12].ToString();
                                usuario.Direccion.NumeroInterior = row[13].ToString();
                                usuario.Direccion.NumeroExterior = row[14].ToString();
                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia = int.Parse(row[15].ToString());
                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }
                        result.Object = tablaUsurio; //pasar la tabla a un object de result
                        if(tablaUsurio.Rows.Count > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registron en el Excel.";
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                result.Correct = false;
                result.ErrorMessage= ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result ValidarExcel(List<object> usuarios)
        {
            ML.Result result = new ML.Result();
            try
            {
                result.Objects = new List<object>(); //para almacenar los registros erroneos 
                int i = 1;
                foreach (ML.Usuario usuario  in usuarios)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;
                    if(usuario.Nombre == "") { error.Mensaje += "Ingresa el nombre."; }
                    if(usuario.ApellidoPaterno == "") { error.Mensaje += "Ingresa el apellido paterno."; }
                    if(usuario.FechaNacimiento.ToString() == "") { error.Mensaje += "Ingresa la fecha de nacimiento."; }
                    if(usuario.Email == "") { error.Mensaje += "Ingresa el email."; }
                    if(usuario.Rol.IdRol.ToString() == "") { error.Mensaje += "Ingresa el Rol."; }
                    if(usuario.UserName == "") { error.Mensaje += "Ingresa el user name."; }
                    if(usuario.Password == "") { error.Mensaje += "Ingresa el password."; }
                    if(usuario.Sexo == "") { error.Mensaje += "Ingresa el sexo."; }
                    if(usuario.Telefono == "") { error.Mensaje += "Ingresa el telefono."; }
                    if(usuario.Celular == "") { error.Mensaje += "Ingresa el celular."; }
                    if(usuario.Curp == "") { error.Mensaje += "Ingresa el curp."; }
                    if(usuario.Direccion.Calle == "") { error.Mensaje += "Ingresa la calle."; }
                    if(usuario.Direccion.NumeroInterior == "") { error.Mensaje += "Ingresa el numero interior."; }
                    if(usuario.Direccion.NumeroExterior == "") { error.Mensaje += "Ingresa el numero exterior."; }
                    if(usuario.Direccion.Colonia.IdColonia.ToString() == "") { error.Mensaje += "Ingresa la colonia."; }

                    if(error.Mensaje != null)
                    {
                        result.Objects.Add(error);
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
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    DLEF.Usuario usuarioNuevo = new DLEF.Usuario();
                    usuarioNuevo.Nombre = usuario.Nombre;
                    usuarioNuevo.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioNuevo.ApellidoMaterno = usuario.ApellidoPaterno;
                    usuarioNuevo.FechaNacimiento = usuario.FechaNacimiento;
                    //usuarioNuevo.Correo = usuario.Email;

                    usuarioNuevo.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioNuevo);
                    context.SaveChanges();
                }
                result.Correct=true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var query = (from a in context.Usuarios where a.IdUsuario == usuario.IdUsuario select a).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.FechaNacimiento = usuario.FechaNacimiento;
                        //query.Correo = usuario.Email;

                        query.IdRol = usuario.Rol.IdRol;
                        context.SaveChanges();
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No se pudo actualizar. "+usuario.IdUsuario;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var query = (from a in context.Usuarios where a.IdUsuario == usuario.IdUsuario select a).First();
                    context.Usuarios.Remove(query);
                    context.SaveChanges();
                }
                result.Correct=true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var query = (from Users in context.Usuarios
                                 join Rol in context.Rols on Users.IdRol equals Rol.IdRol
                                 select new
                                 {
                                     IdUsuario = Users.IdUsuario,
                                     Nombre = Users.Nombre,
                                     ApellidoPaterno = Users.ApellidoPaterno,
                                     ApellidoMaterno = Users.ApellidoMaterno,
                                     FechaNacimiento = Users.FechaNacimiento,
                                     //Correo = Users.Correo,
                                     //Altura = Users.Altura,
                                     //Peso = Users.Peso,
                                     IdRol = Users.IdRol,
                                     NombreRol = Rol.Nombre
                                 });
                    result.Objects = new List<object>();
                    if(query != null && query.ToList().Count > 0)
                    {
                        foreach( var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.FechaNacimiento = (DateTime)item.FechaNacimiento;
                            //usuario.Email = item.Correo;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = item.IdRol;
                            usuario.Rol.Nombre = item.NombreRol;
                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetByIdLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ESantiagoProgramacionNCapasEntities1 context = new ESantiagoProgramacionNCapasEntities1())
                {
                    var query = (from Users in context.Usuarios
                                 join Rol in context.Rols on Users.IdRol equals Rol.IdRol
                                 where Users.IdUsuario == usuario.IdUsuario
                                 select new
                                 {
                                     IdUsuario = Users.IdUsuario,
                                     Nombre = Users.Nombre,
                                     ApellidoPaterno = Users.ApellidoPaterno,
                                     ApellidoMaterno = Users.ApellidoMaterno,
                                     FechaNacimiento = Users.FechaNacimiento,
                                     
                                     IdRol = Users.IdRol,
                                     NombreRol = Rol.Nombre
                                 });
                    if (query != null)
                    {
                        result.Object = new List<object>();
                        foreach (var registro in query)
                        {
                            usuario.IdUsuario = registro.IdUsuario;
                            usuario.Nombre = registro.Nombre;
                            usuario.ApellidoPaterno = registro.ApellidoPaterno;
                            usuario.ApellidoMaterno = registro.ApellidoMaterno;
                            usuario.FechaNacimiento = (DateTime)registro.FechaNacimiento;
                            //usuario.Email = registro.Correo;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = registro.IdRol;
                            usuario.Rol.Nombre = registro.NombreRol;
                            result.Object = usuario;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar el ID";
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
