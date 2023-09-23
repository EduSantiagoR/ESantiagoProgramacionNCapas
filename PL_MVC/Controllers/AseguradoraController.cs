using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Aseguradora
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Aseguradora.GetAll();
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            //Consumimos el servicio
            ServiceReferenceAseguradora.ServiceAseguradoraClient service = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
            var result = service.GetAll();

            if (result.Correct)
            {
                aseguradora.Aseguradoras = result.Objects.ToList();
                return View(aseguradora);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Form(int? IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            if(IdAseguradora!= null)
            {
                //ML.Result result = BL.Aseguradora.GetById(IdAseguradora.Value);

                ServiceReferenceAseguradora.ServiceAseguradoraClient service = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
                var result = service.GetById(IdAseguradora.Value);

                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object; //unboxing
                }
                else
                {

                }
            }
            return View(aseguradora);
        }
        public ActionResult Delete(int? IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.IdAseguradora = IdAseguradora.Value;

            //ML.Result result = BL.Aseguradora.Delete(aseguradora);
            //WCF
            ServiceReferenceAseguradora.ServiceAseguradoraClient servicio = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
            var result = servicio.Delete(aseguradora);

            if (result.Correct)
            {
                ViewBag.Message = "Eliminado correctamente.";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Error "+result.ErrorMessage;
                return PartialView("Modal");
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            if(aseguradora.IdAseguradora == 0)
            {
                //ML.Result result = BL.Aseguradora.Add(aseguradora);
                ServiceReferenceAseguradora.ServiceAseguradoraClient service = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
                var result = service.Add(aseguradora);

                if(result.Correct)
                {
                    ViewBag.Mensaje = "Registro éxtitoso.";
                }
                else
                {
                    ViewBag.Mensaje = "Error " + result.ErrorMessage;
                }
            }
            else
            {
                //ML.Result result = BL.Aseguradora.Update(aseguradora);

                ServiceReferenceAseguradora.ServiceAseguradoraClient service = new ServiceReferenceAseguradora.ServiceAseguradoraClient();
                var result = service.Update(aseguradora);

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
    }
}