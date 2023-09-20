using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DependienteController : Controller
    {
        // GET: Dependiente
        public ActionResult Dependiente()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            empleado.Nombre = "";
            empleado.Empresa.IdEmpresa = 0;
            ML.Result resultEmpleados = BL.Empleado.GetAll(empleado);
            empleado.Empleados = resultEmpleados.Objects; //pasar lista de empleados
            return View(empleado);
        }
        public ActionResult GetDependientes(string numeroEmpleado)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            ML.Result result = BL.Dependiente.GetByNumeroEmpleado(numeroEmpleado);
            dependiente.Dependientes = result.Objects;
            dependiente.Empleado = new ML.Empleado();
            dependiente.Empleado.NumeroEmpleado = numeroEmpleado;
            return View(dependiente);
        }
        public ActionResult Delete(int IdDependiente)
        {
            ML.Result result = BL.Dependiente.Delete(IdDependiente);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Eliminado Correctamente";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar el dependiente";
                return PartialView("Modal");

            }
        }
        public ActionResult Form(string numeroEmpleado, int? idDependiente)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            dependiente.Empleado = new ML.Empleado();
            dependiente.Empleado.NumeroEmpleado = numeroEmpleado;

            if (idDependiente != null)
            {
                ML.Result result = BL.Dependiente.GetById(idDependiente.Value);
                dependiente = (ML.Dependiente)result.Object; //Unboxing
            }

            return View(dependiente);

        }
        [HttpPost]
        public ActionResult Form(ML.Dependiente dependiente)
        {
            if(dependiente.IdDependiente == 0)
            {
                ML.Result result = BL.Dependiente.Add(dependiente);
                if (result.Correct)
                {
                    return RedirectToAction("GetDependientes","Dependiente", new {dependiente.Empleado.NumeroEmpleado});
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar";
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result = BL.Dependiente.Update(dependiente);
                if (result.Correct)
                {
                    return RedirectToAction("GetDependientes","Dependiente", new {dependiente.Empleado.NumeroEmpleado});
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar";
                    return PartialView("Modal");
                }
            }
        }
    }
}