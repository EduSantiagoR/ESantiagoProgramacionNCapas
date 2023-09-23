using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;


namespace SLWebApi.Controllers
{
    [RoutePrefix("api/empleado")]
    public class EmpleadoController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
        [Route("{numeroEmpleado}")]
        [HttpPut]
        public IHttpActionResult Update(string numeroEmpleado, [FromBody]ML.Empleado empleado)
        {
            empleado.NumeroEmpleado = numeroEmpleado;
            ML.Result result = BL.Empleado.Update(empleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
        [Route("{numeroEmpleado}")]
        [HttpDelete]
        public IHttpActionResult Delete(string numeroEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(numeroEmpleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
    }
}
