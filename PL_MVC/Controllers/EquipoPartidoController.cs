using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EquipoPartidoController : Controller
    {
        // GET: EquipoPartido
        public ActionResult GetAll()
        {
            ML.Result result = BL.EquipoPartido.GetAll();
            ML.EquipoPartido equipoPartido = new ML.EquipoPartido();
            equipoPartido.EquipoPartidos = result.Objects;

            return View(equipoPartido);
        }

        [HttpGet]
        public ActionResult Form(int? IdEquipoPartido)
        {
            ML.EquipoPartido equipoPartido = new ML.EquipoPartido();
            ML.Result result = new ML.Result();

            if (IdEquipoPartido == null)
            {
                ViewBag.Message = "Agregar partido";
                ViewBag.Accion = "Guardar";

                ML.Result resultEquipo = BL.Equipo.GetAll();
                equipoPartido.Equipo = new ML.Equipo();
                equipoPartido.Equipo.Equipos = resultEquipo.Objects;

                ML.Result resultVisita = BL.Equipo.GetAll();
                equipoPartido.EquipoVisita = new ML.Equipo();
                equipoPartido.EquipoVisita.Equipos = resultVisita.Objects;

                ML.Result resultlPartido = BL.Partido.GetAll();
                equipoPartido.Partido = new ML.Partido();
                equipoPartido.Partido.Partidos = resultlPartido.Objects;

                return View(equipoPartido);

            }
            else
            {
                ViewBag.Message = "Actualizar";
                ViewBag.Accion = "Actualizar";
                equipoPartido.IdEquipoPartido = IdEquipoPartido.Value;
                result = BL.EquipoPartido.GetByIdEF(equipoPartido);

                if (result.Object != null)
                {
                    equipoPartido.IdEquipoPartido = ((ML.EquipoPartido)result.Object).IdEquipoPartido;
                    //equipoPartido.Equipo = new ML.Equipo();
                    equipoPartido.Equipo.IdEquipo = ((ML.EquipoPartido)result.Object).Equipo.IdEquipo;
                    equipoPartido.Equipo.Nombre = ((ML.EquipoPartido)result.Object).Equipo.Nombre;
                    //equipoPartido.EquipoVisita = new ML.Equipo();
                    equipoPartido.EquipoVisita.IdEquipo = ((ML.EquipoPartido)result.Object).EquipoVisita.IdEquipo;
                    equipoPartido.EquipoVisita.Nombre = ((ML.EquipoPartido)result.Object).EquipoVisita.Nombre;

                    ML.Result resultEquipo = BL.Equipo.GetAll();
                    equipoPartido.Equipo = new ML.Equipo();
                    equipoPartido.Equipo.Equipos = resultEquipo.Objects;

                    ML.Result resultVisita = BL.Equipo.GetAll();
                    equipoPartido.EquipoVisita = new ML.Equipo();
                    equipoPartido.EquipoVisita.Equipos = resultVisita.Objects;

                    ML.Result resultlPartido = BL.Partido.GetAll();
                    equipoPartido.Partido = new ML.Partido();
                    equipoPartido.Partido.Partidos = resultlPartido.Objects;

                    return View(equipoPartido);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View("Validation");
                }
            }
            ;
        }

        [HttpPost]
        public ActionResult Form(ML.EquipoPartido equipopartido)
        {
            ML.Result result = new ML.Result();

            if (equipopartido.IdEquipoPartido == 0)
            {
                result = BL.EquipoPartido.Add(equipopartido);

                if (result.Correct == true)
                {
                    ViewBag.Message = "Se agrego correctamente";
                    return View("Validation");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al agregar el producto.  Error: " + result.ErrorMessage;
                    return View("Validation");
                }
            }
            else
            {
                result = BL.EquipoPartido.Update(equipopartido);

                if (result.Correct == true)
                {
                    ViewBag.Message = "Se agrego correctamente";
                    return View("ValidationModal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al agregar el producto.  Error: " + result.ErrorMessage;
                    return View("ValidationModal");
                }
            }


        }

        public ActionResult Delete(int IdEquipoPartido)
        {
            ML.Result result = BL.EquipoPartido.Delete(IdEquipoPartido);

            if (result.Correct)
            {
                ViewBag.Message = "Partido eliminado correctamente";

            }
            else
            {
                ViewBag.Message = "El Partido no se ha podido eliminar";

            }
            return View("Validation");
        }
    }
}