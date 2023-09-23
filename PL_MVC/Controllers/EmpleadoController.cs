using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]// GET: Empleado
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            empleado.Empresa.IdEmpresa = 0;
            empleado.Nombre = "";
            //ML.Result result = BL.Empleado.GetAll(empleado);
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            //WCF
            ServiceReferenceEmpleado.ServiceEmpleadoClient service = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
            var result = service.GetAll(empleado);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects.ToList();
                empleado.Empresa.Empresas = resultEmpresa.Objects; //Pase la lista
                return View(empleado);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult GetAll(ML.Empleado empleado)
        {
            if(empleado.Nombre == null)
            {
                empleado.Nombre = "";
            }
            //ML.Result result = BL.Empleado.GetAll(empleado);
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            ServiceReferenceEmpleado.ServiceEmpleadoClient service = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
            var result = service.GetAll(empleado);

            if (result.Correct)
            {
                empleado.Empleados = result.Objects.ToList();
                empleado.Empresa.Empresas = resultEmpresa.Objects; //Pase la lista de empresas
                return View(empleado);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(string numeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = numeroEmpleado;

            //ML.Result result = BL.Empleado.Delete(empleado.NumeroEmpleado);

            //WCF
            ServiceReferenceEmpleado.ServiceEmpleadoClient service = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
            var result = service.Delete(empleado.NumeroEmpleado);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Eliminado de manera éxitosa.";
                return View("Modal");
            }
            else
            {
                ViewBag.Mensaje = "Error " + result.ErrorMessage;
                return View("Modal");
            }
        }
        [HttpGet]
        public ActionResult Form(string numeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            if (numeroEmpleado != null) //Update
            {
                //ML.Result result = BL.Empleado.GetById(numeroEmpleado);

                //WCF
                ServiceReferenceEmpleado.ServiceEmpleadoClient service = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
                var result = service.GetById(numeroEmpleado);

                if (result.Correct)
                {
                    empleado = (ML.Empleado)result.Object; //unboxing
                    empleado.Empresa.Empresas = resultEmpresa.Objects; //Pase la lista de empresas
                    empleado.Accion = "Update";
                }
            }
            else //Agrega
            {
                empleado.Empresa.Empresas = resultEmpresa.Objects; //Pase la lista de empresas
                empleado.Accion = "Add";
            }
            return View(empleado);
        }
        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            HttpPostedFileBase file = Request.Files["Imagen"];
            if (file.ContentLength > 0)
            {
                empleado.Foto = ConvertirABase64(file);
            }
            if (empleado.Accion == "Add") //ULTIMO CHEQUEO QUEDO AQUI, HAY QUE DEPURAR PARA AGREGAR
            {
                //ML.Result result = BL.Empleado.Add(empleado);

                //WCF
                ServiceReferenceEmpleado.ServiceEmpleadoClient service = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
                var result = service.Add(empleado);

                if(result.Correct)
                {
                    ViewBag.Mensaje = "Registro éxitoso.";
                }
                else
                {
                    ViewBag.Mensaje = "Error " + result.ErrorMessage;
                }
            }
            else
            {
                //ML.Result result = BL.Empleado.Update(empleado);

                //WCF
                ServiceReferenceEmpleado.ServiceEmpleadoClient service = new ServiceReferenceEmpleado.ServiceEmpleadoClient();
                var result = service.Update(empleado);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Actualización éxitosa.";
                }
                else
                {
                    ViewBag.Mensaje = "Error " + result.ErrorMessage;
                }
            }
            return View("Modal");
        }
        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
    }
}