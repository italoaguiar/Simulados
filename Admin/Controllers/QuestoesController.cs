using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class QuestoesController : Controller
    {
        EF.DBConnection db = new EF.DBConnection();
        
        // GET: Questoes
        public ActionResult Index()
        {
            return View(db.Questoes.ToArray());
        }

        public ContentResult AddAlternativa(string alternativa, string imagem)
        {
            try
            {
                EF.Alternativas a = new EF.Alternativas();
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
            EF.Questoes q = new EF.Questoes();
            q.Enunciado = enunciado;

            foreach(var alt in alternativa)
            {
                var a = db.Alternativas.Find(alt);
                q.Alternativas1.Add(a);
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

        public ActionResult Novo()
        {
            ViewBag.Categorias = db.Categorias.ToList();
            return View();
        }
    }
    public class Alternativa
    {
        public int id { get; set; }
        public string Valor { get; set; }
        public bool Success { get; set; }
    }
}