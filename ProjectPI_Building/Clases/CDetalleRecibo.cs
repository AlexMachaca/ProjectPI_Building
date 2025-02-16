using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CDetalleRecibo
    {
        public string IdDetalleRecibo { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public int TipoProductoServicio { get; set; }
        public int IdRecibo { get; set; }
        public int Codigo { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Descripcion { get; set; }
    }
}
