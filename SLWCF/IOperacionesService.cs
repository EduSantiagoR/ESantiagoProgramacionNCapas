using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperacionesService" in both code and config file together.
    [ServiceContract]
    public interface IOperacionesService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        int Suma(int num1, int num2);
        [OperationContract]
        int Resta(int num1, int num2);
        [OperationContract]
        int Multiplicacion(int num1, int num2);
        [OperationContract]
        double Division(double num1, double num2);
    }
}
