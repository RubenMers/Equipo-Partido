using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Equipo
    {
        public int IdEquipo { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaDeFundacion { get; set; }

        public byte[] Logotipo { get; set; }

        public List<Object> Equipos { get; set; }
    }
}
