using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CDetalleCompra
    {
        public int IdDetalleCompra { get; set; }    // integer NOT NULL
        public int CantidadEntrada { get; set; }     // integer NULL
        public int IdProducto { get; set; }          // integer NULL

        public string NombreProducto { get; set; }   // varchar(50)
        public decimal Subtotal { get; set; }        // decimal(10,2)
        public decimal PrecioCompra { get; set; }    // decimal(10,2)
        public decimal PrecioVenta { get; set; }     // decimal(10,2)

        //Contructor vacio
        public CDetalleCompra() { }
    }
}
