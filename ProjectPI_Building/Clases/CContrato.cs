using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CContrato
    {
        public int IdContrato { get; set; }
        public DateTime FechaIngreso { get; set; } // Usar DateTime? para permitir valores nulos
        public DateTime FechaTermino { get; set; } // Usar DateTime? para permitir valores nulos
        public int IdPersonal { get; set; } // Usar int? para permitir valores nulos
        public int IdTipocontrato { get; set; } // Usar int? para permitir valores nulos

        public CContrato()
        {
            // Constructor vacío
        }
        public CContrato(int idContrato, DateTime fechaIngreso, DateTime fechaTermino, int idPersonal, int idTipocontrato)
        {
            IdContrato = idContrato;
            FechaIngreso = fechaIngreso;
            FechaTermino = fechaTermino;
            IdPersonal = idPersonal;
            IdTipocontrato = idTipocontrato;
        }
    }
}
