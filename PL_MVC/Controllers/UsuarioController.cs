using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet] //Métodos GET
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if(result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            if(usuario.Nombre == null)
            {
                usuario.Nombre = "";
            }
            if(usuario.ApellidoPaterno == null)
            {
                usuario.ApellidoPaterno = "";
            }
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            
            ML.Result result = BL.Usuario.DeleteEF(usuario);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Registro eliminado";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Mensaje = "Error " + result.ErrorMessage;
                return PartialView("Modal");
            }
        }
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new Pais();

            ML.Result resultRol = BL.Rol.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();
            if (IdUsuario != null) //Actualiza
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                    usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;
                }
            }
            else //Agrega
            {
                usuario.Rol.Roles = resultRol.Objects; //Pase la lista de Roles
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects; //PAsar lista de paises
            }
            return View(usuario);
        }
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult EstadoGetByIdPais(int idPais)
        {
            ML.Result resultEstado = BL.Estado.GetByIdPais(idPais);
            return Json(resultEstado.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MunicipioGetByIdEstado(int idEstado)
        {
            ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(idEstado);
            return Json(resultMunicipio.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ColoniaGetByIdMunicipio(int idMunicipio)
        {
            ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(idMunicipio);
            return Json(resultColonia.Objects, JsonRequestBehavior.AllowGet);
        }
        [HttpPost] //Métodos POST
        public ActionResult Form(ML.Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (file.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirABase64(file);
                }
                if (usuario.IdUsuario == 0)
                {
                    ML.Result result = BL.Usuario.AddEF(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha registrado el nuevo usuario";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error " + result.ErrorMessage;
                    }
                }
                else
                {
                    ML.Result result = BL.Usuario.UpdateEF(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha actualizado el usuario";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error " + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                ML.Result resultRol = BL.Rol.GetAll(); //Volver a cargar los DDL
                ML.Result resultPais = BL.Pais.GetAll();
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;
                return View(usuario);
            }
        }
        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
        public JsonResult ChangeStatus(int IdUsuario, bool Status)
        {
            ML.Result result = BL.Usuario.ChangeStatus(IdUsuario, Status);
            return Json(null);
        }
        public ActionResult ValidarUsuario(string username, string password)
        {
            ML.Result result = BL.Usuario.ValidarUsuario(username, password);
            if (result.Correct)
            {
                ViewBag.Correct = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Correct = false;
                ViewBag.Mensaje = "El nombre de usuario o la contraseña son incorrectos.";
                return View("Modal");
            }
        }
    }
}