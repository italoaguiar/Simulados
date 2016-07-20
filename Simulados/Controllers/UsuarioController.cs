using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Simulados.Models;

namespace Simulados.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        EF.LocalDBEntities e = new EF.LocalDBEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            
            return View();
        }
    }
}