using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CProveedor
    {
        // Propiedades
        public int IdProveedor { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }

        // Constructor vacío
        public CProveedor()
        {
            // Inicialización opcional si se requiere
        }

        // Constructor con parámetros (opcional)
        public CProveedor(int idProveedor, string tipoDocumento, string nroDocumento, string nombre, string direccion, string celular, string correoElectronico)
        {
            IdProveedor = idProveedor;
            TipoDocumento = tipoDocumento;
            NroDocumento = nroDocumento;
            Nombre = nombre;
            Direccion = direccion;
            Celular = celular;
            CorreoElectronico = correoElectronico;
        }
    }
}
