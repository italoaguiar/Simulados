using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            EF.DBConnection e = new EF.DBConnection();
            var cat = e.Categorias.ToArray();
            return View(cat);
        }
        public ActionResult Novo()
        {
            EF.Categorias cat = new EF.Categorias();
            return View(cat);
        }
        public ActionResult Editar()
        {
            return View();
        }
        public ActionResult Excluir()
        {
            return View();
        }
    }
}