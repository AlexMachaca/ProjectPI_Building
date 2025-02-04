using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CSucursal
    {
        // Propiedades
        public int IdSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string RUC { get; set; }

        // Constructor vacío
        public CSucursal()
        {
            // Inicialización opcional si se requiere
        }

        // Constructor con parámetros (opcional)
        public CSucursal(int idSucursal, string direccion, string telefono, string ruc)
        {
            IdSucursal = idSucursal;
            Direccion = direccion;
            Telefono = telefono;
            RUC = ruc;
        }
    }
}
