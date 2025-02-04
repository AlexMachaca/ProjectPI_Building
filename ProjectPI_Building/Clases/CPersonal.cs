using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CPersonal
    {
        // Propiedades
        public int IdPersonal { get; set; }
        public string Categoria { get; set; }
        public string Turno { get; set; }
        public int? HorasTrabajo { get; set; } // Nullable para permitir valores nulos
        public string Usuario { get; set; }
        public string Pasword { get; set; }
        public int IdPersona { get; set; } 

        // Constructor vacío
        public CPersonal()
        {
            // Inicialización opcional si se requiere
        }

        // Constructor con parámetros (opcional)
        public CPersonal(int idPersonal, string categoria, string turno, int? horasTrabajo, string usuario, string pasword, int idPersona)
        {
            IdPersonal = idPersonal;
            Categoria = categoria;
            Turno = turno;
            HorasTrabajo = horasTrabajo;
            Usuario = usuario;
            Pasword = pasword;
            IdPersona = idPersona;
        }
    }
}
