using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CPersonal
    {
        public int IdPersonal { get; set; } // ID del personal
        public string Categoria { get; set; } // Categoría del personal
        public string Turno { get; set; } // Turno del personal
        public int HorasTrabajo { get; set; } // Horas de trabajo
        public string Usuario { get; set; } // Nombre de usuario
        public string Pasword { get; set; } // Contraseña
        public int IdPersona { get; set; } // ID de la persona asociada
    }
}
