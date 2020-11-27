using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult GetAll()
        {
            ML.Result result = BL.Jugador.GetAll();
            ML.Jugador jugador = new ML.Jugador();
            jugador.Jugadores = result.Objects;

            return View(jugador);
        }
        [HttpGet]
        public ActionResult Form(int? IdJugador)
        {
            //ML.Result result = new ML.Result();
            ML.Jugador jugador = new ML.Jugador();

            if (IdJugador == null)
            {
                ViewBag.Message = "Agregar";
                ViewBag.Action = "Agregar";
            }
            else
            {
                jugador.IdJugador = IdJugador.Value;
                var result = BL.Jugador.GetByIdEF(jugador);

                if(result.Object !=null ){

                    jugador.IdJugador = ((ML.Jugador)result.Object).IdJugador;
                    jugador.Nombre = ((ML.Jugador)result.Object).Nombre;
                    jugador.FechaDeNacimiento = ((ML.Jugador)result.Object).FechaDeNacimiento;
                    jugador.Equipo = new ML.Equipo();
                    jugador.Equipo.IdEquipo = ((ML.Jugador)result.Object).Equipo.IdEquipo;

                    return View(jugador);
                }
                else{
                    ViewBag.Message = "No hay datos";
                    return PartialView("Validation");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Jugador jugador){
            ML.Result result= new ML.Result();

            if (jugador.IdJugador==0 )
            {
                result = BL.Jugador.Add(jugador);
                if (result.Correct)
                {
                    ViewBag.Message = "Jugador agregador correctamente";
                }
                else
                {
                    ViewBag.Message="El jugador no se ha podido agregar!";
                }
            }
            else
            {
               result = BL.Jugador.Update(jugador);
               if (result.Correct)
               {
                   ViewBag.Message = "Jugador se ha actualizado correctamente";
               }
               else
               {
                   ViewBag.Message = "Jugador no se ha actualizado correctamente";
               }
            }
            return View();
        }

        public ActionResult Delete(int IdJugador)
        {
            ML.Result result = BL.Jugador.Delete(IdJugador);
            if(result.Correct){
                ViewBag.Message = "Jugador eliminado";
            }else
            {
                ViewBag.Message = "El jugador no se ha eliminado";
            }
            return View("Validation");
        }
    }
}