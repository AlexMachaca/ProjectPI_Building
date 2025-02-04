using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CProducto
    {
        // Propiedades
        public int IdProducto { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public int? Cantidad { get; set; } // Nullable para permitir valores nulos
        public int? Stock { get; set; }    // Nullable para permitir valores nulos
        public decimal? PrecioCompra { get; set; } // Nullable para permitir valores nulos
        public decimal? PrecioVenta { get; set; }  // Nullable para permitir valores nulos
        public decimal? PrecioUnitario { get; set; } // Nullable para permitir valores nulos
        public DateTime FechaActualizacion { get; set; } // Nullable para permitir valores nulos

        // Constructor vacío
        public CProducto()
        {
            // Inicialización opcional si se requiere
        }

        // Constructor con parámetros (opcional)
        public CProducto(int idProducto, string categoria, string descripcion, string unidad, int? cantidad, int? stock, decimal? precioCompra, decimal? precioVenta, decimal? precioUnitario, DateTime fechaActualizacion)
        {
            IdProducto = idProducto;
            Categoria = categoria;
            Descripcion = descripcion;
            Unidad = unidad;
            Cantidad = cantidad;
            Stock = stock;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
            PrecioUnitario = precioUnitario;
            FechaActualizacion = fechaActualizacion;
        }
    }
}
