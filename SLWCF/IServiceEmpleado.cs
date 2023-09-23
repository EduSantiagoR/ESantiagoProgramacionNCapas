using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceEmpleado" in both code and config file together.
    [ServiceContract]
    public interface IServiceEmpleado
    {
        [OperationContract]
        SLWCF.Result Add(ML.Empleado empleado);
        [OperationContract]
        SLWCF.Result Delete(string numeroEmpleado);
        [OperationContract]
        SLWCF.Result Update(ML.Empleado empleado);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))] //Modelo que tendrá en cuenta para deserializar.
        SLWCF.Result GetById(string numeroEmpleado);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))]
        SLWCF.Result GetAll(ML.Empleado empleado);
    }
}
