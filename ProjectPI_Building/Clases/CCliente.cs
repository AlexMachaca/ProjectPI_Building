using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CCliente
    {
        // Propiedades
        public int IdCliente { get; set; }
        public string CorreoElectronico { get; set; }
        public int IdPersona { get; set; } 

        // Constructor vacío
        public CCliente()
        {
            // Inicialización opcional si se requiere
        }

        // Constructor con parámetros (opcional)
        public CCliente(int idCliente, string correoElectronico, int idPersona)
        {
            IdCliente = idCliente;
            CorreoElectronico = correoElectronico;
            IdPersona = idPersona;
        }
    }
}
