using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CRecibo
    {
        public int IdRecibo { get; set; }
        public string TipoRecibo { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime Hora { get; set; }
        public decimal TotalGravado { get; set; }
        public decimal IGV { get; set; }
        public decimal Total { get; set; }
        public string TotalLetras { get; set; }
        public string FormaPago { get; set; }
        public int IdPersonal { get; set; }
        public int IdCliente { get; set; }
        public string TipoMoneda { get; set; }
        public string NroRecibo { get; set; }
        public string TipoServicio { get; set; }
        public string NombreCliente { get; set; }
    }
}
