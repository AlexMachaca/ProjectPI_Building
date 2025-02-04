using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CCompra
    {
        // Propiedades para Recibo de Compra
        public string IdReciboCompra { get; set; } // char(18) NOT NULL
        public DateTime FechaIngreso { get; set; }   // datetime
        public int IdProveedor { get; set; }    // integer

        // Propiedades para Detalle de Compra
        public int IdDetalleCompra { get; set; } // integer
        public int CantidadEntrada { get; set; }   // integer NULL
        public int IdProducto { get; set; }        // integer NULL

        // Constructor vacío (por si necesitas crear la clase sin inicializar datos)
        public CCompra() { }
    }
}
