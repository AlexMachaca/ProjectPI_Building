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
    public partial class Frm_Reporte_Producto : Frm_Template_Reporte
    {
        public Frm_Reporte_Producto()
        {
            InitializeComponent();
        }

        private void fillData()
        {
            string categoria = cb_categoria.Text.Trim();
            if (string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Seleccione una categoría de producto");
                return;
            }
            Connection_Producto connection = new Connection_Producto();
            DataSet productoData = connection.Producto_por_categoria(categoria);
            if (productoData != null)
            {
                dgv_producto.DataSource = productoData.Tables["ProductoCategoria"];
            }
            else
            {
                MessageBox.Show("Error al cargar los datos. Consulte el registro de errores para más detalles.");
            }
        }

        private void cb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillData();
        }

        private void Frm_Reporte_Producto_Load(object sender, EventArgs e)
        {
            //inciar el comboBox con el primer valor
            cb_categoria.SelectedIndex = 0;
        }

        //GUARDAR EN PDF
        private string GenerarHtmlReporte(DataSet productoData, string categoria)
        {
            // Leer la plantilla HTML
            string htmlTemplatePath = Path.Combine(@"C:\Users\ALEX\source\repos\ProjectPI_Building\ProjectPI_Building\Html\reporte_productos_template.html"); // Ajusta la ruta si es necesario
            string htmlTemplate = File.ReadAllText(htmlTemplatePath);

            // Reemplazar el nombre de la categoría
            htmlTemplate = htmlTemplate.Replace("<span id=\"categoria-nombre\"></span>", categoria);

            // Reemplazar la fecha de generación
            htmlTemplate = htmlTemplate.Replace("<span id=\"fecha-generacion\"></span>", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            // Construir las filas de la tabla
            StringBuilder tablaProductosHtml = new StringBuilder();
            if (productoData != null && productoData.Tables.Count > 0)
            {
                foreach (DataRow fila in productoData.Tables[0].Rows)
                {
                    tablaProductosHtml.Append("<tr>");
                    tablaProductosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{fila["idProducto"]}</td>");
                    tablaProductosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{fila["descripcion"]}</td>");
                    tablaProductosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{fila["unidad"]}</td>");
                    tablaProductosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{fila["cantidad"]}</td>");
                    tablaProductosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{fila["stock"]}</td>");
                    tablaProductosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{Convert.ToDecimal(fila["preciocompra"]):N2}</td>");
                    tablaProductosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{Convert.ToDecimal(fila["precioventa"]):N2}</td>");
                    tablaProductosHtml.Append($"<td style=\"border: 1px solid #ccc; padding: 8px;\">{Convert.ToDecimal(fila["preciounitario"]):N2}</td>");
                    tablaProductosHtml.Append("</tr>");
                }
            }

            // Insertar las filas en la tabla
            htmlTemplate = htmlTemplate.Replace("<tbody id=\"tabla-productos\">\r\n                <!-- Aquí se insertarán las filas dinámicamente -->\r\n            </tbody>", $"<tbody id=\"tabla-productos\">\r\n{tablaProductosHtml.ToString()}\r\n            </tbody>");

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
            // Obtener la categoría seleccionada
            string categoria = cb_categoria.Text.Trim();

            // Obtener los datos de los productos
            Connection_Producto connection = new Connection_Producto();
            DataSet productoData = connection.Producto_por_categoria(categoria);

            // Generar el HTML del reporte
            string htmlReporte = GenerarHtmlReporte(productoData, categoria);

            // Especificar la ruta de guardado para el PDF
            string rutaPdf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Reporte_Productos_{categoria}.pdf");

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
