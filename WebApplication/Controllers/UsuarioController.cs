using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;


namespace WebApplication.Controllers
{
    public class UsuarioController : Controller
    {
        TVision unTV = TVision.Instancia;
        // GET: Persona
        public ActionResult Index()
        {
            Session["Logueado"] = null;
            Session["LogueadoRol"] = null;
            Session["LogueadoCedula"] = null;
            return View();
        }
        public ActionResult Login()
        {
            if ((String)Session["LogueadoRol"] == "Cliente" || (String)Session["LogueadoRol"] == "Operador")
            {
                return Redirect("/Usuario/SinPermisos");
            }
            else 
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(string usuario, string contrasena)
        {
            ViewBag.Usuario = unTV.VerificarUsuario(usuario, contrasena);
            Usuario unU = ViewBag.Usuario;
            if (unU != null)
            {
                Session["LogueadoRol"] = unU.Rol;
                Session["LogueadoCedula"] = unU.Cedula;
                Session["Logueado"] = true;
                if (unU.Rol == "Cliente")
                {
                    return Redirect("/Usuario/AccesoCliente?cedula=" + usuario);
                }
                else if (unU.Rol == "Operador")
                {
                    return Redirect("/Usuario/AccesoOperador");
                }
            }
            else
            {
                ViewBag.mensaje = "Error de login";
            }
            return View();
        }
        public ActionResult AccesoCliente(string cedula)
        {
            if ((String)Session["LogueadoRol"] == "Cliente")
            {
                ViewBag.Cliente = unTV.EncontrarCliente(cedula).UnC.Nombre;
                return View(); 
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult AccesoOperador()
        {
            if ((String)Session["LogueadoRol"] == "Operador")
            {
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult RegistrarseComoCliente()
        {
            if ((String)Session["LogueadoRol"] != null)
            {
                return Redirect("/Usuario/SinPermisos");
            }
            return View();
        }       
        [HttpPost]
        public ActionResult RegistrarseComoCliente(string cedula, string contrasena, string nombre, string apellido)
        {
            string rol = "Cliente";
            ViewBag.mensaje = "";
            ViewBag.Cliente = unTV.AgregarCliente(cedula, contrasena, rol, nombre, apellido);
            if (!ViewBag.Cliente)
            {
                ViewBag.mensaje = "Error, intente nuevamente";
            }
            else {
                ViewBag.mensaje = "Registro exitoso!";
            }
            return View();
        }
        public ActionResult Suscripciones(string cedula)
        {
            if ((String)Session["LogueadoRol"] == "Cliente")
            {
                ViewBag.ClientePaquetes = unTV.EncontrarCliente(cedula).UnC.ComprasVigentes();
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult VerSuscripcion(int id)
        {
            if ((String)Session["LogueadoRol"] == "Cliente")
            {
                ViewBag.Paquete = unTV.EncontrarPaquete(id);
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult CancelarSuscripcion(int idPaquete, string cedula)
        {
            if ((String)Session["LogueadoRol"] == "Cliente")
            {
                ViewBag.EliminarPaquetes = unTV.EliminarCompraCliente(idPaquete, cedula);
                ViewBag.ClientePaquetes = unTV.EncontrarCliente(cedula).UnC.ComprasVigentes();
                return View("Suscripciones");
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult MostrarClientes()
        {
            if ((String)Session["LogueadoRol"] == "Operador")
            {
                ViewBag.Clientes = unTV.ClientesOrdenadosApellido();
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult ClientesConVencimiento()
        {
            if ((String)Session["LogueadoRol"] == "Operador")
            {
                ViewBag.ClientesVencimiento = unTV.ClientesConVencimiento30();
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult Estadisticas()
        {
            if ((String)Session["LogueadoRol"] == "Operador")
            {
                return View();
            }
            else
            {
                return Redirect("/Usuario/SinPermisos");
            }
        }
        public ActionResult SinPermisos()
        {
            return View();
        }
    }
}