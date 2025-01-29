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
    public partial class Frm_Template_Search : Form
    {
        private bool isDragging = false;
        private Point startPoint;
        public Frm_Template_Search()
        {
            InitializeComponent();
        }

        private void Frm_Template_Search_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);//Registrar el punto de inicio
            }
        }

        private void Frm_Template_Search_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {

                Point newPosition = this.Location;
                newPosition.X += e.X - startPoint.X;
                newPosition.Y += e.Y - startPoint.Y;
                this.Location = newPosition;
                this.Location = newPosition;//Mueve el formulario
            }
        }

        private void Frm_Template_Search_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
