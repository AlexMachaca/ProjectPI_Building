using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CEmpresa
    {
        // Propiedades
        public string RUC { get; set; }
        public string Nombre { get; set; }
        public string PaginaWeb { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }

        // Constructor vacío
        public CEmpresa()
        {
            // Inicialización opcional si se requiere
        }

        // Constructor con parámetros (opcional)
        public CEmpresa(string ruc, string nombre, string paginaWeb, string facebook, string youtube)
        {
            RUC = ruc;
            Nombre = nombre;
            PaginaWeb = paginaWeb;
            Facebook = facebook;
            Youtube = youtube;
        }
    }
}
