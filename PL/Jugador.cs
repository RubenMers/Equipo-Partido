using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Jugador
    {
        public static void GetAllEF()
        {
            ML.Result result = BL.Jugador.GetAll();

            if (result.Correct)
            {
                foreach (ML.Jugador producto in result.Objects)
                {

                    Console.WriteLine("IdJugador: " + producto.IdJugador);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);


                }

                ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
                var result1 = obj.GetAll();

                Console.WriteLine("La colsuta fue ejecutada correctamente ");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al ejeutar la consulta " + result.ErrorMessage);
            }
        }
    }
}
