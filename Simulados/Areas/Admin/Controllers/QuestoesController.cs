using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Simulados.EF;

namespace Simulados.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestoesController : Controller
    {
        private LocalDBEntities db = new LocalDBEntities();

        // GET: Questoes
        public ActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var items = db.Questoes.ToArray();

            return View(items.ToPagedList(pageNumber, pageSize));
        }

        public ContentResult AddAlternativa(string alternativa, string imagem)
        {
            try
            {
                Alternativa a = new Alternativa();
                a.Valor = alternativa;               
                a.Imagem = string.IsNullOrEmpty(imagem)? null : imagem;

                db.Alternativas.Add(a);
                db.SaveChanges();
                return Content(a.Id.ToString());
            }
            catch
            {
                return Content("Error");
            }
        }

        public JsonResult Subcategorias(int categoria)
        {
            var r = from k in db.Subcategorias
                    where k.Pai == categoria
                    select new Models.SubCategoria()
                    {
                        Id = k.Id,
                        Nome = k.Nome.Trim()
                    };

            return Json(r.ToList(), JsonRequestBehavior.AllowGet); 
        }
        [HttpPost]
        public ContentResult UploadImage()
        {
            try
            {

                string FileName = "";
                HttpPostedFileBase hpf = Request.Files["imagem"] as HttpPostedFileBase;
                if (hpf != null)
                {
                    var TimeStamp = DateTime.Now.ToString("ddMyyyyHHmmsf");
                    FileName = "img_" + TimeStamp + Path.GetExtension(hpf.FileName);
                    string savedFileName = Path.Combine(Server.MapPath("~/Content/Images"), FileName);
                    hpf.SaveAs(savedFileName); // Save the file                }
                }

                
                return Content(FileName);
            }
            catch
            {
                return Content("Error");
            }
        }

        [HttpPost]
        public ActionResult Save(string enunciado, int[] alternativa, int correta, int categoria, int subcategoria, string imagem)
        {
            //cria um novo objeto do tipo questoes e preenche com os dados do formulário
            Questao q = new Questao();
            q.Enunciado = enunciado;

            foreach(var alt in alternativa)
            {
                var a = db.Alternativas.Find(alt);
                q.Alternativas.Add(a);               
            }

            q.Cat = subcategoria;
            q.Correta = correta;
            q.Imagem = string.IsNullOrEmpty(imagem)? null : imagem;

            //adiciona o objeto à estrutura do banco de dados
            db.Questoes.Add(q);
            //salva as alterações no banco de dados
            db.SaveChanges();


            return Redirect("Index");            
        }

        public ActionResult Editar(int? id)
        {
            var item = db.Questoes.Find(id);
            ViewBag.Categorias = db.Categorias.Where(p=> p.Id != item.Subcategorias.Categorias.Id).ToList();
            ViewBag.SubCategorias = db.Subcategorias.Where(p => p.Id != item.Cat && p.Pai == item.Subcategorias.Categorias.Id).ToList();

            return View(item);
        }

        public ActionResult Novo()
        {
            ViewBag.Categorias = db.Categorias.ToList();
            return View();
        }
    }
}