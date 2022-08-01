using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace WebApplication.Controllers
{
    public class CompraController : Controller
    {
        TVision unTV = TVision.Instancia;

        public ActionResult MostrarCompras()
        {
            if ((String)Session["LogueadoRol"] == "Operador")
            {
                ViewBag.Compras = unTV.Compras();
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        [HttpPost]
        public ActionResult MostrarCompras(string fecha1, string fecha2)
        {
            ViewBag.Compras = unTV.Compras();
            ViewBag.ComprasFecha = unTV.ComprasXFecha(fecha1, fecha2);
            ViewBag.CostoCompras = unTV.CalcularCostoCompras(ViewBag.ComprasFecha);
            return View();
        }
    }
}