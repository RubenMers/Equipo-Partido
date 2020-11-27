using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Partido
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.PartidoGetAll().ToList();

                    result.Objects = new List<Object>();



                    if (result.Objects != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Partido partido = new ML.Partido();
                            partido.IdPartido = obj.IdPartido;
                            partido.Dia = obj.Dia;
                            partido.Horario = obj.Horario;

                            result.Objects.Add(partido);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay datos!";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
