using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceEmpleado" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceEmpleado.svc or ServiceEmpleado.svc.cs at the Solution Explorer and start debugging.
    public class ServiceEmpleado : IServiceEmpleado
    {
        public SLWCF.Result Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
        public SLWCF.Result Delete(string numeroEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(numeroEmpleado);
            SLWCF.Result resultWcf = new SLWCF.Result();
            resultWcf.Correct = result.Correct;
            resultWcf.ErrorMessage = result.ErrorMessage;
            resultWcf.Objects = result.Objects;
            resultWcf.Ex = result.Ex;
            resultWcf.Object = result.Object;
            return resultWcf;
        }
        public SLWCF.Result Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
        public SLWCF.Result GetById(string numeroEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(numeroEmpleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
        public SLWCF.Result GetAll(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.GetAll(empleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
    }
}
