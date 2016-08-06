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
        public int? Selecionada { get; set; }
        public int Correta { get; set; }
    }
    public class Alternativa
    {
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public string Imagem { get; set; }
    }

    public enum StatusType
    {
        Aberto,
        Finalizado
    }

    public class Resposta
    {
        public StatusType Status { get; set; }

        public Resposta(List<Questao> Respostas, StatusType status)
        {
            this.Respostas = Respostas;
            this.Status = status;
        }
        public int TotalQuestoes { get { return Respostas.Count; } }
        public List<Questao> Respostas { get; set; }
        public int TotalAcertos
        {
            get
            {
                return Respostas.Where(r => r.Selecionada == r.Correta).Count();
            }
        }
        public int TotalErros { get { return TotalQuestoes - TotalAcertos; } }
    }
}
