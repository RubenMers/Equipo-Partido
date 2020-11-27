using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Consumir servicio WCF
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();

            string result = obj.Saludar("Ruben");

            PL.Jugador.GetAllEF();
        }
    }
}
