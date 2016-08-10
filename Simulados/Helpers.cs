using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulados
{
    public static class Extensions
    {
        public static string Reduce(this string text, int len)
        {
            if (text.Length < len) return text;
            return text.Substring(0, len) + "...";
        }
        public static string TryTrim(this string text)
        {
            if (!string.IsNullOrEmpty(text))
                return text.Trim();
            else return text;
        }
        public static string CalculaTotal(int acertos, int total)
        {
            float x = (acertos * 100) / total;
            return string.Format("{0}% {1}/{2}", Math.Round(x, 2), acertos, total);
        }
    }
}
