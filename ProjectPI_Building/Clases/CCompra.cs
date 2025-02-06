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
        public string TipoRecibo { get; set; }      // varchar(30)
        public DateTime FechaIngreso { get; set; }  // datetime
        public int IdProveedor { get; set; }        // integer

        // Propiedades para Detalle de Compra
        public int IdDetalleCompra { get; set; }    // integer NOT NULL
        public int CantidadEntrada { get; set; }     // integer NULL
        public int IdProducto { get; set; }          // integer NULL
        public decimal Subtotal { get; set; }        // decimal(10,2)
        public decimal PrecioCompra { get; set; }    // decimal(10,2)
        public decimal PrecioVenta { get; set; }     // decimal(10,2)

        // Constructor vacío (por si necesitas crear la clase sin inicializar datos)
        public CCompra() { }
    }
}
