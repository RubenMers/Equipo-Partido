using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class EquipoPartido
    {
        public int IdEquipoPartido { get; set; }

        public ML.Equipo Equipo { get; set; }

        public ML.Partido Partido { get; set; }

        public ML.Equipo EquipoVisita { get; set; }

        public List<Object> EquipoPartidos { get; set; }
    }
}
