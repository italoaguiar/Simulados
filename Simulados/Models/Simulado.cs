using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulados.Models
{
    public class Questao
    {
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public string Imagem { get; set; }
        public List<Alternativa> Alternativas { get; set; }
        public int Selecionada { get; set; }
    }
    public class Alternativa
    {
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public string Imagem { get; set; }
    }
}
