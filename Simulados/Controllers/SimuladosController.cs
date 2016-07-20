using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Simulados.EF;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Core.Objects;

namespace Simulados.Controllers
{
    [Authorize]
    public class SimuladosController : Controller
    {
        private LocalDBEntities db = new LocalDBEntities();

        // GET: Simulados
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var s = db.Simulados.Where(p => p.Usuario == user).ToList();
            return View(s);
        }

        // GET: Simulados/Novo
        public ActionResult Novo(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EF.Categoria cat = db.Categorias.Find(id);
            if(cat == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectParameter s_id = new ObjectParameter("IdSimulado", typeof(int));
            int? result = db.GeraSimulado(User.Identity.GetUserId(), id, s_id);

            return RedirectToAction("View",new { id = s_id.Value });
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.IdSimulado = id;
            ViewBag.Title = db.Simulados.Where(p => p.Id == id).First().Categorias.Nome;
            return View();
        }

        public JsonResult GetQuestoes(int? id)
        {
            var rst = from q in db.Simulados_Questoes where q.Simulado == id select new Models.Questao()
            {
                Id = q.Questoes.Id,
                Imagem = q.Questoes.Imagem,
                Enunciado = q.Questoes.Enunciado,
                Alternativas = (from a in q.Questoes.Alternativas select new Models.Alternativa()
                {
                    Id = a.Id,
                    Enunciado = a.Valor.Trim(),
                    Imagem = a.Imagem
                }).ToList()
            };
            
            return Json(rst, JsonRequestBehavior.AllowGet);
        }



        public JsonResult Categorias()
        {
            return Json(GetCategorias(), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Models.Categoria> GetCategorias()
        {
            var cats = from k in db.Categorias
                       select new Models.Categoria()
                       {
                           Id = k.Id,
                           Nome = k.Nome.Trim(),
                           Questoes = k.Subcategorias.Sum(p => p.Questoes.Count),
                           Imagem = k.Imagem.Trim()
                       };
            return cats.ToArray();
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
