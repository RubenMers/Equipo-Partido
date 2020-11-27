using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace BL
{
    public class Equipo
    {
        //---------------------------Dapper--------------------------------

        public static ML.Result GetAllDapper()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (IDbConnection context = new SqlConnection(DL_Dapper.Conexion.GetConnectionString()))
                {
                    List<ML.Equipo> EquipoList = new List<ML.Equipo>();
                    EquipoList = context.Query<ML.Equipo>("Select [IdEquipo],[Nombre],[FechaDeFundacion], [Logotipo] From Equipo").ToList();

                    if (EquipoList.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (ML.Equipo row in EquipoList)
                        {

                            ML.Equipo equipoItem = new ML.Equipo();
                            equipoItem.IdEquipo = row.IdEquipo;
                            equipoItem.Nombre = row.Nombre;
                            equipoItem.FechaDeFundacion = row.FechaDeFundacion;
                            equipoItem.Logotipo = row.Logotipo;

                            result.Objects.Add(equipoItem);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros en la tabla Producto";
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


        //----------------------------EF------------------------------------
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.EquipoGetAll().ToList();

                    result.Objects = new List<Object>();



                    if (result.Objects != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Equipo equipo = new ML.Equipo();
                            equipo.IdEquipo = obj.IdEquipo;
                            equipo.Nombre = obj.Nombre;
                            equipo.FechaDeFundacion = Convert.ToDateTime(obj.FechaDeFundacion);
                            equipo.Logotipo = Convert.FromBase64String(obj.Logotipo);

                            result.Objects.Add(equipo);
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

        public static ML.Result Add(ML.Equipo equipo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.EquipoAdd(equipo.Nombre, Convert.ToDateTime(equipo.FechaDeFundacion), Convert.ToBase64String(equipo.Logotipo));

                    if (query > 1)
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

        public static ML.Result Delete(int IdEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.EquipoDelete(IdEquipo);

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

        public static ML.Result Update(ML.Equipo equipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {
                    var query = context.EquipoUpdate(equipo.IdEquipo, equipo.Nombre, Convert.ToDateTime(equipo.FechaDeFundacion
                        ), Convert.ToBase64String(equipo.Logotipo));

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

        public static ML.Result GetByIdEF(ML.Equipo equipo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EquipoHREntities context = new DL_EF.EquipoHREntities())
                {


                    var alumnos = context.IdEquipoGetById(equipo.IdEquipo).FirstOrDefault();


                    if (alumnos != null)
                    {
                        equipo.IdEquipo = alumnos.IdEquipo;
                        equipo.Nombre = alumnos.Nombre;
                        equipo.FechaDeFundacion = Convert.ToDateTime(alumnos.FechaDeFundacion);
                        equipo.Logotipo = Convert.FromBase64String(alumnos.Logotipo);
                        result.Object = equipo;


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
