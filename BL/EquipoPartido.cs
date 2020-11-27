using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EquipoPartido
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.EquipoPartidoInnerJoin().ToList();

                    result.Objects = new List<Object>();



                    if (result.Objects != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.EquipoPartido equipoPartido = new ML.EquipoPartido();
                            equipoPartido.Equipo = new ML.Equipo();
                            equipoPartido.Partido = new ML.Partido();
                            equipoPartido.EquipoVisita = new ML.Equipo();
                            equipoPartido.IdEquipoPartido = obj.IdEquipoPartido;

                            equipoPartido.Equipo.IdEquipo = Convert.ToInt32(obj.IdEquipo);
                            equipoPartido.Equipo.Nombre = obj.NombreEquipo;

                            equipoPartido.EquipoVisita.IdEquipo = Convert.ToInt32(obj.IdEquipoVisita);
                            equipoPartido.EquipoVisita.Nombre = obj.NombreEquipoVisita;

                            equipoPartido.Partido.IdPartido = obj.IdPartido;
                            equipoPartido.Partido.Dia = obj.Dia;
                            equipoPartido.Partido.Horario = obj.Horario;

                            result.Objects.Add(equipoPartido);
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

        public static ML.Result Add(ML.EquipoPartido equipoPartido)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.EquipoPartidoAdd(equipoPartido.Equipo.IdEquipo, equipoPartido.Partido.IdPartido,equipoPartido.EquipoVisita.IdEquipo);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.EquipoPartido equipoPartido)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.EquipoPartidoAdd(equipoPartido.Equipo.IdEquipo,equipoPartido.Partido.IdPartido, equipoPartido.EquipoVisita.IdEquipo);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

        public static ML.Result GetByIdEF(ML.EquipoPartido equipoPartido)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {


                    var alumnos = context.EquipoPartidoGetByIdInner(equipoPartido.IdEquipoPartido).FirstOrDefault();


                    if (alumnos != null)
                    {
                        equipoPartido.IdEquipoPartido = alumnos.IdEquipoPartido;
                        equipoPartido.Equipo = new ML.Equipo();
                        equipoPartido.Equipo.IdEquipo = Convert.ToInt32(alumnos.IdEquipo);
                        equipoPartido.Equipo.Nombre = alumnos.NombreEquipo;
                        equipoPartido.EquipoVisita = new ML.Equipo();
                        equipoPartido.EquipoVisita.IdEquipo = Convert.ToInt32(alumnos.IdEquipoVisita);

                        result.Object = equipoPartido;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
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

        public static ML.Result Delete(int IdEquipoPartido)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.EquipoPartidoDelete(IdEquipoPartido);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
