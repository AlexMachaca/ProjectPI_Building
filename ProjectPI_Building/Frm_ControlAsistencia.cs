using ProjectPI_Building.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ProjectPI_Building
{
    public partial class Frm_ControlAsistencia : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        private readonly AsistenciaAndRemuneracionesService asistenciaService;

        public Frm_ControlAsistencia()
        {
            InitializeComponent();
            asistenciaService = new AsistenciaAndRemuneracionesService();
            CargarEmpleados();
            dtpFecha.Value = DateTime.Now;
            // Llamar a CargarAsistencias después de cargar empleados
            if (cmbEmpleado.Items.Count > 0)
            {
                cmbEmpleado.SelectedIndex = -1; 
                CargarAsistencias(); 
            }

            ActualizarEstadoAsistencia();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Frm_ControlAsistencia_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPosition = PointToScreen(e.Location);
                Location = new Point(currentScreenPosition.X - startPoint.X, currentScreenPosition.Y - startPoint.Y);
            }
        }
        private void Frm_ControlAsistencia_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }
        private void Frm_ControlAsistencia_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        // Cargar empleados en ComboBox
        private void CargarEmpleados()
        {
            try
            {
                DataTable empleados = asistenciaService.ObtenerEmpleados();
                if (empleados.Rows.Count > 0)
                {
                    cmbEmpleado.DataSource = empleados;
                    cmbEmpleado.DisplayMember = "NombreCompleto";
                    cmbEmpleado.ValueMember = "idPersonal";
                    cmbEmpleado.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se encontraron empleados registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAsistencias()
        {
            try
            {
                // Obtener todas las asistencias del día actual
                DataTable asistencias = asistenciaService.ObtenerTodasLasAsistencias(DateTime.Now.Date);

                // Cambiar el nombre de la columna si es necesario
                if (asistencias.Columns.Contains("NombreCompleto"))
                {
                    asistencias.Columns["NombreCompleto"].ColumnName = "Nombre del Empleado";
                }

                dgvAsistencias.DataSource = asistencias;

                // Ocultar la columna del ID del empleado si es necesario
                if (asistencias.Columns.Contains("idPersonal"))
                {
                    dgvAsistencias.Columns["idPersonal"].Visible = false;
                }

                ActualizarEstadoAsistencia();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cargar asistencias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task RegistrarEntradaAsync()
        {
            try
            {
                if (cmbEmpleado.SelectedValue != null)
                {
                    int idPersonal = Convert.ToInt32(cmbEmpleado.SelectedValue);
                    await Task.Run(() => asistenciaService.RegistrarEntrada(idPersonal));
                    MessageBox.Show("Entrada registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAsistencias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar entrada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RegistrarSalidaAsync()
        {
            try
            {
                if (cmbEmpleado.SelectedValue != null)
                {
                    int idPersonal = Convert.ToInt32(cmbEmpleado.SelectedValue);
                    await Task.Run(() => asistenciaService.RegistrarSalida(idPersonal));
                    MessageBox.Show("Salida registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAsistencias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar salida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            _ = RegistrarEntradaAsync();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            _ = RegistrarSalidaAsync();
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpleado.SelectedValue != null)
                {
                    if (int.TryParse(cmbEmpleado.SelectedValue.ToString(), out int idPersonal))
                    {
                        CargarDatosEmpleado(idPersonal);
                        ActualizarEstadoAsistencia(); // Asegúrate de llamar a este método aquí
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadoAsistencia()
        {
            try
            {
                if (cmbEmpleado.SelectedValue != null)
                {
                    int idPersonal = Convert.ToInt32(cmbEmpleado.SelectedValue);
                    string estado = asistenciaService.ObtenerEstadoAsistencia(idPersonal, dtpFecha.Value);
                    lblEstadoAsistencia.Text = estado;
                    lblEstadoAsistencia.ForeColor = estado switch
                    {
                        "En jornada" => System.Drawing.Color.Green,
                        "Finalizó jornada" => System.Drawing.Color.Red,
                        _ => System.Drawing.Color.Gray
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar estado de asistencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEmpleado(int idPersonal)
        {
            try
            {
                DataRow empleado = asistenciaService.ObtenerDatosEmpleado(idPersonal);

                if (empleado != null)
                {
                    txtTDocumento.Text = empleado["tipoDocumento"].ToString();
                    txtNroDoc.Text = empleado["numeroDocumento"].ToString();
                    txtTDocumento.Enabled = false;
                }
                else
                {
                    txtTDocumento.Text = string.Empty;
                    txtNroDoc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {
            //dtpHora.Value = DateTime.Now;
        }
    }
}