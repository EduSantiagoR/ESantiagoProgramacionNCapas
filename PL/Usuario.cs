using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        //Métodos que interactuan con el usuario
        public static void Add()
        {
            //Creamos un objeto nuevo para poder acceder a las propiedades de la clase usuario en la CAPA DE MODELO  = ML
            ML.Usuario usuario = new ML.Usuario();

            //Pedimos al usuario que ingrese los datos
            //usamos el objeto creado anteiormente para acceder a cada una de las propiedades
            Console.WriteLine("Ingresa el nombre del nuevo usuario");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el apellido paterno del nuevo usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el apellido materno del nuevo usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingresa la fecha de nacimiento del nuevo usuario");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el email del nuevo usuario");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingresa el id del rol del nuevo usuario");
            usuario.Rol = new ML.Rol(); //Instanciamos el objeto Rol para guardar datos
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nombre de usuario del nuevo usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingresa el password del nuevo usuario");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingresa el sexo del nuevo usuario");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingresa el numero telefono del nuevo usuario");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingresa el numero de celular del nuevo usuario");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingresa el CURP del nuevo usuario");
            usuario.Curp = Console.ReadLine();

            //En este punto el programa se comunicara con la CAPA DE NEGOCIO = BL
            ML.Result result = BL.Usuario.AddEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("Usuario no agregado "+ result.ErrorMessage);
            }

        }
        public static void Update()
        {
            //Creamos un objeto nuevo para poder acceder a las propiedades de la clase usuario en la CAPA DE MODELO  = ML
            ML.Usuario usuario = new ML.Usuario();

            //Pedimos al usuario que ingrese los datos
            //usamos el objeto creado anteiormente para acceder a cada una de las propiedades
            Console.WriteLine("Ingresa el id del usuario que deseas actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nombre del usuario");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingresa la fecha de nacimiento del usuario");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el email del usuario");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingresa el id del rol del usuario");
            usuario.Rol = new ML.Rol(); //Instanciamos el objeto Rol para guardar datos
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nombre de usuario del usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingresa el password del usuario");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingresa el sexo del usuario");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingresa el numero telefono del usuario");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingresa el numero de celular del usuario");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingresa el CURP del nuevo usuario");
            usuario.Curp = Console.ReadLine();

            //En este punto el programa se comunicara con la CAPA DE NEGOCIO = BL
            ML.Result result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Usuario no actualizado " + result.ErrorMessage);
            }

        }
        public static void Delete()
        {
            //Creamos un objeto nuevo para poder acceder a las propiedades de la clase usuario en la CAPA DE MODELO  = ML
            ML.Usuario usuario = new ML.Usuario();

            //Pedimos al usuario que ingrese los datos
            Console.WriteLine("Ingresa el Id del usuario que deseas eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //En este punto el programa se comunicara con la CAPA DE NEGOCIO = BL
            ML.Result result = BL.Usuario.DeleteEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Usuario no eliminado " + result.ErrorMessage);
            }

        }
        public static void GetAll()
        {
            ML.Result result = new ML.Result();
            //result = BL.Usuario.GetAllEF();
            if (result.Correct)
            {
                foreach(ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("-----------");
                    Console.WriteLine("ID: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Fecha de nacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Nombre de usuario: " + usuario.UserName);
                    Console.WriteLine("Password: " + usuario.Password);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("CURP: "+usuario.Curp);
                    Console.WriteLine("Id Rol: "+usuario.Rol.IdRol);
                    Console.WriteLine("Nombre de rol: "+usuario.Rol.Nombre);
                    Console.WriteLine("-----------");
                }
            }
            else
            {
                Console.WriteLine("Error al consultar los registros.");
            }


        }
        public static void GetById()
        {
            Console.WriteLine("Ingresa el Id del usuario a consultar");
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);
            if(result.Correct)
            {
                //unboxing
                Console.WriteLine("---------------------------");
                Console.WriteLine("ID: "+usuario.IdUsuario);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("Apellido paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Fecha de nacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Nombre de usuario: " + usuario.UserName);
                Console.WriteLine("Password: " + usuario.Password);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("CURP: " + usuario.Curp);
                Console.WriteLine("Id Rol: " + usuario.Rol.IdRol);
                Console.WriteLine("Nombre de rol: " + usuario.Rol.Nombre);
                Console.WriteLine("---------------------------");
            }
            else
            {
                Console.WriteLine("Error "+ result.ErrorMessage);
            }

        }

    }
}
