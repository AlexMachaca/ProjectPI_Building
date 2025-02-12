using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPI_Building.Forms_Register;
using ProjectPI_Building.Forms_Reportes;

namespace ProjectPI_Building
{
    public partial class Frm_Page_Admin : Form
    {
        private string user;
        public Frm_Page_Admin(string userName)
        {
            InitializeComponent();
            this.user = userName;
        }

        private void Frm_Page_Admin_Load(object sender, EventArgs e)
        {
            lb_userName.Text = user;
        }

        private void btn_minimizar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void btn_maximizar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Maximized;

        private void btn_salir_Click(object sender, EventArgs e) => this.Close();

        private void btn_compra_producto_Click(object sender, EventArgs e)
        {
            Frm_Compra_Producto frm_compra_producto = new Frm_Compra_Producto();
            frm_compra_producto.ShowDialog();
        }

        private void btn_contrato_personal_Click(object sender, EventArgs e)
        {
            Frm_Contrato frm_contrato_personal = new Frm_Contrato();
            frm_contrato_personal.ShowDialog();
        }

        private void btn_reporte_producto_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Producto frm_reporte_producto = new Frm_Reporte_Producto();
            frm_reporte_producto.ShowDialog();
        }

        private void btn_reporte_compras_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Recibo_Compra frm_reporte_compras = new Frm_Reporte_Recibo_Compra();
            frm_reporte_compras.ShowDialog();
        }
    }
}
