using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simulados.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Simulados()
        {
            return View();
        }
                 
        public ContentResult Novo(int categoria)
        {
            return Content(string.Format("Valor passado: {0}",categoria));
        }
    }
}