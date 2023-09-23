﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceAseguradora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceAseguradora.svc or ServiceAseguradora.svc.cs at the Solution Explorer and start debugging.
    public class ServiceAseguradora : IServiceAseguradora
    {
        public SLWCF.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Add(aseguradora);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
        public SLWCF.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Update(aseguradora);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
        public SLWCF.Result Delete(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.Delete(idAseguradora);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
        public SLWCF.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
        public SLWCF.Result GetById(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetById(idAseguradora);
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
