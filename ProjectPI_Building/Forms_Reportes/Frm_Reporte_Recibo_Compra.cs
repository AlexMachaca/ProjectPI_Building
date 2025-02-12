using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Reportes
{
    public partial class Frm_Reporte_Recibo_Compra : Frm_Template_Reporte
    {
        public Frm_Reporte_Recibo_Compra()
        {
            InitializeComponent();


        }
        private void fill_data()
        {
            //obtener el valor del combobox
            string tipo = cb_tipo_recibo.Text;
            //verificar si esta vacio
            if (tipo == "")
            {
                MessageBox.Show("Seleccione un tipo de recibo");
                return;
            }
            DateTime startDate = dtp_fecha_inicio.Value;
            DateTime endDate = dtp_fecha_fin.Value;

            Connection_Compra connection = new Connection_Compra();

            DataSet reciboData = connection.FillReciboByDateRange(startDate, endDate, tipo);

            if (reciboData != null)
            {
                // Process the dataSet (e.g., display it in a DataGridView, generate a report, etc.)
                // For example:
                // dataGridView1.DataSource = reciboData.Tables["ReciboCompra"];
                dgv_recibo_compra.DataSource = connection.FillReciboByDateRange(startDate, endDate, tipo).Tables["ReciboCompra"];
            }
            else
            {
                // Handle the error (e.g., display an error message to the user)
                MessageBox.Show("Failed to retrieve recibo data. See error log for details.");
            }
        }

        private void dtp_fecha_inicio_ValueChanged(object sender, EventArgs e)
        {
            fill_data();
        }

        private void dtp_fecha_fin_ValueChanged(object sender, EventArgs e)
        {
            fill_data();
        }

        private void cb_tipo_recibo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_data();
        }

        private void Frm_Reporte_Recibo_Compra_Load(object sender, EventArgs e)
        {
            //Darle el valor de la primera opcion al combobox
            cb_tipo_recibo.SelectedIndex = 0;
            //Darle la fecha del mes actual a los DateTimePicker
            dtp_fecha_inicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtp_fecha_fin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        }

        private void dgv_recibo_compra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener el idReciboCompra de la fila seleccionada
                string idReciboCompra = dgv_recibo_compra.Rows[e.RowIndex].Cells["Nro_Compra"].Value.ToString(); // Asegúrate que "Nro_Compra" es el nombre correcto de la columna

                // Crear una instancia del formulario Frm_Reporte_Detalle_Compra
                Frm_Reporte_Detalle_Compra frmDetalle = new Frm_Reporte_Detalle_Compra(idReciboCompra);

                // Mostrar el formulario
                frmDetalle.ShowDialog(); // Usar ShowDialog para que se abra como una ventana modal
            }
        }

        private string GenerarHtmlReporteRecibos(DataSet reciboData, DateTime fechaInicio, DateTime fechaFin, string tipoRecibo)
        {
            // Leer la plantilla HTML
            string htmlTemplatePath = Path.Combine(@"C:\Users\ALEX\source\repos\ProjectPI_Building\ProjectPI_Building\Html\reporte_recibos_template.html"); // Ajusta la ruta si es necesario
            string htmlTemplate = File.ReadAllText(htmlTemplatePath);

            // Reemplazar los valores dinámicos
            htmlTemplate = htmlTemplate.Replace("<span id=\"tipo-recibo\"></span>", tipoRecibo);
            htmlTemplate = htmlTemplate.Replace("<span id=\"fecha-inicio\"></span>", fechaInicio.ToString("dd/MM/yyyy"));
            htmlTemplate = htmlTemplate.Replace("<span id=\"fecha-fin\"></span>", fechaFin.ToString("dd/MM/yyyy"));
            htmlTemplate = htmlTemplate.Replace("<span id=\"fecha-generacion\"></span>", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            // Construir las filas de la tabla
            StringBuilder tablaRecibosHtml = new StringBuilder();
            if (reciboData != null && reciboData.Tables.Count > 0)
            {
                foreach (DataRow fila in reciboData.Tables[0].Rows)
                {
                    tablaRecibosHtml.Append("<tr>");
                    tablaRecibosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{fila["Nro_Compra"]}</td>");
                    tablaRecibosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{fila["Nombre_Proveedor"]}</td>");
                    tablaRecibosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{fila["Documento"]}</td>");
                    tablaRecibosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{((DateTime)fila["Fecha"]).ToString("dd/MM/yyyy")}</td>");
                    tablaRecibosHtml.Append("</tr>");
                }
            }

            // Insertar las filas en la tabla
            htmlTemplate = htmlTemplate.Replace("<tbody id=\"tabla-recibos\">\r\n                <!-- Aquí se insertarán las filas dinámicamente -->\r\n            </tbody>", $"<tbody id=\"tabla-recibos\">\r\n{tablaRecibosHtml.ToString()}\r\n            </tbody>");

            return htmlTemplate;
        }

        public bool GenerarPdfDesdeHtml(string html, string outputPath)
        {
            try
            {
                ConverterProperties converterProperties = new ConverterProperties();

                using (FileStream pdfStream = new FileStream(outputPath, FileMode.Create))
                {
                    PdfWriter writer = new PdfWriter(pdfStream);
                    PdfDocument pdfDocument = new PdfDocument(writer);

                    HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el PDF: " + ex.Message);
                return false;
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string tipoRecibo = cb_tipo_recibo.Text.Trim();
            DateTime fechaInicio = dtp_fecha_inicio.Value;
            DateTime fechaFin = dtp_fecha_fin.Value;

            // Obtener los datos de los recibos
            Connection_Compra connection = new Connection_Compra();
            DataSet reciboData = connection.FillReciboByDateRange(fechaInicio, fechaFin, tipoRecibo);

            // Generar el HTML del reporte
            string htmlReporte = GenerarHtmlReporteRecibos(reciboData, fechaInicio, fechaFin, tipoRecibo);

            // Especificar la ruta de guardado para el PDF
            string rutaPdf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Reporte_Recibos_{tipoRecibo}_{fechaInicio.ToString("yyyyMMdd")}_{fechaFin.ToString("yyyyMMdd")}.pdf");

            // Generar el PDF desde el HTML
            if (GenerarPdfDesdeHtml(htmlReporte, rutaPdf))
            {
                MessageBox.Show($"Reporte generado y guardado en: {rutaPdf}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo(rutaPdf) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error al generar el reporte en PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
