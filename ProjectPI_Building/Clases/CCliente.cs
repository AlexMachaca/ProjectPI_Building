using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CCliente
    {
        public string Idcliente { get; set; }
        public string Correoelectronico { get; set; }
        public string IdPersona { get; set; }
        public string TipoDocumento { get; set; } // Agregar esta propiedad
        public string NumeroDocumento { get; set; } // Agregar esta propiedad
        public string NombreCompleto { get; set; }
    }
}
