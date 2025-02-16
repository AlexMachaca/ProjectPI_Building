using ProjectPI_Building.Clases;
using ProjectPI_Building.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using static ProjectPI_Building.Servicios.ClienteService;
using System.Globalization;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.Diagnostics;
using MigraDoc.DocumentObjectModel.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Image = MigraDoc.DocumentObjectModel.Shapes.Image;

namespace ProjectPI_Building
{
    public partial class Frm_VentadeProducto : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        private ClienteService clienteService = new ClienteService();
        private ProductService productService = new ProductService();
        private ReciboService reciboService = new ReciboService();
        private SucursalService sucursalService = new SucursalService();
        private PersonalService personalService = new PersonalService();

        private bool isFormLoaded = false;
        public Frm_VentadeProducto()
        {
            InitializeComponent();
            InitializeDataGridView();
            clienteService.fillComboBoxClientes(cbClientes);
            productService.fillComboBoxProductos(cbBuscarProducto);
            sucursalService.fillComboBoxSucursal(cbSucursal);
            personalService.fillComboBoxPersonal(cbPersonal);
            cbClientes.SelectedIndex = -1;
            cbBuscarProducto.SelectedIndex = -1;
            txtPrecioFinal.Clear();
            isFormLoaded = true;
        }

        private void InitializeDataGridView()
        {
            dgvDetalles.Columns.Clear();
            dgvDetalles.Columns.Add("IdProducto", "Código");
            dgvDetalles.Columns.Add("Descripcion", "Descripcion");
            dgvDetalles.Columns.Add("Cantidad", "Cantidad");
            dgvDetalles.Columns.Add("Precio", "Precio");
            dgvDetalles.Columns.Add("Subtotal", "Subtotal");
            dgvDetalles.Columns.Add("Fecha", "FechaEmision");
            dgvDetalles.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Frm_VentadeProducto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void Frm_VentadeProducto_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPosition = PointToScreen(e.Location);
                Location = new Point(currentScreenPosition.X - startPoint.X, currentScreenPosition.Y - startPoint.Y);
            }
        }

        private void Frm_VentadeProducto_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded)
                return;

            if (cbClientes.SelectedItem != null)
            {
                // Preguntar al usuario si desea iniciar una nueva venta
                DialogResult result = MessageBox.Show(
                    "¿Desea iniciar una nueva venta?",
                    "Nueva Venta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el cliente seleccionado
                    var selectedCliente = (ClienteInfo)cbClientes.SelectedItem;

                    // Asignar los valores a los campos de texto
                    txtTipoDoc.Text = selectedCliente.TipoDocumento;
                    txtNroDoc.Text = selectedCliente.NumeroDocumento;

                    // Deshabilitar los campos de texto
                    txtTipoDoc.Enabled = false;
                    txtNroDoc.Enabled = false;
                    txtTotal.Text = "0.00";

                    // Limpiar el DataGridView como si fuera una nueva venta
                    dgvDetalles.Rows.Clear();
                }
                else
                {
                    // Si el usuario cancela, restaurar la selección anterior
                    cbClientes.SelectedIndexChanged -= cbClientes_SelectedIndexChanged; // Desuscribir temporalmente el evento
                    cbClientes.SelectedItem = null; // Restaurar la selección anterior
                    cbClientes.SelectedIndexChanged += cbClientes_SelectedIndexChanged; // Volver a suscribir el evento
                }
            }
            else
            {
                // Limpiar los campos de texto si no hay cliente seleccionado
                txtTipoDoc.Clear();
                txtNroDoc.Clear();

                // Habilitar los campos de texto
                txtTipoDoc.Enabled = true;
                txtNroDoc.Enabled = true;

                // Limpiar el DataGridView
                dgvDetalles.Rows.Clear();
                txtTotal.Text = "0.00";
            }
        }

        private void cbBuscarProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBuscarProducto.SelectedItem != null)
            {
                var selectedProducto = (KeyValuePair<string, string>)cbBuscarProducto.SelectedItem;
                string idProductoSeleccionado = selectedProducto.Key;
                CProducto producto = productService.GetProductoDetails(idProductoSeleccionado);

                if (producto != null)
                {
                    txtDescripcion.Text = producto.Descripcion;
                    txtDescripcion.Enabled = false;
                    txtPrecioVenta.Text = producto.Precioventa.ToString("F2");
                    txtPrecioVenta.Enabled = false;
                    txtStock.Text = producto.Stock.ToString();
                    txtStock.Enabled = false;
                    txtUnidad.Text = producto.Unidad;
                    txtUnidad.Enabled = false;
                    decimal precioFinal = producto.Precioventa * 1.03m;
                    txtPrecioFinal.Text = precioFinal.ToString("F2");
                }
                else
                {
                    MessageBox.Show("No se encontraron detalles para el producto seleccionado.");
                }
            }
            else
            {
                txtDescripcion.Clear();
                txtPrecioVenta.Clear();
                txtStock.Clear();
                txtPrecioFinal.Clear();
                txtUnidad.Clear();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cbBuscarProducto.SelectedItem != null &&
                int.TryParse(txtCantidad.Text, out int cantidad) &&
                cantidad > 0)
            {
                var selectedProducto = (KeyValuePair<string, string>)cbBuscarProducto.SelectedItem;
                string idProductoSeleccionado = selectedProducto.Key;
                CProducto producto = productService.GetProductoDetails(idProductoSeleccionado);

                if (producto != null && decimal.TryParse(txtPrecioFinal.Text, out decimal precioFinal))
                {
                    decimal subtotal = precioFinal * cantidad;
                    DateTime fecha = dtFechaRegistro.Value;

                    // Agregar fila al DataGridView con la descripción
                    dgvDetalles.Rows.Add(
                        idProductoSeleccionado,
                        producto.Descripcion, // Asegúrate de que esta línea esté presente
                        cantidad,
                        producto.Precioventa,
                        subtotal,
                        fecha
                    );

                    // Calcular el total
                    decimal total = dgvDetalles.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !row.IsNewRow && row.Cells["Subtotal"].Value != null)
                        .Sum(row => Convert.ToDecimal(row.Cells["Subtotal"].Value));

                    txtTotal.Text = total.ToString("0.00");
                }
                else
                {
                    MessageBox.Show("El precio final no es un número válido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto y una cantidad válida.");
            }
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar tipo de recibo
                if (cbTipoRecibo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un tipo de recibo.");
                    return;
                }

                // Calcular totales
                decimal totalGravado = CalcularTotalGravado();
                decimal igv = totalGravado * 0.18m;
                decimal total = totalGravado + igv;

                // Generar IDs únicos
                int idRecibo = GenerarIdReciboUnico();

                // Obtener el nombre del cliente
                var selectedCliente = (ClienteInfo)cbClientes.SelectedItem;
                string nombreCliente = selectedCliente.NombreCompleto;
                // Crear el recibo
                CRecibo nuevoRecibo = new CRecibo
                {
                    IdRecibo = idRecibo,
                    TipoRecibo = cbTipoRecibo.SelectedItem.ToString(),
                    IdSucursal = 1, // Convert.ToInt32(cbSucursal.SelectedValue),
                    FechaEmision = DateTime.Now,
                    Hora = DateTime.Now,
                    TotalGravado = totalGravado,
                    IGV = igv,
                    Total = total,
                    TotalLetras = "",
                    FormaPago = cbFormaPago.SelectedItem.ToString(),
                    IdPersonal = Convert.ToInt32(cbPersonal.SelectedValue),
                    TipoMoneda = "S/.",
                    IdCliente = Convert.ToInt32(cbClientes.SelectedValue),
                    NroRecibo = reciboService.GenerarNumeroRecibo(cbTipoRecibo.SelectedItem.ToString()),
                    TipoServicio = "Producto",
                    NombreCliente = nombreCliente
                };

                // Insertar el recibo usando transacciones
                using (var connection = new SqlConnection(reciboService.ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Insertar el recibo
                        int resultadoRecibo = reciboService.InsertarRecibo(nuevoRecibo, transaction);
                        if (resultadoRecibo <= 0)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al insertar el recibo.");
                            return;
                        }

                        // Insertar detalles del recibo
                        foreach (DataGridViewRow row in dgvDetalles.Rows)
                        {
                            if (row.IsNewRow) continue;
                            string descripcionProducto = row.Cells["Descripcion"].Value?.ToString();
                            if (string.IsNullOrEmpty(descripcionProducto))
                            {
                                MessageBox.Show($"La descripción del producto con ID {row.Cells["IdProducto"].Value} es nula o vacía.");
                            }
                            int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                            int cantidadVendida = Convert.ToInt32(row.Cells["Cantidad"].Value);

                            // Verificar stock
                            if (!reciboService.VerificarStockDisponible(idProducto, cantidadVendida, transaction))
                            {
                                transaction.Rollback();
                                MessageBox.Show($"No hay suficiente stock disponible para el producto con ID {idProducto}.");
                                return;
                            }

                            string idDetalleRecibo = GenerarIdDetalleReciboUnico();
                            CDetalleRecibo detalle = new CDetalleRecibo
                            {
                                IdDetalleRecibo = idDetalleRecibo,
                                Cantidad = cantidadVendida,
                                Subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value),
                                IdRecibo = nuevoRecibo.IdRecibo,
                                TipoProductoServicio = 1,
                                Codigo = idProducto,
                                PrecioVenta = Convert.ToDecimal(row.Cells["Precio"].Value),
                                Descripcion = descripcionProducto // Asignar la descripción aquí
                            };

                            // Insertar el detalle
                            int resultadoDetalle = reciboService.InsertarDetalleRecibo(detalle, transaction);
                            if (resultadoDetalle <= 0)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error al insertar el detalle del recibo.");
                                return;
                            }

                            // Actualizar stock
                            if (!reciboService.ActualizarStockProducto(idProducto, cantidadVendida, transaction))
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Error al actualizar el stock del producto con ID {idProducto}.");
                                return;
                            }
                        }

                        // Confirmar transacción
                        transaction.Commit();

                        // Generar PDF
                        List<CDetalleRecibo> detallesRecibo = dgvDetalles.Rows
                            .Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .Select(row => new CDetalleRecibo
                            {
                                Codigo = Convert.ToInt32(row.Cells["IdProducto"].Value),
                                Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                                PrecioVenta = Convert.ToDecimal(row.Cells["Precio"].Value),
                                Subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value)
                            })
                            .ToList();

                        GenerarTicketPDF(nuevoRecibo, detallesRecibo);

                        MessageBox.Show("Venta confirmada y recibo guardado en la base de datos.");
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error durante la transacción: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

        private int GenerarIdReciboUnico()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(2023, 1, 1)).TotalSeconds);
        }

        private string GenerarIdDetalleReciboUnico()
        {
            return "DR-" + DateTime.UtcNow.Ticks.ToString("X");
        }

        private decimal CalcularTotalGravado()
        {
            decimal totalGravado = 0;
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.IsNewRow || row.Cells["Subtotal"].Value == null) continue;
                if (decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal subtotal))
                {
                    totalGravado += subtotal;
                }
            }
            return totalGravado;
        }

        private void GenerarTicketPDF(CRecibo recibo, List<CDetalleRecibo> detalles)
        {
            try
            {
                if (recibo == null || detalles == null || detalles.Count == 0)
                {
                    MessageBox.Show("No hay datos disponibles para generar el ticket.");
                    return;
                }

                // Obtener las descripciones originales desde el DataGridView
                List<string> descripciones = new List<string>();
                foreach (DataGridViewRow row in dgvDetalles.Rows)
                {
                    if (row.IsNewRow) continue;
                    string descripcion = row.Cells["Descripcion"].Value?.ToString();
                    descripciones.Add(descripcion ?? "Descripción no disponible");
                }

                // Definir la carpeta de destino
                string carpetaDestino = @"C:\Users\ALEX\Desktop\Recibos\";
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                // Definir la ruta completa del archivo
                string rutaArchivo = Path.Combine(carpetaDestino, $"Ticket_{recibo.NroRecibo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                // Crear el documento con un tamaño personalizado
                Document document = new Document();
                Section section = document.AddSection();

                // Configurar tamaño de página personalizado (más estrecho)
                section.PageSetup.PageWidth = "10cm";
                section.PageSetup.PageHeight = "16cm";
                section.PageSetup.LeftMargin = "0.5cm";
                section.PageSetup.RightMargin = "0.5cm";
                section.PageSetup.TopMargin = "0.5cm";
                section.PageSetup.BottomMargin = "0.5cm";

                // Agregar logo encima del nombre de la empresa
                string rutaLogo = @"C:\Users\ALEX\Desktop\Recibos\logo.jpg"; // Ruta de la imagen
                if (File.Exists(rutaLogo))
                {
                    Paragraph logoPara = section.AddParagraph();
                    Image logo = logoPara.AddImage(rutaLogo);
                    logo.Width = "2.5cm";  // Ajustar ancho del logo
                    logo.Height = "2.5cm"; // Ajustar altura del logo
                    logoPara.Format.Alignment = ParagraphAlignment.Center;
                }

                // Encabezado del ticket
                Paragraph encabezado = section.AddParagraph("EMPRESA LOS CHAMOS");
                encabezado.Format.Font.Name = "Arial";
                encabezado.Format.Font.Size = 12;
                encabezado.Format.Alignment = ParagraphAlignment.Center;
                encabezado.Format.SpaceAfter = 5;

                Paragraph subEncabezado = section.AddParagraph("Teléfono: 123-456-789\nEmail: edgarycachimbo@gmail.com\n" +
                                                             "--------------------------------------------");
                subEncabezado.Format.Font.Name = "Arial";
                subEncabezado.Format.Font.Size = 8;
                subEncabezado.Format.Alignment = ParagraphAlignment.Center;
                subEncabezado.Format.SpaceAfter = 10;

                // Información del ticket
                Paragraph infoTicket = section.AddParagraph();
                infoTicket.Format.Font.Name = "Arial";
                infoTicket.Format.Font.Size = 8;
                infoTicket.Format.Alignment = ParagraphAlignment.Left;
                infoTicket.AddFormattedText($"Nro de Recibo: {recibo.NroRecibo}\n", TextFormat.Bold);
                infoTicket.AddFormattedText($"Fecha: {recibo.FechaEmision.ToShortDateString()}\n");
                infoTicket.AddFormattedText($"Hora: {recibo.Hora.ToShortTimeString()}\n");
                infoTicket.AddFormattedText($"Cliente: {recibo.NombreCliente}\n");
                infoTicket.AddFormattedText($"Forma de Pago: {recibo.FormaPago}");
                infoTicket.Format.SpaceAfter = 10;

                // Crear tabla con bordes sutiles
                Table table = section.AddTable();
                table.Borders.Width = 0.2; // Bordes sutiles
                table.Format.Alignment = ParagraphAlignment.Left;

                // Definir columnas con mejor distribución del espacio
                table.AddColumn("1.0cm"); // Número
                table.AddColumn("2.8cm"); // Descripción (un poco más compacta)
                table.AddColumn("1.3cm"); // Cantidad
                table.AddColumn("2.0cm"); // Precio Unitario
                table.AddColumn("2.0cm"); // Subtotal (ajustado)


                // Agregar fila de encabezado
                Row headerRow = table.AddRow();
                headerRow.Shading.Color = Colors.LightGray; // Fondo gris
                headerRow.Cells[0].AddParagraph("#");
                headerRow.Cells[1].AddParagraph("Descripción");
                headerRow.Cells[2].AddParagraph("Cantidad");
                headerRow.Cells[3].AddParagraph("Precio U.");
                headerRow.Cells[4].AddParagraph("Subtotal");

                // Formatear el encabezado
                foreach (Cell cell in headerRow.Cells)
                {
                    cell.Format.Font.Bold = true;
                    cell.Format.Font.Size = 8;
                    cell.Format.Alignment = ParagraphAlignment.Center;
                }

                // Agregar filas de datos
                for (int i = 0; i < detalles.Count; i++)
                {
                    Row row = table.AddRow();
                    row.Cells[0].AddParagraph((i + 1).ToString());
                    row.Cells[1].AddParagraph(descripciones[i]);
                    row.Cells[2].AddParagraph(detalles[i].Cantidad.ToString());
                    row.Cells[3].AddParagraph(detalles[i].PrecioVenta.ToString("C"));
                    row.Cells[4].AddParagraph(detalles[i].Subtotal.ToString("C"));

                    // Ajustar formato de celdas
                    foreach (Cell cell in row.Cells)
                    {
                        cell.Format.Font.Name = "Arial";
                        cell.Format.Font.Size = 7;
                        cell.Format.Alignment = ParagraphAlignment.Left;
                    }
                }


                // Totales
                Paragraph totales = section.AddParagraph();
                totales.Format.Font.Name = "Arial";
                totales.Format.Font.Size = 8;
                totales.Format.SpaceBefore = 8;
                totales.Format.Alignment = ParagraphAlignment.Right; // Alinear a la derecha
                totales.AddFormattedText($"Total Gravado: {recibo.TotalGravado:C}\n", TextFormat.Bold);
                totales.AddFormattedText($"IGV (18%): {recibo.IGV:C}\n", TextFormat.Bold);
                totales.AddFormattedText($"Total: {recibo.Total:C}", TextFormat.Bold);

                // Pie de página
                Paragraph piePagina = section.AddParagraph("\n¡Gracias por su compra!\n\n");
                piePagina.Format.Font.Name = "Arial";
                piePagina.Format.Font.Size = 8;
                piePagina.Format.Alignment = ParagraphAlignment.Center;
                piePagina.AddText("www.edgarycachimbo.com");

                // Guardar el PDF
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(rutaArchivo);

                // Mostrar mensaje de éxito
                MessageBox.Show($"El ticket ha sido generado exitosamente.\nRuta: {rutaArchivo}", "Ticket Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir automáticamente el archivo
                Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el ticket: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            cbClientes.SelectedIndex = -1;
            cbBuscarProducto.SelectedIndex = -1;
            txtTipoDoc.Clear();
            txtNroDoc.Clear();
            txtPrecioFinal.Clear();
            txtCantidad.Clear();
            txtTotal.Clear();
            dgvDetalles.Rows.Clear();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Frm_SearchCliente frm = new Frm_SearchCliente();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada (usando CurrentRow)
            if (dgvDetalles.CurrentRow != null && !dgvDetalles.CurrentRow.IsNewRow)
            {
                // Obtener la fila actualmente seleccionada
                DataGridViewRow selectedRow = dgvDetalles.CurrentRow;

                // Eliminar la fila seleccionada
                dgvDetalles.Rows.Remove(selectedRow);

                // Recalcular el total
                // Calcular el total sumando los valores de la columna "Subtotal"
                decimal total = dgvDetalles.Rows
                    .Cast<DataGridViewRow>()
                    .Where(row => !row.IsNewRow && row.Cells["Subtotal"].Value != null)
                    .Sum(row => Convert.ToDecimal(row.Cells["Subtotal"].Value));

                // Actualizar el campo de texto del total
                txtTotal.Text = total.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //Abrir el formulario de búsqueda de clientes
            /*Frm_SearchCliente frm_SearchCliente = new Frm_SearchCliente();
            frm_SearchCliente.ShowDialog();
            //si respone OK, se actualiza el combobox de clientes con los datos selecctionados con doble click en el datagridview
            if (frm_SearchCliente.DialogResult == DialogResult.OK)
            {
                //poner los datos que se selecciono en el datagridview del formulario cliente
                cbClientes.SelectedValue = frm_SearchCliente.IdCliente;
            }*/
        }
    }
}