namespace ProjectPI_Building.Forms_Register
{
    partial class Frm_Compra_Producto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Compra_Producto));
            btn_salir = new PictureBox();
            btn_guardar = new PictureBox();
            btn_exit = new PictureBox();
            btn_maximizar = new PictureBox();
            btn_minimizar = new PictureBox();
            dgv_Recibo_Compra = new DataGridView();
            cb_proveedor = new ComboBox();
            cb_tipo_recibo = new ComboBox();
            txt_id_recibo = new TextBox();
            dtp_fecha_registro = new DateTimePicker();
            cb_producto = new ComboBox();
            txt_descripcion = new TextBox();
            txt_unidad = new TextBox();
            txt_stock = new TextBox();
            txt_cantidad = new TextBox();
            txt_precio_compra = new TextBox();
            txt_precio_venta = new TextBox();
            txt_precio_unitario = new TextBox();
            btn_filtrar_proveedor = new PictureBox();
            btn_registrar_proveedor = new PictureBox();
            btn_registrar_producto = new PictureBox();
            btn_filtrar_producto = new PictureBox();
            btn_imprimir = new PictureBox();
            btn_eliminar = new PictureBox();
            btn_guardar_DB = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_guardar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Recibo_Compra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_filtrar_proveedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_registrar_proveedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_registrar_producto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_filtrar_producto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_imprimir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_eliminar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_guardar_DB).BeginInit();
            SuspendLayout();
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Transparent;
            btn_salir.Location = new Point(1011, 671);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(122, 67);
            btn_salir.TabIndex = 0;
            btn_salir.TabStop = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_guardar
            // 
            btn_guardar.BackColor = Color.Transparent;
            btn_guardar.Location = new Point(833, 336);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(44, 52);
            btn_guardar.TabIndex = 1;
            btn_guardar.TabStop = false;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.Transparent;
            btn_exit.Location = new Point(1110, 17);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(40, 61);
            btn_exit.TabIndex = 2;
            btn_exit.TabStop = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.BackColor = Color.Transparent;
            btn_maximizar.Location = new Point(1050, 17);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(40, 61);
            btn_maximizar.TabIndex = 3;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_minimizar
            // 
            btn_minimizar.BackColor = Color.Transparent;
            btn_minimizar.Location = new Point(994, 17);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(40, 61);
            btn_minimizar.TabIndex = 4;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // dgv_Recibo_Compra
            // 
            dgv_Recibo_Compra.AllowUserToAddRows = false;
            dgv_Recibo_Compra.AllowUserToDeleteRows = false;
            dgv_Recibo_Compra.BackgroundColor = Color.RosyBrown;
            dgv_Recibo_Compra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Recibo_Compra.Location = new Point(74, 506);
            dgv_Recibo_Compra.Name = "dgv_Recibo_Compra";
            dgv_Recibo_Compra.ReadOnly = true;
            dgv_Recibo_Compra.RowHeadersWidth = 51;
            dgv_Recibo_Compra.Size = new Size(931, 232);
            dgv_Recibo_Compra.TabIndex = 5;
            dgv_Recibo_Compra.CellMouseClick += dgv_Recibo_Compra_CellMouseClick;
            // 
            // cb_proveedor
            // 
            cb_proveedor.FormattingEnabled = true;
            cb_proveedor.Location = new Point(267, 164);
            cb_proveedor.Name = "cb_proveedor";
            cb_proveedor.Size = new Size(565, 28);
            cb_proveedor.TabIndex = 6;
            // 
            // cb_tipo_recibo
            // 
            cb_tipo_recibo.FormattingEnabled = true;
            cb_tipo_recibo.Items.AddRange(new object[] { "Boleta", "Factura" });
            cb_tipo_recibo.Location = new Point(213, 210);
            cb_tipo_recibo.Name = "cb_tipo_recibo";
            cb_tipo_recibo.Size = new Size(150, 28);
            cb_tipo_recibo.TabIndex = 7;
            cb_tipo_recibo.SelectedIndexChanged += cb_tipo_recibo_SelectedIndexChanged;
            // 
            // txt_id_recibo
            // 
            txt_id_recibo.Location = new Point(510, 210);
            txt_id_recibo.Multiline = true;
            txt_id_recibo.Name = "txt_id_recibo";
            txt_id_recibo.ReadOnly = true;
            txt_id_recibo.Size = new Size(162, 41);
            txt_id_recibo.TabIndex = 8;
            // 
            // dtp_fecha_registro
            // 
            dtp_fecha_registro.Format = DateTimePickerFormat.Short;
            dtp_fecha_registro.Location = new Point(854, 217);
            dtp_fecha_registro.Name = "dtp_fecha_registro";
            dtp_fecha_registro.Size = new Size(160, 27);
            dtp_fecha_registro.TabIndex = 9;
            // 
            // cb_producto
            // 
            cb_producto.FormattingEnabled = true;
            cb_producto.Location = new Point(255, 292);
            cb_producto.Name = "cb_producto";
            cb_producto.Size = new Size(570, 28);
            cb_producto.TabIndex = 10;
            cb_producto.SelectedIndexChanged += cb_producto_SelectedIndexChanged;
            // 
            // txt_descripcion
            // 
            txt_descripcion.Location = new Point(255, 341);
            txt_descripcion.Multiline = true;
            txt_descripcion.Name = "txt_descripcion";
            txt_descripcion.ReadOnly = true;
            txt_descripcion.Size = new Size(570, 41);
            txt_descripcion.TabIndex = 11;
            // 
            // txt_unidad
            // 
            txt_unidad.Location = new Point(255, 394);
            txt_unidad.Multiline = true;
            txt_unidad.Name = "txt_unidad";
            txt_unidad.ReadOnly = true;
            txt_unidad.Size = new Size(162, 41);
            txt_unidad.TabIndex = 12;
            // 
            // txt_stock
            // 
            txt_stock.Location = new Point(551, 390);
            txt_stock.Multiline = true;
            txt_stock.Name = "txt_stock";
            txt_stock.ReadOnly = true;
            txt_stock.Size = new Size(162, 41);
            txt_stock.TabIndex = 13;
            // 
            // txt_cantidad
            // 
            txt_cantidad.Location = new Point(869, 393);
            txt_cantidad.Multiline = true;
            txt_cantidad.Name = "txt_cantidad";
            txt_cantidad.Size = new Size(136, 41);
            txt_cantidad.TabIndex = 14;
            // 
            // txt_precio_compra
            // 
            txt_precio_compra.Location = new Point(255, 446);
            txt_precio_compra.Multiline = true;
            txt_precio_compra.Name = "txt_precio_compra";
            txt_precio_compra.Size = new Size(162, 41);
            txt_precio_compra.TabIndex = 15;
            txt_precio_compra.TextChanged += txt_precio_compra_TextChanged;
            // 
            // txt_precio_venta
            // 
            txt_precio_venta.Location = new Point(563, 443);
            txt_precio_venta.Multiline = true;
            txt_precio_venta.Name = "txt_precio_venta";
            txt_precio_venta.Size = new Size(150, 41);
            txt_precio_venta.TabIndex = 16;
            // 
            // txt_precio_unitario
            // 
            txt_precio_unitario.Location = new Point(883, 442);
            txt_precio_unitario.Multiline = true;
            txt_precio_unitario.Name = "txt_precio_unitario";
            txt_precio_unitario.ReadOnly = true;
            txt_precio_unitario.Size = new Size(120, 41);
            txt_precio_unitario.TabIndex = 17;
            // 
            // btn_filtrar_proveedor
            // 
            btn_filtrar_proveedor.BackColor = Color.Transparent;
            btn_filtrar_proveedor.Location = new Point(838, 147);
            btn_filtrar_proveedor.Name = "btn_filtrar_proveedor";
            btn_filtrar_proveedor.Size = new Size(52, 55);
            btn_filtrar_proveedor.TabIndex = 18;
            btn_filtrar_proveedor.TabStop = false;
            btn_filtrar_proveedor.Click += btn_filtrar_proveedor_Click;
            // 
            // btn_registrar_proveedor
            // 
            btn_registrar_proveedor.BackColor = Color.Transparent;
            btn_registrar_proveedor.Location = new Point(896, 147);
            btn_registrar_proveedor.Name = "btn_registrar_proveedor";
            btn_registrar_proveedor.Size = new Size(52, 55);
            btn_registrar_proveedor.TabIndex = 19;
            btn_registrar_proveedor.TabStop = false;
            btn_registrar_proveedor.Click += btn_registrar_proveedor_Click;
            // 
            // btn_registrar_producto
            // 
            btn_registrar_producto.BackColor = Color.Transparent;
            btn_registrar_producto.Location = new Point(888, 275);
            btn_registrar_producto.Name = "btn_registrar_producto";
            btn_registrar_producto.Size = new Size(52, 55);
            btn_registrar_producto.TabIndex = 21;
            btn_registrar_producto.TabStop = false;
            btn_registrar_producto.Click += btn_registrar_producto_Click;
            // 
            // btn_filtrar_producto
            // 
            btn_filtrar_producto.BackColor = Color.Transparent;
            btn_filtrar_producto.Location = new Point(830, 275);
            btn_filtrar_producto.Name = "btn_filtrar_producto";
            btn_filtrar_producto.Size = new Size(52, 55);
            btn_filtrar_producto.TabIndex = 20;
            btn_filtrar_producto.TabStop = false;
            btn_filtrar_producto.Click += btn_filtrar_producto_Click;
            // 
            // btn_imprimir
            // 
            btn_imprimir.BackColor = Color.Transparent;
            btn_imprimir.Location = new Point(1011, 595);
            btn_imprimir.Name = "btn_imprimir";
            btn_imprimir.Size = new Size(118, 54);
            btn_imprimir.TabIndex = 22;
            btn_imprimir.TabStop = false;
            btn_imprimir.Click += btn_imprimir_Click;
            // 
            // btn_eliminar
            // 
            btn_eliminar.BackColor = Color.Transparent;
            btn_eliminar.Location = new Point(883, 336);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(44, 52);
            btn_eliminar.TabIndex = 23;
            btn_eliminar.TabStop = false;
            btn_eliminar.Click += btn_eliminar_Click;
            // 
            // btn_guardar_DB
            // 
            btn_guardar_DB.BackColor = Color.Transparent;
            btn_guardar_DB.Location = new Point(1008, 524);
            btn_guardar_DB.Name = "btn_guardar_DB";
            btn_guardar_DB.Size = new Size(121, 51);
            btn_guardar_DB.TabIndex = 24;
            btn_guardar_DB.TabStop = false;
            btn_guardar_DB.Click += btn_guardar_DB_Click;
            // 
            // Frm_Compra_Producto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1155, 767);
            Controls.Add(btn_guardar_DB);
            Controls.Add(btn_eliminar);
            Controls.Add(btn_imprimir);
            Controls.Add(btn_registrar_producto);
            Controls.Add(btn_filtrar_producto);
            Controls.Add(btn_registrar_proveedor);
            Controls.Add(btn_filtrar_proveedor);
            Controls.Add(txt_precio_unitario);
            Controls.Add(txt_precio_venta);
            Controls.Add(txt_precio_compra);
            Controls.Add(txt_cantidad);
            Controls.Add(txt_stock);
            Controls.Add(txt_unidad);
            Controls.Add(txt_descripcion);
            Controls.Add(cb_producto);
            Controls.Add(dtp_fecha_registro);
            Controls.Add(txt_id_recibo);
            Controls.Add(cb_tipo_recibo);
            Controls.Add(cb_proveedor);
            Controls.Add(dgv_Recibo_Compra);
            Controls.Add(btn_minimizar);
            Controls.Add(btn_maximizar);
            Controls.Add(btn_exit);
            Controls.Add(btn_guardar);
            Controls.Add(btn_salir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Compra_Producto";
            Text = "Frm_Compra_Producto";
            Load += Frm_Compra_Producto_Load;
            MouseDown += Frm_Compra_Producto_MouseDown;
            MouseMove += Frm_Compra_Producto_MouseMove;
            MouseUp += Frm_Compra_Producto_MouseUp;
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_guardar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Recibo_Compra).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_filtrar_proveedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_registrar_proveedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_registrar_producto).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_filtrar_producto).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_imprimir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_eliminar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_guardar_DB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btn_salir;
        private PictureBox btn_guardar;
        private PictureBox btn_exit;
        private PictureBox btn_maximizar;
        private PictureBox btn_minimizar;
        private DataGridView dgv_Recibo_Compra;
        private ComboBox cb_proveedor;
        private ComboBox cb_tipo_recibo;
        private TextBox txt_id_recibo;
        private DateTimePicker dtp_fecha_registro;
        private ComboBox cb_producto;
        private TextBox txt_descripcion;
        private TextBox txt_unidad;
        private TextBox txt_stock;
        private TextBox txt_cantidad;
        private TextBox txt_precio_compra;
        private TextBox txt_precio_venta;
        private TextBox txt_precio_unitario;
        private PictureBox btn_filtrar_proveedor;
        private PictureBox btn_registrar_proveedor;
        private PictureBox btn_registrar_producto;
        private PictureBox btn_filtrar_producto;
        private PictureBox btn_imprimir;
        private PictureBox btn_eliminar;
        private PictureBox btn_guardar_DB;
    }
}