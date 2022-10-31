using DSIGE.Modelo;
using DSIGE.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSIGE.Web.Controllers
{
    public class NoCortarController : Controller
    {
        //
        // GET: /NoCortar/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListarSumnistroCorte(int id_tiposervicio, string fecha_asignacion, string suministro)
        {
            // Int32 respuesta = new NObservacion_Servicio().NAsignaServicio(__a, );
            NCorte objetocorte = new NCorte();
            List<corteSumnistro> lits = new List<corteSumnistro>();
            lits = objetocorte.NlistaNoCorte(id_tiposervicio, fecha_asignacion, suministro);
            if(lits.Count>0){
                return Json(lits, JsonRequestBehavior.AllowGet);
            }
            
            else
            {
                var resultado = 0;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public ActionResult CambioEstadoCorte(int id_tiposervicio, string fecha_asignacion, string suministro, int SuministrosMasivos)
        {

            try
            {
                NCorte objetocorte = new NCorte();
                var lits = objetocorte.NCambioEstadoCorte(id_tiposervicio, fecha_asignacion, suministro, SuministrosMasivos);
                return Json(lits, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

 


    }
}
