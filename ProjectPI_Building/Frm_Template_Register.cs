using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPI_Building
{
    public partial class Frm_Template_Register : Form
    {
        private bool isDragging = false;
        private Point startPoint;
        public Frm_Template_Register()
        {
            InitializeComponent();
        }

        private void Frm_Template_Register_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {

                Point newPosition = this.Location;
                newPosition.X += e.X - startPoint.X;
                newPosition.Y += e.Y - startPoint.Y;
                this.Location = newPosition;
                this.Location = newPosition;
            }
        }

        private void Frm_Template_Register_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void Frm_Template_Register_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {

        }
    }
}
