using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simulados.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            EF.LocalDBEntities e = new EF.LocalDBEntities();

            var k = e.Questoes.ToArray();
            ViewBag.Questoes = k;
            ViewBag.Style = "border: 1px dotted";          
            
                        
            return View();
        }

        public ContentResult Json()
        {
            return Content(""); 
        }
    }
}
