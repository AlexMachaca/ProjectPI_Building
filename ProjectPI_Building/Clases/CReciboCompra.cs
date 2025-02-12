using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CReciboCompra
    {
        // Propiedades para Recibo de Compra
        public string IdReciboCompra { get; set; } // char(18) NOT NULL
        public string TipoRecibo { get; set; }      // varchar(30)
        public DateTime FechaIngreso { get; set; }  // datetime
        public int IdProveedor { get; set; }        // integer


        // Constructor vacío (por si necesitas crear la clase sin inicializar datos)
        public CReciboCompra() { }

    }
}
