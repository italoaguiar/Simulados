using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulados.Models
{
    public class Simulado
    {
        public string Categoria { get; set; }
        public List<Questao> Questoes { get; set; }
    }

    public class Questao
    {
        public string Enunciado { get; set; }
        public string Imagem { get; set; }
        public List<Alternativa> Alternativas { get; set; }

        public Alternativa AlternativaCorreta
        {
            get
            {
                return null;
            }

            set
            {
            }
        }
    }
    public class Alternativa
    {
        public string Enunciado { get; set; }
        public string Imagem { get; set; }
    }
}
