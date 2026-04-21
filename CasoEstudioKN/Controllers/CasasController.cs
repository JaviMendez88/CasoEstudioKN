using CasoEstudio2.EntityFramework;
using CasoEstudio2.Models;
using System;
using System.Linq;
using System.Web.Mvc;
namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        private CasoEstudio2Entities db = new CasoEstudio2Entities();


        #region Consultas
        public ActionResult Consultas()
        {
            var resultado = db.CasasSistema
                .Where(c => c.PrecioCasa >= 115000 && c.PrecioCasa <= 180000)

                .OrderBy(c => c.UsuarioAlquiler == null ? 0 : 1)

                .Select(c => new CasasModel
                {
                    IdCasa = c.IdCasa,
                    DescripcionCasa = c.DescripcionCasa,
                    PrecioCasa = c.PrecioCasa,
                    UsuarioAlquiler = c.UsuarioAlquiler,
                    FechaAlquiler = c.FechaAlquiler
                })
                .ToList();

            return View(resultado);
        }

        #endregion Consultas


        #region Alquileres

        public ActionResult Alquileres()
        {
            CargarCasasDisponibles();
            return View(new CasasModel());
        }


        #region AJAX dinámico

        public JsonResult ObtenerPrecio(long idCasa)
        {
            var casa = db.CasasSistema.FirstOrDefault(c => c.IdCasa == idCasa);

            return Json(casa?.PrecioCasa, JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX dinámico


        #region guardarAlquiler

        private void CargarCasasDisponibles()
        {
            var casas = db.CasasSistema
                .Where(c => c.UsuarioAlquiler == null)
                .ToList();

            ViewBag.Casas = new SelectList(casas, "IdCasa", "DescripcionCasa");
        }


        [HttpPost]
        public ActionResult Alquilar(CasasModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarCasasDisponibles();
                return View("Alquileres", model);
            }

            var casa = db.CasasSistema
                .FirstOrDefault(c => c.IdCasa == model.IdCasa.Value && c.UsuarioAlquiler == null);

            if (casa == null)
            {
                ModelState.AddModelError("", "La casa ya no está disponible");
                CargarCasasDisponibles();
                return View("Alquileres", model);
            }

            casa.UsuarioAlquiler = model.UsuarioAlquiler;
            casa.FechaAlquiler = DateTime.Now;

            db.SaveChanges();

            return RedirectToAction("Consultas");
        }

        #endregion guardarAlquiler

        #endregion Alquileres
    }
}
