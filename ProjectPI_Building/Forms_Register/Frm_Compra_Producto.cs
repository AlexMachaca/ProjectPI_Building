using System;
using System.Collections;
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
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Geom;
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
        private System.Drawing.Point startPoint;

        CReciboCompra compra = new CReciboCompra();
        //Lista de idRebicocompra
        List<int> listaIdReciboCompra = new List<int>();
        //Fila seleccionada
        private int fila;

        //Indicadores boolenos
        private bool primeraVez = false;
        //Nro de recibo
        public string NroRecibo { get; set; }
        //Lista de compras
        List<CDetalleCompra> listaCompras = new List<CDetalleCompra>();
        //temporal idDetalleCompra
        int temporalIdDetalleCompra = 0;

        public Frm_Compra_Producto()
        {
            InitializeComponent();
        }
        //LlENAR DATA GRID VIEW

        //Imprimir la lista de compras en el DataGridView
        private void fill_data()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IdDetalleCompra", typeof(int)); // Especifica el tipo de dato correcto
                dt.Columns.Add("Producto", typeof(string));
                dt.Columns.Add("CantidadEntrada", typeof(int)); // Especifica el tipo de dato correcto
                dt.Columns.Add("PrecioCompra", typeof(decimal)); // Especifica el tipo de dato correcto
                dt.Columns.Add("PrecioVenta", typeof(decimal)); // Especifica el tipo de dato correcto
                dt.Columns.Add("Subtotal", typeof(decimal)); // Especifica el tipo de dato correcto

                foreach (CDetalleCompra compra in listaCompras)
                {
                    DataRow row = dt.NewRow();
                    row["IdDetalleCompra"] = compra.IdDetalleCompra;
                    row["Producto"] = compra.NombreProducto;
                    row["CantidadEntrada"] = compra.CantidadEntrada;
                    row["PrecioCompra"] = compra.PrecioCompra;
                    row["PrecioVenta"] = compra.PrecioVenta;
                    row["Subtotal"] = compra.Subtotal;
                    dt.Rows.Add(row);
                }
                dgv_Recibo_Compra.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                startPoint = new System.Drawing.Point(e.X, e.Y);//Registrar el punto de inicio
            }
        }

        private void Frm_Compra_Producto_MouseUp(object sender, MouseEventArgs e) => isDragging = false;

        private void Frm_Compra_Producto_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                //Calcular nueva posicion del formulario
                //Point newLocation = new Point(this.Left + e.X - startPoint.X, this.Top + e.Y - startPoint.Y);
                System.Drawing.Point newPosition = this.Location;
                newPosition.X += e.X - startPoint.X;
                newPosition.Y += e.Y - startPoint.Y;
                this.Location = newPosition;
                this.Location = newPosition;//Mueve el formulario
            }
        }

        private void btn_exit_Click(object sender, EventArgs e) => this.Close();

        private void btn_maximizar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Maximized;

        private void btn_minimizar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void btn_salir_Click(object sender, EventArgs e) => this.Close();
        //-------------------------------------------------------------------
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
            //cb_proveedor.SelectedIndex = -1;
            dtp_fecha_registro.Value = DateTime.Now;
            txt_descripcion.Clear();
            txt_unidad.Clear();
            txt_stock.Clear();
            txt_cantidad.Clear();
            txt_precio_compra.Clear();
            txt_precio_venta.Clear();
            txt_precio_unitario.Clear();
            //cb_tipo_recibo.SelectedIndex = -1;
        }

        private int generarIdDetalleCompra()
        {

            Connection_Compra connection_Compra = new Connection_Compra();
            int id = connection_Compra.count_detalle_compra();
            return id;
        }//Se usa una sola vez


        private void generarIdReciboCompra()
        {
            Connection_Compra connection_Compra = new Connection_Compra();
            string id = connection_Compra.ObtenerNextIdReciboCompra_Factura();
            txt_id_recibo.Text = id.ToString();
        }//cambiar a fc0000 o bc0000
        private bool ObtenerValores()
        {
            try
            {
                // Obtener el valor seleccionado del ComboBox de Proveedores
                string idProveedor = cb_proveedor.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(idProveedor))
                {
                    MessageBox.Show("Por favor, seleccione un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Obtener el valor seleccionado del ComboBox de Tipo de Recibo
                string tipoRecibo = cb_tipo_recibo.Text.Trim();
                if (string.IsNullOrEmpty(tipoRecibo))
                {
                    MessageBox.Show("Por favor, seleccione un tipo de recibo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //Obtener el Nro ed Recibo
                string NroRecibo = txt_id_recibo.Text.Trim();//cambiar a fc0000 o bc0000
                if (string.IsNullOrEmpty(NroRecibo))
                {
                    MessageBox.Show("Por favor, seleccione un Nro de recibo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                // Obtener la fecha seleccionada en el DateTimePicker
                DateTime fechaIngreso = dtp_fecha_registro.Value;

                // Asignar los valores a la clase CCompra
                int idDetalleCompra = generarIdDetalleCompra();
                if (idDetalleCompra <= 0)
                {
                    MessageBox.Show("Error al generar el ID detalle compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                temporalIdDetalleCompra = idDetalleCompra;

                // Obtener el valor seleccionado del ComboBox de Productos
                string idProducto = cb_producto.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(idProducto))
                {
                    MessageBox.Show("Por favor, seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                string NombreProducto = cb_producto.Text;

                // Obtener la cantidad del TextBox
                if (!int.TryParse(txt_cantidad.Text, out int cantidadEntrada))
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }



                decimal precioCompra = decimal.Parse(txt_precio_compra.Text);
                if (precioCompra <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio de compra válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                decimal precioVenta = decimal.Parse(txt_precio_venta.Text);
                if (precioVenta <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio de venta válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los valores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }//Se usa una sola vez

        private bool ObtenerValores2()
        {
            try
            {

                // Obtener el valor seleccionado del ComboBox de Productos
                string idProducto = cb_producto.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(idProducto))
                {
                    MessageBox.Show("Por favor, seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                string NombreProducto = cb_producto.Text;

                // Obtener la cantidad del TextBox
                if (!int.TryParse(txt_cantidad.Text, out int cantidadEntrada))
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                decimal precioCompra = decimal.Parse(txt_precio_compra.Text);
                if (precioCompra <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio de compra válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                decimal precioVenta = decimal.Parse(txt_precio_venta.Text);
                if (precioVenta <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio de venta válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Asignar los valores a la clase CCompra
                int idDetalleCompra = temporalIdDetalleCompra + 1;
                if (idDetalleCompra <= 0)
                {
                    MessageBox.Show("Error al generar el ID detalle compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                temporalIdDetalleCompra = idDetalleCompra;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los valores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //COMPRAR PRODUCTO
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            
            CDetalleCompra detalleCompra = new CDetalleCompra();

            if (primeraVez == false)
            {
                if (ObtenerValores() == false)
                {
                    return;
                }

                string idProveedor = cb_proveedor.SelectedValue?.ToString();
                string tipoRecibo = cb_tipo_recibo.Text.Trim();
                string nroRecibo = txt_id_recibo.Text.Trim();
                NroRecibo = nroRecibo;//almacer globalmente
                DateTime fechaIngreso = dtp_fecha_registro.Value;

                int idDetalleCompra = temporalIdDetalleCompra;
                string idProducto = cb_producto.SelectedValue?.ToString();
                string NombreProducto = cb_producto.Text;
                int cantidadEntrada = int.Parse(txt_cantidad.Text);
                decimal precioCompra = decimal.Parse(txt_precio_compra.Text);
                decimal precioVenta = decimal.Parse(txt_precio_venta.Text);

                compra.IdReciboCompra = nroRecibo;
                compra.TipoRecibo = tipoRecibo;
                compra.FechaIngreso = fechaIngreso;
                compra.IdProveedor = int.Parse(idProveedor);

                detalleCompra.IdDetalleCompra = idDetalleCompra;
                detalleCompra.CantidadEntrada = cantidadEntrada;
                detalleCompra.IdProducto = int.Parse(idProducto);
                detalleCompra.NombreProducto = NombreProducto;
                detalleCompra.PrecioCompra = precioCompra;
                detalleCompra.PrecioVenta = precioVenta;
                detalleCompra.Subtotal = cantidadEntrada * precioCompra;
                //Insertar en la lista de compras
                listaCompras.Add(detalleCompra);
                fill_data();
                listaIdReciboCompra.Add(detalleCompra.IdDetalleCompra);
                LimpiarCampos();

                //Desablitar algunos controles
                cb_proveedor.Enabled = false;
                cb_tipo_recibo.Enabled = false;
                txt_id_recibo.Enabled = false;
                dtp_fecha_registro.Enabled = false;
                btn_filtrar_proveedor.Enabled = false;
                btn_registrar_proveedor.Enabled = false;

                primeraVez = true;
            }
            else
            {
                if (ObtenerValores2() == false)
                {
                    return;
                }

                
                string idProducto = cb_producto.SelectedValue?.ToString();
                string NombreProducto = cb_producto.Text;
                int cantidadEntrada = int.Parse(txt_cantidad.Text);
                decimal precioCompra = decimal.Parse(txt_precio_compra.Text);
                decimal precioVenta = decimal.Parse(txt_precio_venta.Text);

                detalleCompra.IdDetalleCompra = temporalIdDetalleCompra;
                detalleCompra.CantidadEntrada = cantidadEntrada;
                detalleCompra.IdProducto = int.Parse(idProducto);
                detalleCompra.NombreProducto = NombreProducto;
                detalleCompra.PrecioCompra = precioCompra;
                detalleCompra.PrecioVenta = precioVenta;
                detalleCompra.Subtotal = cantidadEntrada * precioCompra;
                //Insertar en la lista de compras
                listaCompras.Add(detalleCompra);
                listaIdReciboCompra.Add(detalleCompra.IdDetalleCompra);
                fill_data();
                LimpiarCampos();
            }


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
            LimpiarTodosCampos();
            btn_imprimir.Enabled = false;
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
                CProducto1 producto = frm_Producto_Search.ProductoSeleccionado;
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
                    int idDetalleCompra = int.Parse(dgv_Recibo_Compra[0, fila].Value.ToString().Trim());

                    // Mostrar mensaje de confirmación
                    DialogResult resultadoConfirmacion = MessageBox.Show($"¿Está seguro de que desea eliminar la compra con ID: {idDetalleCompra}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultadoConfirmacion == DialogResult.Yes)
                    {
                        //Eliminar de la listaIdReciboCompra
                        listaIdReciboCompra.Remove(idDetalleCompra);
                        //Eliminar de la listaCompras
                        listaCompras.RemoveAll(detalleCompra => detalleCompra.IdDetalleCompra == idDetalleCompra);
                        fill_data();
                        //Imprimir la listaCompra
                        StringBuilder sb = new StringBuilder();

                        foreach (CDetalleCompra detalle in listaCompras)
                        {
                            sb.AppendLine($"ID: {detalle.IdDetalleCompra}, Producto: {detalle.NombreProducto}, Cantidad: {detalle.CantidadEntrada}, Subtotal: {detalle.Subtotal}");
                        }

                        MessageBox.Show(sb.ToString(), "Detalles de la Compra");
                        MessageBox.Show("La compra se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string FONT = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
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
            try
            {
                // Generar el HTML de la factura
                string htmlFactura = GenerarHtmlFactura(NroRecibo);

                // Especificar la ruta de guardado para el PDF
                string rutaPdf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Factura_{NroRecibo}.pdf");

                // Generar el PDF desde el HTML
                if (GenerarPdfDesdeHtml(htmlFactura, rutaPdf))
                {
                    MessageBox.Show($"Factura generada y guardada en: {rutaPdf}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //System.Diagnostics.Process.Start(rutaPdf); // Abre el PDF
                    try
                    {
                        System.Diagnostics.Process.Start(new ProcessStartInfo(rutaPdf) { UseShellExecute = true }); // Abre el PDF con la aplicación predeterminada
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al abrir el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al generar la factura en PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex){
                MessageBox.Show($"Error al generar la factura en PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            /*if (string.IsNullOrEmpty(NroRecibo))
            {
                MessageBox.Show("Primero debe realizar al menos una compra para guardar el recibo como PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método
            }
            Connection_Compra con = new Connection_Compra();
            Dictionary<string, object> datosRecibo = con.ObtenerDatosReciboCompraPorId(NroRecibo);
            if (datosRecibo.Count > 0) // Verifica si se encontraron resultados
            {
                string nroRecibo = datosRecibo["Nro_Recibo"].ToString();
                string tipoRecibo = datosRecibo["Tipo_Recibo"].ToString();
                DateTime fechaIngreso = (DateTime)datosRecibo["Fecha_Ingreso"]; // Cast al tipo DateTime
                string proveedor = datosRecibo["Proveedor"].ToString();
                string nroDocumento = datosRecibo["Nro_documento"].ToString();

                Console.WriteLine($"Nro Recibo: {nroRecibo}");
                Console.WriteLine($"Tipo Recibo: {tipoRecibo}");
                Console.WriteLine($"Fecha Ingreso: {fechaIngreso}");
                Console.WriteLine($"Proveedor: {proveedor}");
                Console.WriteLine($"Nro Documento: {nroDocumento}");
            }
            else
            {
                MessageBox.Show($"No se encontró información para el ID de recibo: {NroRecibo}");
            }*/


            /*
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
            }*/
        }

        private void cb_tipo_recibo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection_Compra connection_Compra = new Connection_Compra();
            if (cb_tipo_recibo.Text == "Factura")
            {
                string nroFacrura = connection_Compra.ObtenerNextIdReciboCompra_Factura();
                txt_id_recibo.Text = nroFacrura;
            }
            else if (cb_tipo_recibo.Text == "Boleta")
            {
                string nroBoleta = connection_Compra.ObtenerNextIdReciboCompra_Boleta();
                txt_id_recibo.Text = nroBoleta;
            }
            else
            {
                txt_id_recibo.Text = "";
            }
        }

        private void btn_guardar_DB_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje de confirmación
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea guardar los datos de esta compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar si el usuario confirmó
            if (resultado == DialogResult.Yes)
            {
                //Guardar los datos
                Connection_Compra connection_Compra = new Connection_Compra();
                if (connection_Compra.InsertarCompra(compra, listaCompras))
                {
                    MessageBox.Show("Compra registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    desactivarControles();
                    btn_imprimir.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error al registrar la compra. Por favor, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La operación ha sido cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void desactivarControles()
        {
            cb_proveedor.Enabled = false;
            cb_tipo_recibo.Enabled = false;
            txt_id_recibo.Enabled = false;
            dtp_fecha_registro.Enabled = false;
            btn_filtrar_proveedor.Enabled = false;
            btn_registrar_proveedor.Enabled = false;

            cb_producto.Enabled = false;
            txt_descripcion.Enabled = false;
            txt_unidad.Enabled = false;
            txt_stock.Enabled = false;
            txt_cantidad.Enabled = false;
            txt_precio_compra.Enabled = false;
            txt_precio_venta.Enabled = false;
            txt_precio_unitario.Enabled = false;
            btn_filtrar_producto.Enabled = false;
            btn_registrar_producto.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_guardar.Enabled = false;
        }

        private void reset()
        {
            LimpiarTodosCampos();
            listaCompras.Clear();
            listaIdReciboCompra.Clear();
            activarControles();
            primeraVez = false;
            NroRecibo = "";
            temporalIdDetalleCompra = 0;
            fila = -1;
            //Resetear el objeto compra de la clase CCompra
            compra = new CReciboCompra();

        }

        private void activarControles()
        {
            cb_proveedor.Enabled = true;
            cb_tipo_recibo.Enabled = true;
            txt_id_recibo.Enabled = true;
            dtp_fecha_registro.Enabled = true;
            btn_filtrar_proveedor.Enabled = true;
            btn_registrar_proveedor.Enabled = true;
            cb_producto.Enabled = true;
            txt_descripcion.Enabled = true;
            txt_unidad.Enabled = true;
            txt_stock.Enabled = true;
            txt_cantidad.Enabled = true;
            txt_precio_compra.Enabled = true;
            txt_precio_venta.Enabled = true;
            txt_precio_unitario.Enabled = true;
            btn_filtrar_producto.Enabled = true;
            btn_registrar_producto.Enabled = true;
        }
        private void LimpiarTodosCampos()
        {
            cb_proveedor.SelectedIndex = -1;
            cb_tipo_recibo.SelectedIndex = -1;
            txt_id_recibo.Clear();
            dtp_fecha_registro.Value = DateTime.Now;
            cb_producto.SelectedIndex = -1;
            txt_descripcion.Clear();
            txt_unidad.Clear();
            txt_stock.Clear();
            txt_cantidad.Clear();
            txt_precio_compra.Clear();
            txt_precio_venta.Clear();
            txt_precio_unitario.Clear();
        }

        private void txt_precio_compra_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_precio_compra.Text.Trim(), out decimal precioCompra))
            {
                decimal precioVenta = precioCompra + 0.03m * precioCompra;
                txt_precio_venta.Text = precioVenta.ToString();
            }
            else
            {
                // Handle invalid input, e.g., clear the output TextBox or show a message
                txt_precio_venta.Text = string.Empty;
            }
        }


        public string GenerarHtmlFactura(string nroCompra)
        {
            Connection_Compra connectionCompra = new Connection_Compra();

            // Obtener los datos del recibo de compra
            Dictionary<string, object> datosRecibo = connectionCompra.ObtenerDatosReciboCompraPorId(nroCompra);

            // Obtener los detalles de la compra
            DataSet detallesCompraDataSet = connectionCompra.ObtenerDetallesCompraPorIdRecibo(nroCompra);


            // Leer la plantilla HTML
            string htmlTemplatePath = @"C:\Users\ALEX\source\repos\ProjectPI_Building\ProjectPI_Building\Html\invoice_template.html";
            //string htmlTemplatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Html", "invoice_template.html");
            string htmlTemplate = File.ReadAllText(htmlTemplatePath);

            // Reemplazar los valores estáticos en la plantilla con los datos del recibo
            //htmlTemplate=htmlTemplate.Replace("<span id=\"tipoRecibo\"></span>", datosRecibo[])
            htmlTemplate = htmlTemplate.Replace("<span id=\"nro-factura\"></span>", datosRecibo["Nro_Recibo"].ToString());
            htmlTemplate = htmlTemplate.Replace("<span id=\"fecha\"></span>", ((DateTime)datosRecibo["Fecha_Ingreso"]).ToString("dd/MM/yyyy")); // Formatear la fecha
            htmlTemplate = htmlTemplate.Replace("<span id=\"proveedor\"></span>", datosRecibo["Proveedor"].ToString());
            htmlTemplate = htmlTemplate.Replace("<span id=\"nro-documento\"></span>", datosRecibo["Nro_documento"].ToString());
            htmlTemplate = htmlTemplate.Replace("<span id=\"tipo-recibo\"></span>", datosRecibo["Tipo_Recibo"].ToString());

            decimal total = 0;

            // Construir las filas de la tabla de detalles
            StringBuilder tablaDetallesHtml = new StringBuilder();
            if (detallesCompraDataSet != null && detallesCompraDataSet.Tables.Count > 0)
            {
                DataTable tablaDetalles = detallesCompraDataSet.Tables[0];
                foreach (DataRow fila in tablaDetalles.Rows)
                {
                    tablaDetallesHtml.Append("<tr>");
                    tablaDetallesHtml.Append($"<td>{fila["Producto_Categoria"]}</td>");
                    tablaDetallesHtml.Append($"<td>{fila["Producto_Descripcion"]}</td>");
                    tablaDetallesHtml.Append($"<td>{fila["Cantidad_Comprada"]}</td>");
                    tablaDetallesHtml.Append($"<td>{fila["PrecioCompra"]}</td>");
                    tablaDetallesHtml.Append($"<td>{fila["Precio_Venta"]}</td>");
                    tablaDetallesHtml.Append($"<td>{fila["Subtotal"]}</td>");
                    tablaDetallesHtml.Append("</tr>");

                    total += Convert.ToDecimal(fila["Subtotal"]);
                }
            }
            // Insertar las filas de la tabla en la plantilla
            htmlTemplate = htmlTemplate.Replace("<tbody id=\"tabla-detalles\">\r\n                <!-- Aquí se insertarán las filas dinámicamente -->\r\n            </tbody>", $"<tbody id=\"tabla-detalles\">\r\n{tablaDetallesHtml.ToString()}\r\n            </tbody>");

            // Insertar el total
            htmlTemplate = htmlTemplate.Replace("<span id=\"total\"></span>", total.ToString("N2"));

            return htmlTemplate;
        }

        public bool GenerarPdfDesdeHtml(string html, string outputPath)
        {
            try
            {
                // Verifica si el HTML está vacío o nulo
                if (string.IsNullOrEmpty(html))
                {
                    Console.WriteLine("Error: El HTML está vacío o nulo.");
                    return false;
                }

                // Configurar las propiedades de conversión (opcional)
                ConverterProperties converterProperties = new ConverterProperties();

                // Definir el tamaño de la página (ancho: 150mm, alto: 80mm) - ORIENTACIÓN HORIZONTAL
                float anchoEnPuntos = 150 * 2.83465f;
                float altoEnPuntos = 80 * 2.83465f;
                PageSize pageSize = new PageSize(anchoEnPuntos, altoEnPuntos);

                // Crear el documento PDF con el tamaño de página especificado
                using (FileStream pdfStream = new FileStream(outputPath, FileMode.Create))
                {
                    PdfWriter writer = new PdfWriter(pdfStream);
                    PdfDocument pdfDocument = new PdfDocument(writer);
                    pdfDocument.SetDefaultPageSize(pageSize); // Establecer el tamaño de página por defecto
                    Document document = new Document(pdfDocument);

                    // Convertir el HTML a PDF
                    if (pdfDocument != null && converterProperties != null)
                    {
                        HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);
                    }
                    else
                    {
                        Console.WriteLine("Error: pdfDocument o converterProperties son nulos.");
                        return false;
                    }
                }

                return true; // Indica que la operación fue exitosa
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el PDF: " + ex.Message);
                return false; // Indica que hubo un error
            }
        }

    }
}
