using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.IdentityModel.Tokens;
using ProjectPI_Building.Clases;
using ProjectPI_Building.Forms_Search;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Register
{
    public partial class Frm_Compra_Producto : Form
    {
        //VENTANA
        private bool isDragging = false;
        private Point startPoint;

        CCompra compra = new CCompra();
        //Lista de idRebicocompra
        List<string> listaIdReciboCompra = new List<string>();
        //Fila seleccionada
        private int fila;

        public Frm_Compra_Producto()
        {
            InitializeComponent();
        }
        //LlENAR DATA GRID VIEW
        private void fill_data()
        {
            try
            {
                Connection_Compra con = new Connection_Compra();
                dgv_Recibo_Compra.DataSource = con.fillRecibo(listaIdReciboCompra).Tables["ReciboCompra"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LLENAR COMBOBOX
        private void LlenarComboBoxProveedor()
        {
            try
            {
                Connection_Proveedor conection = new Connection_Proveedor();
                DataSet proveedoresDataSet = conection.fillProveedor();
                if (proveedoresDataSet?.Tables.Count > 0)
                {
                    DataTable proveedorTable = proveedoresDataSet.Tables["Proveedor"];

                    // Desvincula y limpia el ComboBox
                    cb_proveedor.DataSource = null;
                    cb_proveedor.Items.Clear();

                    // Verifica si la columna InfoProveedor ya existe antes de agregarla
                    if (!proveedorTable.Columns.Contains("InfoProveedor"))
                    {
                        proveedorTable.Columns.Add("InfoProveedor", typeof(string), "nombre + '   ' + Nrodocumento");
                    }

                    // Configura el ComboBox
                    cb_proveedor.DisplayMember = "InfoProveedor";
                    cb_proveedor.ValueMember = "idProveedor";
                    cb_proveedor.DataSource = proveedorTable;

                    // Refresca el ComboBox
                    cb_proveedor.Refresh();
                }
                else
                {
                    MessageBox.Show("No se encontraron proveedores registrados.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el ComboBox: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void LlenarComboBoxProducto()
        {
            try
            {
                Connection_Producto conection = new Connection_Producto();
                DataSet productosDataSet = conection.fillProducto();
                if (productosDataSet?.Tables.Count > 0)
                {
                    DataTable productoTable = productosDataSet.Tables["Producto"];

                    // Desvincula y limpia el ComboBox
                    cb_producto.DataSource = null;
                    cb_producto.Items.Clear();

                    // Verifica si la columna InfoProducto ya existe antes de agregarla
                    if (!productoTable.Columns.Contains("InfoProducto"))
                    {
                        productoTable.Columns.Add("InfoProducto", typeof(string), "categoria + ' ' + descripcion");
                    }

                    // Configura el ComboBox
                    cb_producto.DisplayMember = "InfoProducto";
                    cb_producto.ValueMember = "idproducto";
                    cb_producto.DataSource = productoTable;

                    // Refresca el ComboBox
                    cb_producto.Refresh();
                }
                else
                {
                    MessageBox.Show("No se encontraron productos registrados.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el ComboBox: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        //CONFIGURACION MOVER VENTANA
        private void Frm_Compra_Producto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);//Registrar el punto de inicio
            }
        }

        private void Frm_Compra_Producto_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Frm_Compra_Producto_MouseMove(object sender, MouseEventArgs e)
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

        private void btn_exit_Click(object sender, EventArgs e)
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

        private void ObtenerDetallesProducto(int idProducto)
        {
            try
            {
                Connection_Producto conection = new Connection_Producto();
                DataSet productoDataSet = conection.fillProducto();

                if (productoDataSet != null && productoDataSet.Tables.Count > 0)
                {
                    DataTable productoTable = productoDataSet.Tables["Producto"];
                    DataRow[] rows = productoTable.Select($"idProducto = {idProducto}");

                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0]; // Obtener la primera fila que coincide

                        // Asignar valores a los TextBox
                        txt_descripcion.Text = row["descripcion"].ToString();
                        txt_unidad.Text = row["unidad"].ToString();
                        txt_stock.Text = row["stock"].ToString();
                        txt_precio_compra.Text = row["preciocompra"].ToString();
                        txt_precio_venta.Text = row["precioventa"].ToString();
                        txt_precio_unitario.Text = row["preciounitario"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron detalles para el producto seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los datos de productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener detalles del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            cb_producto.SelectedIndex = -1;
            cb_proveedor.SelectedIndex = -1;
            dtp_fecha_registro.Value = DateTime.Now;
            txt_descripcion.Clear();
            txt_unidad.Clear();
            txt_stock.Clear();
            txt_cantidad.Clear();
            txt_precio_compra.Clear();
            txt_precio_venta.Clear();
            txt_precio_unitario.Clear();
            cb_tipo_recibo.SelectedIndex = -1;
        }

        private int generarIdDetalleCompra()
        {

            Connection_Compra connection_Compra = new Connection_Compra();
            int id = connection_Compra.count_detalle_compra();
            return id;
        }

        private void generarIdReciboCompra()
        {
            Connection_Compra connection_Compra = new Connection_Compra();
            string id = connection_Compra.GetNextReciboCompraId();
            txt_id_recibo.Text = id.ToString();
        }
        private void ObtenerValores()
        {
            try
            {
                // Obtener el valor seleccionado del ComboBox de Proveedores
                string idProveedor = cb_proveedor.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(idProveedor))
                {
                    MessageBox.Show("Por favor, seleccione un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el valor seleccionado del ComboBox de Productos
                string idProducto = cb_producto.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(idProducto))
                {
                    MessageBox.Show("Por favor, seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string tipoRecibo = cb_tipo_recibo.Text.Trim();
                if (string.IsNullOrEmpty(tipoRecibo))
                {
                    MessageBox.Show("Por favor, seleccione un tipo de recibo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Obtener la fecha seleccionada en el DateTimePicker
                DateTime fechaIngreso = dtp_fecha_registro.Value;

                // Obtener la cantidad del TextBox
                if (!int.TryParse(txt_cantidad.Text, out int cantidadEntrada))
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar los valores a la clase CCompra
                int idDetalleCompra = generarIdDetalleCompra();
                if (idDetalleCompra <= 0)
                {
                    MessageBox.Show("Error al generar el ID detalle compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal precioCompra = decimal.Parse(txt_precio_compra.Text);
                if (precioCompra <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio de compra válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal precioVenta = decimal.Parse(txt_precio_venta.Text);
                if (precioVenta <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio de venta válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                compra.IdReciboCompra = txt_id_recibo.Text.Trim();
                compra.TipoRecibo = tipoRecibo;
                compra.FechaIngreso = fechaIngreso;
                compra.IdProveedor = int.Parse(idProveedor);
                compra.IdDetalleCompra = idDetalleCompra;
                compra.CantidadEntrada = cantidadEntrada;
                compra.IdProducto = int.Parse(idProducto);
                compra.PrecioCompra = precioCompra;
                compra.PrecioVenta = precioVenta;
                compra.Subtotal = cantidadEntrada * precioCompra;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los valores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //COMPRAR PRODUCTO
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            ObtenerValores();

            // Verificar si se han asignado los valores correctamente
            if (string.IsNullOrEmpty(compra.IdReciboCompra) || string.IsNullOrEmpty(compra.TipoRecibo) || compra.IdProveedor <= 0 ||
                compra.IdDetalleCompra <= 0 || compra.CantidadEntrada <= 0 || compra.IdProducto <= 0 || compra.PrecioCompra <= 0 ||
                compra.PrecioCompra <= 0)
            {
                MessageBox.Show("Por favor, asegúrese de que todos los campos estén completos y válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Crear una instancia de ConnectionCompra para insertar la compra
            Connection_Compra connectionCompra = new Connection_Compra();

            // Llamar al método InsertarCompra y manejar el resultado
            bool resultado = connectionCompra.InsertarCompra(compra);

            if (resultado)
            {
                listaIdReciboCompra.Add(compra.IdReciboCompra);
                fill_data();
                MessageBox.Show("La compra se registró exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                generarIdReciboCompra();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la compra. Por favor, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_producto.SelectedValue != null)
            {
                int idProducto = Convert.ToInt32(cb_producto.SelectedValue);

                // Llamar a la función para obtener detalles del producto
                ObtenerDetallesProducto(idProducto);
            }
        }

        private void Frm_Compra_Producto_Load(object sender, EventArgs e)
        {
            LlenarComboBoxProducto();
            LlenarComboBoxProveedor();
            generarIdReciboCompra();
            LimpiarCampos();
        }
        //Frm_Producto_Register
        private void btn_registrar_proveedor_Click(object sender, EventArgs e)
        {
            Frm_Proveedor_Register frmProvider = new Frm_Proveedor_Register();
            frmProvider.option = 0;
            if (frmProvider.ShowDialog() == DialogResult.OK) // Verificar si se agregó un nuevo proveedor
            {
                LlenarComboBoxProveedor(); // Actualizar la tabla de proveedores
                LimpiarCampos();
            }
        }
        //Frm_Producto_Search
        private void btn_filtrar_proveedor_Click(object sender, EventArgs e)
        {
            Frm_Proveedor_Search frmProvider = new Frm_Proveedor_Search();
            if (frmProvider.ShowDialog() == DialogResult.OK) // Verificar si se seleccionó un proveedor
            {
                CProveedor proveedor = frmProvider.ProveedorSeleccionado;
                if (proveedor != null)
                {
                    cb_proveedor.SelectedValue = proveedor.IdProveedor;
                }
            }
        }
        //Frm_Provvedor_Register
        private void btn_registrar_producto_Click(object sender, EventArgs e)
        {
            Frm_Producto_Register frmProduct = new Frm_Producto_Register();
            frmProduct.option = 0;
            if (frmProduct.ShowDialog() == DialogResult.OK)
            {
                LlenarComboBoxProducto();
                LimpiarCampos();
            }
        }
        //Frm_Prpveedor_Search
        private void btn_filtrar_producto_Click(object sender, EventArgs e)
        {
            Frm_Producto_Search frm_Producto_Search = new Frm_Producto_Search();
            if (frm_Producto_Search.ShowDialog() == DialogResult.OK)
            {
                CProducto producto = frm_Producto_Search.ProductoSeleccionado;
                if (producto != null)
                {
                    cb_producto.SelectedValue = producto.IdProducto;
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                try
                {
                    string idReciboCompra = dgv_Recibo_Compra[0, fila].Value.ToString().Trim();

                    // Mostrar mensaje de confirmación
                    DialogResult resultadoConfirmacion = MessageBox.Show($"¿Está seguro de que desea eliminar la compra con ID: {idReciboCompra}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultadoConfirmacion == DialogResult.Yes)
                    {
                        Connection_Compra connectionCompra = new Connection_Compra();
                        bool resultado = connectionCompra.DeleteCompra(idReciboCompra);

                        if (resultado)
                        {
                            listaIdReciboCompra.Remove(idReciboCompra);
                            fill_data();
                            MessageBox.Show("La compra se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la compra. Por favor, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eliminación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una compra para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_Recibo_Compra_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fila = e.RowIndex;
            }
        }
        //IMPRIMIR CON ITEXT7
        public void GenerarPdfRecibo(List<string> listaIdRecibo, string filePath)
        {
            // Obtener los datos
            Connection_Compra con = new Connection_Compra();
            DataSet dataSet = con.fillRecibo(listaIdRecibo);

            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                DataTable dt = dataSet.Tables[0];

                // Crear el documento PDF
                PdfWriter writer = new PdfWriter(filePath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                // Configurar la fuente
                string FONT = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);
                PdfFont boldFont = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED); // Fuente en negrita

                // Agregar contenido para cada recibo
                foreach (DataRow row in dt.Rows)
                {
                    // Espacio en blanco entre recibos
                    document.Add(new Paragraph("\n"));

                    // Fila 1: Recibo de Compra (izquierda) y datos del recibo (derecha)
                    Paragraph header = new Paragraph()
                        .Add(new Text("Recibo de Compra").SetFont(boldFont).SetFontSize(16))
                        .SetTextAlignment(TextAlignment.LEFT);

                    Paragraph headerRight = new Paragraph()
                        .Add(new Text($"Fecha Ingreso: {row["Fecha_Ingreso"]}").SetFont(font).SetFontSize(12).SetTextAlignment(TextAlignment.RIGHT))
                        .Add(new Text($"\nTipo Recibo: {row["Tipo_Recibo"]}").SetFont(font).SetFontSize(12).SetTextAlignment(TextAlignment.RIGHT))
                        .Add(new Text($"\nNro. Recibo: {row["Nro_Recibo"]}").SetFont(font).SetFontSize(12).SetTextAlignment(TextAlignment.RIGHT));

                    Div headerDiv = new Div().SetWidth(UnitValue.CreatePercentValue(100));
                    headerDiv.Add(header);
                    headerDiv.Add(headerRight);

                    document.Add(headerDiv);

                    // Fila 2: Subtítulo "Datos del Proveedor"
                    Paragraph proveedorSubtitulo = new Paragraph("Datos del Proveedor").SetFont(boldFont).SetFontSize(14).SetTextAlignment(TextAlignment.LEFT);
                    document.Add(proveedorSubtitulo);

                    // Fila 3: Proveedor y Nro_documento
                    Paragraph proveedorDatos = new Paragraph()
                        .Add(new Text($"Proveedor: {row["Proveedor"]}").SetFont(font).SetFontSize(12))
                        .Add(new Text($"\nNro. Documento: {row["Nro_documento"]}").SetFont(font).SetFontSize(12));
                    document.Add(proveedorDatos);

                    // Fila 4: Subtítulo "Datos del Producto"
                    Paragraph productoSubtitulo = new Paragraph("Datos del Producto").SetFont(boldFont).SetFontSize(14).SetTextAlignment(TextAlignment.LEFT);
                    document.Add(productoSubtitulo);

                    // Fila 5: Producto_Categoria, Producto_Descripcion, Cantidad_Comprada
                    Paragraph productoDatos = new Paragraph()
                        .Add(new Text($"Producto Categoria: {row["Producto_Categoria"],-30} ").SetFont(font).SetFontSize(12)) // Formato: 30 caracteres de ancho
                        .Add(new Text($"Producto Descripcion: {row["Producto_Descripcion"],-30} ").SetFont(font).SetFontSize(12)) // Formato: 30 caracteres de ancho
                        .Add(new Text($"Cantidad Comprada: {row["Cantidad_Comprada"],-10}").SetFont(font).SetFontSize(12));  // Formato: 10 caracteres de ancho
                    document.Add(productoDatos);

                    // Fila 6: PrecioCompra, Precio_Venta, subtotal
                    Paragraph precios = new Paragraph()
                        .Add(new Text($"Precio Compra: {row["PrecioCompra"],-15}").SetFont(font).SetFontSize(12))  // Formato: 15 caracteres de ancho
                        .Add(new Text($"Precio Venta: {row["Precio_Venta"],-15}").SetFont(font).SetFontSize(12))  // Formato: 15 caracteres de ancho
                        .Add(new Text($"Subtotal: {row["subtotal"],-10}").SetFont(font).SetFontSize(12));    // Formato: 10 caracteres de ancho
                    document.Add(precios);

                    // Agregar una línea divisoria para separar los recibos
                    document.Add(new LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine()));
                }

                // Cerrar el documento
                document.Close();
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            // Validar si la lista de recibos está vacía
            if (listaIdReciboCompra == null || listaIdReciboCompra.Count == 0)
            {
                MessageBox.Show("Primero debe realizar al menos una compra para guardar el recibo como PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar Recibo como PDF";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Validar si el DataSet contiene datos
                Connection_Compra con = new Connection_Compra();
                DataSet dataSet = con.fillRecibo(listaIdReciboCompra);

                if (dataSet == null || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de compra para generar el recibo en PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir del método
                }

                GenerarPdfRecibo(listaIdReciboCompra, filePath);
                MessageBox.Show("Recibo guardado como PDF exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
