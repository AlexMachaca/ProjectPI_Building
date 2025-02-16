namespace ProjectPI_Building
{
    public partial class Frmtemplate_Search : Form
    {

        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        public Frmtemplate_Search()
        {
            InitializeComponent();
        }
        private void Frmtemplate_Search_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void Frmtemplate_Search_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPosition = PointToScreen(e.Location);
                Location = new Point(currentScreenPosition.X - startPoint.X, currentScreenPosition.Y - startPoint.Y);
            }
        }

        private void Frmtemplate_Search_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}