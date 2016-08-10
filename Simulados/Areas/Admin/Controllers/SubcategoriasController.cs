using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Simulados.EF;

namespace Simulados.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubcategoriasController : Controller
    {
        private LocalDBEntities db = new LocalDBEntities();

        // GET: Subcategorias
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Categorias", null);
        }

        // GET: Subcategorias/Create
        public ActionResult Add()
        {
            ViewBag.Pai = new SelectList(db.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Subcategorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Nome,Pai,Qtd")] Subcategoria subcategorias)
        {
            if (ModelState.IsValid)
            {
                db.Subcategorias.Add(subcategorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pai = new SelectList(db.Categorias, "Id", "Nome", subcategorias.Pai);
            return View(subcategorias);
        }

        // GET: Subcategorias/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategoria subcategorias = db.Subcategorias.Find(id);
            if (subcategorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pai = new SelectList(db.Categorias, "Id", "Nome", subcategorias.Pai);
            return View(subcategorias);
        }

        // POST: Subcategorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Nome,Pai,Qtd")] Subcategoria subcategorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pai = new SelectList(db.Categorias, "Id", "Nome", subcategorias.Pai);
            return View(subcategorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
