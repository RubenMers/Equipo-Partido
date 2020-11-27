using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Saludar(string nombre)
        {
            return string.Format("Hola " + nombre);
        }


        public Result GetAll()
        {
            ML.Result result = BL.Jugador.GetAll();
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.ex };
        }

        public Result Add(ML.Jugador jugador)
        {

            ML.Result result = BL.Jugador.Add(jugador);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.ex };
        }
    }
}
