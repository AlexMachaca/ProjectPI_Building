using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CPersona
    {
        // Propiedades
        public int IdPersona { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public char Genero { get; set; }
        public DateTime? FechaNac { get; set; } // Nullable para permitir valores nulos
        public string Celular { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

        // Constructor vacío
        public CPersona()
        {
            // Inicialización opcional si se requiere
        }

        // Constructor con parámetros (opcional)
        public CPersona(int idPersona, string apellidos, string nombre, char genero, DateTime? fechaNac, string celular, string tipoDocumento, string numeroDocumento)
        {
            IdPersona = idPersona;
            Apellidos = apellidos;
            Nombre = nombre;
            Genero = genero;
            FechaNac = fechaNac;
            Celular = celular;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
        }
    }
}
