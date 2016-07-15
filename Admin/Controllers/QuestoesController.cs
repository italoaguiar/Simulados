using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class QuestoesController : Controller
    {
        EF.DBConnection e = new EF.DBConnection();
        
        // GET: Questoes
        public ActionResult Index()
        {
            return View(e.Questoes.ToArray());
        }

        public ContentResult AddAlternativa(string alternativa)
        {
            try
            {
                EF.Alternativas a = new EF.Alternativas();
                a.Valor = alternativa;
                e.Alternativas.Add(a);
                e.SaveChanges();
                Alternativa alt = new Alternativa();
                alt.id = a.Id;
                alt.Valor = a.Valor;
                alt.Success = true;
                return Content(JsonConvert.SerializeObject(alt));
            }
            catch
            {
                Alternativa alt = new Alternativa();
                alt.Success = false;
                return Content(JsonConvert.SerializeObject(alt));
            }
        }

        public ActionResult Novo()
        {
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