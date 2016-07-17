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
        public ActionResult Editar(int id)
        {
            return View();
        }
        public ActionResult Excluir()
        {
            return View();
        }
        public ActionResult Salvar()
        {
            EF.DBConnection db = new EF.DBConnection();//gerenciador do BD

            EF.Categorias c = new EF.Categorias();//Tabela do BD
            c.Nome = "Enem";

            db.Categorias.Add(c);
            db.SaveChanges();

            return View();
        }
    }
}