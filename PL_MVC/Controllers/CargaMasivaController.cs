using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        [HttpGet]
        public ActionResult Cargar()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            return View(result);
        }
        [HttpPost]
        public ActionResult Cargar(ML.Result result)
        {
            HttpPostedFileBase file = Request.Files["Excel"];
            HttpPostedFileBase filetxt = Request.Files["TXT"];
            if (Session["pathExcel"] == null) //Validamos que la sesion esté vacía
            {
                if (file != null)
                {
                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower();
                    string extensionValida = ConfigurationManager.AppSettings["TipoExcel"]; //Se encuentra en AppSettings

                    if (extensionArchivo == extensionValida)
                    {
                        string filePath = Server.MapPath("~/CargaMasiva/") + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                        if (!System.IO.File.Exists(filePath)) //Verificar que el archivo exista
                        {
                            file.SaveAs(filePath);

                            string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filePath;
                            ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);

                            if (resultUsuarios.Correct)
                            {
                                ML.Result resultValidacion = BL.Usuario.ValidarExcel(resultUsuarios.Objects);
                                if (resultValidacion.Objects.Count == 0)
                                {
                                    resultValidacion.Correct = true;
                                    Session["pathExcel"] = filePath; //Capturamos en una variable sesion la ubicacion del nuevo archivo.
                                }
                                return View(resultValidacion);
                            }
                            else
                            {
                                ViewBag.Mensaje = "El excel no contiene registros";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "Favor de seleccionar un archivo .xlsx\nVerifique su archivo.";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "No ha seleccionado ningún archivo";
                }
                return View(result);
            }
            else
            {
                string filePath = Session["pathExcel"].ToString();
                if(filePath != null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filePath;
                    ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);

                    if(resultUsuarios.Correct)
                    {
                        ML.Result resultErrores = new ML.Result();
                        resultErrores.Objects = new List<object>();
                        foreach(ML.Usuario usuario in resultUsuarios.Objects)
                        {
                            ML.Result result1 = BL.Usuario.AddEF(usuario);
                            if(!result1.Correct)
                            {
                                string error = "Ocurrió un error al insertar el registro de " + usuario.UserName + " el error fue "+ result1.Ex.InnerException;
                                resultErrores.Objects.Add(error);
                            }
                            Session["pathExcel"] = null; //Cerramos la sesion cuando termine de agregar
                        }
                        if(resultErrores.Objects.Count > 0)
                        {
                            string pathTxt = Server.MapPath(@"~\Files\logErrores") + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                            using(StreamWriter writer = new StreamWriter(pathTxt))
                            {
                                foreach(string linea in resultErrores.Objects)
                                {
                                    writer.WriteLine(linea);
                                }
                            }
                        }
                    }
                }
            }
            return View(result);
        }
    }
}