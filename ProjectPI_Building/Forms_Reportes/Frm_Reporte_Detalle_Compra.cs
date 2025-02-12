using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Reportes
{
    public partial class Frm_Reporte_Detalle_Compra : Form
    {
        private string idReciboCompra;
        public Frm_Reporte_Detalle_Compra(string idReciboCompra)
        {
            InitializeComponent();
            this.idReciboCompra = idReciboCompra; // Guardar el idReciboCompra
        }
        private void LlenarDataGridView()
        {
            Connection_Compra connection = new Connection_Compra();
            DataSet detallesData = connection.ObtenerDetallesCompraPorIdRecibo(idReciboCompra);

            if (detallesData != null && detallesData.Tables.Count > 0)
            {
                dgv_detalle_compra.DataSource = detallesData.Tables[0]; // Asigna el DataTable al DataGridView
            }
            else
            {
                // Manejar el caso en que no se encontraron detalles
                dgv_detalle_compra.DataSource = null;
                MessageBox.Show("No se encontraron detalles para el recibo con ID: " + idReciboCompra);
            }
        }

        private void Frm_Reporte_Detalle_Compra_Load(object sender, EventArgs e)
        {
            // Llama a la función para llenar el DataGridView cuando el formulario se carga
            LlenarDataGridView();
        }
    }
}
