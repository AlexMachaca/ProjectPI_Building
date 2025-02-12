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

namespace ProjectPI_Building
{
    public partial class Frm_home : Form
    {
        private bool isDragging = false;
        private Point startPoint;
        public Frm_home()
        {
            InitializeComponent();
        }

        private void Frm_home_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Frm_home_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                //Calcular nueva posicion del formulario
                //Point newLocation = new Point(this.Left + e.X - startPoint.X, this.Top + e.Y - startPoint.Y);
                Point newPosition = this.Location;
                newPosition.X += e.X - startPoint.X;
                newPosition.Y += e.Y - startPoint.Y;
                this.Location = newPosition;
                this.Location = newPosition;//Mueve el formulario
            }
        }

        private void Frm_home_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);//Registrar el punto de inicio
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Compra_Click(object sender, EventArgs e)
        {
            Frm_Login_Admin frm_login=new Frm_Login_Admin();
            DialogResult result = frm_login.ShowDialog();

            if (result == DialogResult.OK)
            {
                // El login fue exitoso, abre frm_compra
                //Frm_Compra_Producto compraForm = new Frm_Compra_Producto();
                //compraForm.ShowDialog();
                //obtener el NameUser del login
                string user = frm_login.NameUser;
                
                Frm_Page_Admin adminForm = new Frm_Page_Admin(user);
                adminForm.ShowDialog();

            }
            else
            {
                // El login falló o fue cancelado
                // Muestra un mensaje de error o realiza alguna otra acción
            }
            frm_login.Dispose(); // Importante: Liberar los recursos
        }
    }
}
