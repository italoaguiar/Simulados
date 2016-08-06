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
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Helpers;

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
            if(id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            EF.Categoria cat = db.Categorias.Find(id);
            if(cat == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            //parâmetro de retorno da função que ira retornar o id do novo simulado
            ObjectParameter s_id = new ObjectParameter("IdSimulado", typeof(int));

            int? result = db.GeraSimulado(User.Identity.GetUserId(), id, s_id);

            //redireciona para a visualização do novo simulado
            return RedirectToAction("View",new { id = s_id.Value });
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var simulado = db.Simulados.Where(p => p.Id == id);
            if (simulado.Count() == 0) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            ViewBag.IdSimulado = id;
            ViewBag.Title = simulado.First().Categorias.Nome;
            return View();
        }

        public JsonResult GetQuestoes(int? id)
        {
            var sm = db.Simulados.Where(p => p.Id == id);
            if (sm.Count() == 0) return Json("Not Found", JsonRequestBehavior.AllowGet);
            if (sm.First().Submissao == null)
            {
                var rst = from q in db.Simulados_Questoes
                          where q.Simulado == id
                          select new Models.Questao()
                          {
                              Id = q.Questoes.Id,
                              Imagem = q.Questoes.Imagem,
                              Enunciado = q.Questoes.Enunciado,
                              Alternativas = (from a in q.Questoes.Alternativas
                                              select new Models.Alternativa()
                                              {
                                                  Id = a.Id,
                                                  Enunciado = a.Valor.Trim(),
                                                  Imagem = a.Imagem
                                              }).ToList()
                          };
                Models.Resposta r = new Models.Resposta(rst.ToList(), Models.StatusType.Aberto);
                return Json(r, JsonRequestBehavior.AllowGet);
            }
            else
            {

                var rst = from q in db.Simulados_Questoes
                          where q.Simulado == id
                          select new Models.Questao()
                          {
                              Id = q.Questoes.Id,
                              Imagem = q.Questoes.Imagem,
                              Enunciado = q.Questoes.Enunciado,
                              Correta = q.Questoes.Correta,
                              Selecionada = q.Marcada,
                              Alternativas = (from a in q.Questoes.Alternativas
                                              select new Models.Alternativa()
                                              {
                                                  Id = a.Id,
                                                  Enunciado = a.Valor.Trim(),
                                                  Imagem = a.Imagem
                                              }).ToList()
                          };
                var questoes = rst.ToList();
                Models.Resposta r = new Models.Resposta(questoes, Models.StatusType.Finalizado);
                return Json(r, JsonRequestBehavior.AllowGet);
            }
        }


        public async Task<JsonResult> Submit(int? simulado, List<Models.Questao> questoes)
        {
            if(simulado == null)
            {
                return Json("Bad Request");
            }
            var user = User.Identity.GetUserId();
            var sm = db.Simulados.First(s => s.Id == simulado && s.Usuario == user);
            sm.Submissao = DateTime.Now;

            if (sm == null) return Json("Bad Request");


            var q = db.Simulados_Questoes.Where(p=> p.Simulado == simulado);

            foreach(var item in q)
            {
                int? selecionada = questoes.First(k => k.Id == item.Questao).Selecionada;
                item.Marcada = selecionada;
            }

            await db.SaveChangesAsync();


            return GetQuestoes(simulado);
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
