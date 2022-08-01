using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace WebApplication.Controllers
{
    public class PaqueteController : Controller
    {
        TVision unTv = TVision.Instancia;
        // GET: Paquete
        public ActionResult Index()
        {
            ViewBag.Paquetes = unTv.Paquetes();
            return View();
        }
        public ActionResult PaquetesCliente()
        {
            if ((String)Session["LogueadoRol"] == "Cliente")
            {
                ViewBag.Paquetes = unTv.Paquetes();
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult MostrarPaquete(int id, string cedula)
        {
            if ((String)Session["LogueadoRol"] == "Cliente")
            {
                ViewBag.Paquete = unTv.EncontrarPaquete(id);
                ViewBag.TienePaquete = unTv.EncontrarCliente(cedula).UnC.BuscarPaquete(id);
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult ComprarPaquete(int id, string cedula)
        {
            if ((String)Session["LogueadoRol"] == "Cliente")
            {
                ViewBag.Cliente = unTv.EncontrarCliente(cedula);
                ViewBag.Paquete = unTv.EncontrarPaquete(id);
                ViewBag.Comprado = unTv.ComprarPaquete(id, cedula);
                if (ViewBag.Comprado == true)
                {
                    ViewBag.Mensaje4 = "Paquete comprado";
                }
                else
                {
                    ViewBag.Mensaje4 = "No encontrado";
                }
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult MostrarCanales()
        {
            if ((String)Session["LogueadoRol"] == "Operador")
            {
                ViewBag.Canales = unTv.Canales();
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult BuscarPaquete(int idCanal)
        {
            if ((String)Session["LogueadoRol"] == "Operador")
            {
                ViewBag.Canales = unTv.Canales();
                ViewBag.Paquetes = unTv.BuscarPaquetesConCanal(idCanal);
                return View("MostrarCanales");
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult MostrarPaquetesMayorCosto()
        {
            if ((String)Session["LogueadoRol"] == "Operador")
            {
                ViewBag.PaquetesConMayorCosto = unTv.PaquetesConMayorCosto();
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
    }
}