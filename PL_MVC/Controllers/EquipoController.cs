using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult GetAll()
        {
            ML.Equipo equipo = new ML.Equipo();
            ML.Result result = BL.Equipo.GetAll();
            equipo.Equipos = result.Objects;

            return View(equipo);
        }

        [HttpGet]
        public ActionResult Form(int? IdEquipo)
        {
            ML.Equipo equipo = new ML.Equipo();



            if (IdEquipo == null)
            {
                ViewBag.Titulo = "Registrar Equipo";
                ViewBag.Accion = "Guardar";


                return View(equipo);
            }
            else
            {
                ViewBag.Titulo = "Actualizar Equipo";
                ViewBag.Accion = "Actualizar";



                equipo.IdEquipo = IdEquipo.Value;


                var result = BL.Equipo.GetByIdEF(equipo);


                if (result.Object != null)
                {
                    equipo.IdEquipo = ((ML.Equipo)result.Object).IdEquipo;
                    equipo.Nombre = ((ML.Equipo)result.Object).Nombre;
                    equipo.FechaDeFundacion = ((ML.Equipo)result.Object).FechaDeFundacion;
                    equipo.Logotipo = ((ML.Equipo)result.Object).Logotipo;


                    return View(equipo);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Validation");
                }
            }
           
        }

        public ActionResult Form(ML.Equipo producto, HttpPostedFileBase Imagen)
        {
            ML.Result result = new ML.Result();
            ML.Equipo equipo=new ML.Equipo();

            if (producto.IdEquipo == 0)
            {

                //result = BL.Producto.AddEF(producto);
                producto.Logotipo = ConvertToBytes(Imagen);
                result = BL.Equipo.Add(producto);

                if (result.Correct == true)
                {
                    ViewBag.Message = "Se agrego el equipo correctamente";
                    return View("Validation");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al agregar el equipo.  Error: " + result.ErrorMessage;
                    return View("Validation");
                }
            }
            else
            {

                equipo.Logotipo = ConvertToBytes(Imagen);
                result = BL.Equipo.Update(producto);

                if (result.Correct == true)
                {
                    ViewBag.Message = "Se actualizo correctamente el equipo ";
                    return View("Validation");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al actualizar el equipo.  Error: " + result.ErrorMessage;
                    return View("Validation");
                }
            }
           
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {

            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }

        public ActionResult Delete(int IdEquipo)
        {
            ML.Result result = BL.Equipo.Delete(IdEquipo);

            if (result.Correct)
            {
                ViewBag.Message = "Equipo eliminado correctamente";

            }
            else
            {
                ViewBag.Message = "El equipo no se ha podido eliminar";

            }
            return View("Validation");
        }
    }
}