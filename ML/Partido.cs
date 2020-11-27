using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Partido
    {
        public int IdPartido { get; set; }

        public string Dia { get; set; }

        public string Horario { get; set; }

        public List<Object> Partidos { get; set; }
    }
}
