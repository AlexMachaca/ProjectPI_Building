using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CProducto
    {
        public string Idproducto { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public decimal Preciocompra { get; set; } // Cambiado a decimal
        public decimal Precioventa { get; set; } // Cambiado a decimal
        public decimal Preciounitario { get; set; } // Cambiado a decimal
        public DateTime Fechaactualizacion { get; set; }
    }
}
