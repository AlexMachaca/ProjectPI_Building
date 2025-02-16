using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ProjectPI_Building
{
    public partial class Frm_Remuneraciones : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        private string connectionString = "Server=ROG\\SQLEXPRESS;Database=BDBuilding3;User ID=sa;Password=1111;Encrypt=False;";

        public Frm_Remuneraciones()
        {
            InitializeComponent();

            // Llenar ComboBox con los meses (Enero - Diciembre)
            cmbMes.DataSource = Enumerable.Range(1, 12)
                .Select(m => new { Value = m, Name = new DateTime(1, m, 1).ToString("MMMM") })
                .ToList();
            cmbMes.DisplayMember = "Name";
            cmbMes.ValueMember = "Value";

            // Llenar ComboBox con los años (Últimos 5 años)
            cmbAnio.DataSource = Enumerable.Range(DateTime.Now.Year - 5, 6).ToList();
            cmbAnio.SelectedItem = DateTime.Now.Year;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Frm_Remuneraciones_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPosition = PointToScreen(e.Location);
                Location = new Point(currentScreenPosition.X - startPoint.X, currentScreenPosition.Y - startPoint.Y);
            }
        }

        private void Frm_Remuneraciones_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void Frm_Remuneraciones_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int mes = (int)cmbMes.SelectedValue;
            int anio = (int)cmbAnio.SelectedItem;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"
                SELECT 
                    p.idPersonal,
                    CONCAT(pe.nombre, ' ', pe.apellidos) AS Empleado,
                    SUM(CAST(DATEDIFF(MINUTE, ca.HoraIngreso, ca.HoraSalida) AS FLOAT) / 60) AS TotalHoras,
                    SUM(ca.HorasExtras) AS HorasExtras,
                    (SUM(CAST(DATEDIFF(MINUTE, ca.HoraIngreso, ca.HoraSalida) AS FLOAT) / 60) * 10) + 
                    (SUM(ca.HorasExtras) * 15) AS PagoTotal
                FROM Control_asistencia ca
                JOIN Personal p ON ca.idPersonal = p.idPersonal
                JOIN Persona pe ON p.idPersona = pe.idPersona
                WHERE MONTH(ca.FechaTrabajo) = @mes AND YEAR(ca.FechaTrabajo) = @anio
                GROUP BY p.idPersonal, pe.nombre, pe.apellidos";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@anio", anio);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRemuneraciones.DataSource = dt;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Obtener el último ID de Remuneraciones
                string getIdQuery = "SELECT ISNULL(MAX(idRemuneracion), 0) + 1 FROM Remuneraciones";
                SqlCommand getIdCmd = new SqlCommand(getIdQuery, con);
                int newIdRemuneracion = (int)getIdCmd.ExecuteScalar(); // Nuevo ID de Remuneración

                foreach (DataGridViewRow row in dgvRemuneraciones.Rows)
                {
                    if (row.Cells["Empleado"].Value != null)
                    {
                        // Insertar en la tabla Remuneraciones
                        string insertRemuneracionQuery = @"
                INSERT INTO Remuneraciones (idRemuneracion, idPersonal, pagototal, fechapago, descuentotal)
                VALUES (@idRemuneracion, @idPersonal, @pagoTotal, GETDATE(), @descuento)";

                        SqlCommand cmdRemuneracion = new SqlCommand(insertRemuneracionQuery, con);
                        cmdRemuneracion.Parameters.AddWithValue("@idRemuneracion", newIdRemuneracion);
                        cmdRemuneracion.Parameters.AddWithValue("@idPersonal", row.Cells["idPersonal"].Value);
                        cmdRemuneracion.Parameters.AddWithValue("@pagoTotal", row.Cells["PagoTotal"].Value);
                        cmdRemuneracion.Parameters.AddWithValue("@descuento", 0); // Puedes cambiar esto si hay descuentos

                        cmdRemuneracion.ExecuteNonQuery();

                        // Insertar detalles en Detalle_remuneracion
                        InsertarDetalleRemuneracion(con, newIdRemuneracion, row);

                        newIdRemuneracion++; // Incrementar manualmente el ID para la siguiente inserción
                    }
                }

                MessageBox.Show("Remuneraciones y detalles guardados correctamente.");
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Guardar Recibo de Pago"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    pdfDoc.Add(new Paragraph("Recibo de Pago\n"));
                    pdfDoc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}\n\n"));

                    PdfPTable table = new PdfPTable(4);
                    table.AddCell("Empleado");
                    table.AddCell("Total Horas");
                    table.AddCell("Horas Extras");
                    table.AddCell("Pago Total");

                    foreach (DataGridViewRow row in dgvRemuneraciones.Rows)
                    {
                        if (row.Cells["Empleado"].Value != null)
                        {
                            table.AddCell(row.Cells["Empleado"].Value.ToString());
                            table.AddCell(row.Cells["TotalHoras"].Value.ToString());
                            table.AddCell(row.Cells["HorasExtras"].Value.ToString());
                            table.AddCell($"S/{row.Cells["PagoTotal"].Value}");
                        }
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Close();
                    MessageBox.Show("Recibo generado correctamente.");
                }
            }
        }

        private void InsertarDetalleRemuneracion(SqlConnection con, int idRemuneracion, DataGridViewRow row)
        {
            // Obtener el próximo idDetalleremuneracion manualmente
            string getIdQuery = "SELECT ISNULL(MAX(idDetalleremuneracion), 0) + 1 FROM Detalle_remuneracion";
            SqlCommand getIdCmd = new SqlCommand(getIdQuery, con);
            int newIdDetalle = (int)getIdCmd.ExecuteScalar();

            string insertDetalleQuery = @"
            INSERT INTO Detalle_remuneracion (idDetalleremuneracion, Descricpion, monto, cantidad, subtotal, idRemuneracion, idControl)
            VALUES (@idDetalle, @Descricpion, @Monto, @Cantidad, @Subtotal, @idRemuneracion, @idControl)";

            SqlCommand cmdDetalle = new SqlCommand(insertDetalleQuery, con);
            cmdDetalle.Parameters.AddWithValue("@idDetalle", newIdDetalle);
            cmdDetalle.Parameters.AddWithValue("@Descricpion", "Pago Mensual");
            cmdDetalle.Parameters.AddWithValue("@Monto", row.Cells["PagoTotal"].Value);
            cmdDetalle.Parameters.AddWithValue("@Cantidad", 1);
            cmdDetalle.Parameters.AddWithValue("@Subtotal", row.Cells["PagoTotal"].Value);
            cmdDetalle.Parameters.AddWithValue("@idRemuneracion", idRemuneracion);
            cmdDetalle.Parameters.AddWithValue("@idControl", DBNull.Value); // Ajustar si tienes un idControl disponible

            cmdDetalle.ExecuteNonQuery();
        }

    }
}
