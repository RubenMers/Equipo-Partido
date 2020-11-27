using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Jugador
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.JugadorGetAll().ToList();
                    result.Objects = new List<object>();

                    if (result.Objects != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Jugador jugador = new ML.Jugador();
                            jugador.IdJugador = obj.IdJugador;
                            jugador.Nombre = obj.Nombre;
                            jugador.FechaDeNacimiento = Convert.ToDateTime(obj.FechaDeNacimiento);
                            jugador.Descripcion = obj.Descripcion;
                            jugador.Equipo = new ML.Equipo();
                            jugador.Equipo.IdEquipo = Convert.ToInt32(obj.IdEquipo);

                            result.Objects.Add(jugador);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        public static ML.Result Add(ML.Jugador jugador)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.JugadorAdd(jugador.Nombre,Convert.ToDateTime(jugador.FechaDeNacimiento),jugador.Descripcion,jugador.Equipo.IdEquipo);

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

        public static ML.Result Delete(int IdJugador)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.JugadorDelete(IdJugador);

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

        public static ML.Result Update(ML.Jugador jugador)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.JugadorUpdate(jugador.IdJugador, jugador.Nombre, Convert.ToDateTime(jugador.FechaDeNacimiento), jugador.Descripcion, jugador.Equipo.IdEquipo);

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

        public static ML.Result GetByIdEF(ML.Jugador jugador)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {


                    var alumnos = context.JugadorGetById(jugador.IdJugador).FirstOrDefault();


                    if (alumnos != null)
                    {
                        jugador.IdJugador = alumnos.IdJugador;
                        jugador.Nombre = alumnos.Nombre;
                        jugador.FechaDeNacimiento = Convert.ToDateTime(alumnos.FechaDeNacimiento);
                        jugador.Descripcion = alumnos.Descripcion;
                        jugador.Equipo = new ML.Equipo();
                        jugador.Equipo.IdEquipo = Convert.ToInt32(alumnos.IdEquipo);

                        result.Object = jugador;


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
    }
}
