using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("¿Qué deseas hacer?");
            //Console.WriteLine("1. Ingresar nuevo usuario.");
            //Console.WriteLine("2. Actualizar un registro.");
            //Console.WriteLine("3. Eliminar un registro.");
            //Console.WriteLine("4. Consultar la tabla Usuario.");
            //Console.WriteLine("5. Buscar un registro por ID.");

            BL.Usuario.CargaMasivaTxt();

            //string opcion = Console.ReadLine();
            //if (opcion == "1")
            //{
            //    PL.Usuario.Add();
            //}
            //else if (opcion == "2")
            //{
            //    PL.Usuario.Update();
            //}
            //else if (opcion == "3")
            //{
            //    PL.Usuario.Delete();
            //}
            //else if (opcion == "4")
            //{
            //    PL.Usuario.GetAll();
            //}
            //else if (opcion == "5")
            //{
            //    PL.Usuario.GetById();
            //}
            //else
            //{
            //    Console.WriteLine("Opcion no válida.");
            //}
            //Console.ReadKey();
        }
    }
}
