using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectPI_Building.Servicios
{
    public class Validator
    {
        // Expresión regular para validar RUC (debe comenzar con 20, 10, 15, 16 o 17)
        private static readonly Regex rucRegex = new Regex(@"^(20|10|15|16|17)\d{8}\d$");

        // Expresión regular para validar URL (cualquier página web)
        private static readonly Regex urlRegex = new Regex(@"^(www\.)?[a-zA-Z0-9\-]+\.[a-zA-Z]{2,}(\.[a-zA-Z]*)?$");

        public static bool ValidarRUC(string ruc)
        {
            return rucRegex.IsMatch(ruc);
        }

        public static bool ValidarURL(string url)
        {
            return urlRegex.IsMatch(url);
        }
    }
}
