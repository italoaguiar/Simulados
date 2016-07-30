using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin.EF;

namespace Admin.Controllers
{
    public class SubcategoriasController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Subcategorias
        public ActionResult Index()
        {
            var subcategorias = db.Subcategorias.Include(s => s.Categorias);
            return View(subcategorias.ToList());
        }

        // GET: Subcategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategorias subcategorias = db.Subcategorias.Find(id);
            if (subcategorias == null)
            {
                return HttpNotFound();
            }
            return View(subcategorias);
        }

        // GET: Subcategorias/Create
        public ActionResult Create()
        {
            ViewBag.Pai = new SelectList(db.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Subcategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Pai,Qtd")] Subcategorias subcategorias)
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategorias subcategorias = db.Subcategorias.Find(id);
            if (subcategorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pai = new SelectList(db.Categorias, "Id", "Nome", subcategorias.Pai);
            return View(subcategorias);
        }

        // POST: Subcategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Pai,Qtd")] Subcategorias subcategorias)
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

        // GET: Subcategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategorias subcategorias = db.Subcategorias.Find(id);
            if (subcategorias == null)
            {
                return HttpNotFound();
            }
            return View(subcategorias);
        }

        // POST: Subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcategorias subcategorias = db.Subcategorias.Find(id);
            db.Subcategorias.Remove(subcategorias);
            db.SaveChanges();
            return RedirectToAction("Index");
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
