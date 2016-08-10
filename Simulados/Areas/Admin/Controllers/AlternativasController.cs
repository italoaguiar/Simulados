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
    [Authorize(Roles ="Admin")]
    public class AlternativasController : Controller
    {
        private LocalDBEntities db = new LocalDBEntities();


        // GET: Alternativas
        public ActionResult Index()
        {
            return View(db.Alternativas.ToList());
        }

        // GET: Alternativas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativas = db.Alternativas.Find(id);
            if (alternativas == null)
            {
                return HttpNotFound();
            }
            return View(alternativas);
        }

        // GET: Alternativas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alternativas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,Imagem")] Alternativa alternativas)
        {
            if (ModelState.IsValid)
            {
                db.Alternativas.Add(alternativas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alternativas);
        }

        // GET: Alternativas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativas = db.Alternativas.Find(id);
            if (alternativas == null)
            {
                return HttpNotFound();
            }
            return View(alternativas);
        }

        // POST: Alternativas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,Imagem")] Alternativa alternativas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alternativas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alternativas);
        }

        // GET: Alternativas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativas = db.Alternativas.Find(id);
            if (alternativas == null)
            {
                return HttpNotFound();
            }
            return View(alternativas);
        }

        // POST: Alternativas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alternativa alternativas = db.Alternativas.Find(id);
            db.Alternativas.Remove(alternativas);
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
