using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Jugador
    {
        public int IdJugador { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public string Descripcion { get; set; }

        public ML.Equipo Equipo { get; set; }

        public List<Object> Jugadores { get; set; }
    }
}
