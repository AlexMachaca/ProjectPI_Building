using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPI_Building.Forms_Search;

namespace ProjectPI_Building
{
    public partial class Frm_Administracion : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        public Frm_Administracion()
        {
            InitializeComponent();
        }

        private void btn_persona_Click(object sender, EventArgs e)
        {
            Frm_SearchPersona frm_searchPersona = new Frm_SearchPersona();
            frm_searchPersona.ShowDialog();
        }

        private void btn_personal_Click(object sender, EventArgs e)
        {
            Frm_SearchPersonal frm_searchPersonal = new Frm_SearchPersonal();
            frm_searchPersonal.ShowDialog();
        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            Frm_SearchCliente frm_searchCliente = new Frm_SearchCliente();
            frm_searchCliente.ShowDialog();
        }

        private void btn_producto_Click(object sender, EventArgs e)
        {
            Frm_Producto_Search frm_producto_search = new Frm_Producto_Search();
            frm_producto_search.ShowDialog();
        }

        private void btn_empresa_Click(object sender, EventArgs e)
        {
            Frm_SearchEmpresa frm_searchEmpresa = new Frm_SearchEmpresa();
            frm_searchEmpresa.ShowDialog();
        }

        private void btn_sucursal_Click(object sender, EventArgs e)
        {
            Frm_SearchSucursal frm_searchSucursal = new Frm_SearchSucursal();
            frm_searchSucursal.ShowDialog();
        }

        private void btn_proveedor_Click(object sender, EventArgs e)
        {
            Frm_Proveedor_Search frm_proveedor_search = new Frm_Proveedor_Search();
            frm_proveedor_search.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e) => this.Close();

        private void btn_maximizar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Maximized;

        private void btn_minimizar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void Frm_Administracion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void Frm_Administracion_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPosition = PointToScreen(e.Location);
                Location = new Point(currentScreenPosition.X - startPoint.X, currentScreenPosition.Y - startPoint.Y);
            }
        }

        private void Frm_Administracion_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
