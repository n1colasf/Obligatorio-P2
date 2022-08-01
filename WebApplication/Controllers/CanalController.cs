using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace WebApplication.Controllers
{
    public class CanalController : Controller
    {
        TVision unTv = TVision.Instancia;
        // GET: Canal
        public ActionResult Index()
        {
            return View();
        }
    }
}