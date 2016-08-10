using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public static class Extensions
    {
        public static string Reduce(this string text, int len)
        {
            if (text.Length < len) return text;
            return text.Substring(0, len) + "...";
        }
    }
}
