using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OperacionesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OperacionesService.svc or OperacionesService.svc.cs at the Solution Explorer and start debugging.
    public class OperacionesService : IOperacionesService
    {
        public double Division(double num1, double num2)
        {
            return num1 / num2;
        }
        public void DoWork()
        {
        }
        public int Multiplicacion(int num1, int num2)
        {
            return num1 * num2;
        }
        public int Resta(int num1, int num2)
        {
            return num1 - num2;
        }
        public int Suma(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
