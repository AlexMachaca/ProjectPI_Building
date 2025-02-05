namespace ProjectPI_Building.Forms_Register
{
    partial class Frm_Producto_Register
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
            btn_guardar = new PictureBox();
            groupBox1 = new GroupBox();
            dtp_fecha_actualizacion = new DateTimePicker();
            cb_unidad = new ComboBox();
            cb_categoria = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txt_precio_unitario = new TextBox();
            txt_precio_venta = new TextBox();
            txt_precio_compra = new TextBox();
            txt_stock = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            txt_cantidad = new TextBox();
            txt_descripcion = new TextBox();
            txt_id = new TextBox();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_guardar).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(328, 13);
            label1.Size = new Size(311, 34);
            label1.Text = "Registro de Producto";
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(840, 674);
            // 
            // btn_guardar
            // 
            btn_guardar.BackColor = Color.Transparent;
            btn_guardar.Location = new Point(651, 674);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(156, 62);
            btn_guardar.TabIndex = 5;
            btn_guardar.TabStop = false;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Honeydew;
            groupBox1.Controls.Add(dtp_fecha_actualizacion);
            groupBox1.Controls.Add(cb_unidad);
            groupBox1.Controls.Add(cb_categoria);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txt_precio_unitario);
            groupBox1.Controls.Add(txt_precio_venta);
            groupBox1.Controls.Add(txt_precio_compra);
            groupBox1.Controls.Add(txt_stock);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_cantidad);
            groupBox1.Controls.Add(txt_descripcion);
            groupBox1.Controls.Add(txt_id);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(44, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(951, 297);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Producto";
            // 
            // dtp_fecha_actualizacion
            // 
            dtp_fecha_actualizacion.Location = new Point(610, 198);
            dtp_fecha_actualizacion.Name = "dtp_fecha_actualizacion";
            dtp_fecha_actualizacion.Size = new Size(289, 28);
            dtp_fecha_actualizacion.TabIndex = 22;
            // 
            // cb_unidad
            // 
            cb_unidad.FormattingEnabled = true;
            cb_unidad.Items.AddRange(new object[] { "Unidad", "Kilogramo", "Litro", "Metro", "Caja", "Paquete", "Gramo", "Centímetro", "Pulgada", "Set" });
            cb_unidad.Location = new Point(139, 164);
            cb_unidad.Name = "cb_unidad";
            cb_unidad.Size = new Size(289, 28);
            cb_unidad.TabIndex = 21;
            // 
            // cb_categoria
            // 
            cb_categoria.FormattingEnabled = true;
            cb_categoria.Items.AddRange(new object[] { "Electrónica", "Ropa", "Alimentos", "Muebles", "Juguetes", "Libros", "Herramientas", "Artículos de oficina", "Cosméticos", "Deportes" });
            cb_categoria.Location = new Point(139, 97);
            cb_categoria.Name = "cb_categoria";
            cb_categoria.Size = new Size(289, 28);
            cb_categoria.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(467, 204);
            label7.Name = "label7";
            label7.Size = new Size(146, 20);
            label7.TabIndex = 19;
            label7.Text = "Fecha Actualizacion";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(467, 170);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 18;
            label8.Text = "Precio Unitario";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(467, 136);
            label9.Name = "label9";
            label9.Size = new Size(96, 20);
            label9.TabIndex = 17;
            label9.Text = "Precio Venta";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(467, 102);
            label10.Name = "label10";
            label10.Size = new Size(110, 20);
            label10.TabIndex = 16;
            label10.Text = "Precio Compra";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(467, 68);
            label11.Name = "label11";
            label11.Size = new Size(45, 20);
            label11.TabIndex = 15;
            label11.Text = "Stock";
            // 
            // txt_precio_unitario
            // 
            txt_precio_unitario.Location = new Point(610, 167);
            txt_precio_unitario.Name = "txt_precio_unitario";
            txt_precio_unitario.Size = new Size(289, 28);
            txt_precio_unitario.TabIndex = 13;
            // 
            // txt_precio_venta
            // 
            txt_precio_venta.Location = new Point(610, 133);
            txt_precio_venta.Name = "txt_precio_venta";
            txt_precio_venta.Size = new Size(289, 28);
            txt_precio_venta.TabIndex = 12;
            // 
            // txt_precio_compra
            // 
            txt_precio_compra.Location = new Point(610, 99);
            txt_precio_compra.Name = "txt_precio_compra";
            txt_precio_compra.Size = new Size(289, 28);
            txt_precio_compra.TabIndex = 11;
            // 
            // txt_stock
            // 
            txt_stock.Location = new Point(610, 65);
            txt_stock.Name = "txt_stock";
            txt_stock.Size = new Size(289, 28);
            txt_stock.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 201);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 9;
            label6.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 167);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 8;
            label4.Text = "Unidad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 133);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 7;
            label5.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 99);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 6;
            label3.Text = "Categoria";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 65);
            label2.Name = "label2";
            label2.Size = new Size(22, 20);
            label2.TabIndex = 5;
            label2.Text = "Id";
            // 
            // txt_cantidad
            // 
            txt_cantidad.Location = new Point(139, 198);
            txt_cantidad.Name = "txt_cantidad";
            txt_cantidad.Size = new Size(289, 28);
            txt_cantidad.TabIndex = 4;
            // 
            // txt_descripcion
            // 
            txt_descripcion.Location = new Point(139, 130);
            txt_descripcion.Name = "txt_descripcion";
            txt_descripcion.Size = new Size(289, 28);
            txt_descripcion.TabIndex = 2;
            // 
            // txt_id
            // 
            txt_id.Location = new Point(139, 62);
            txt_id.Name = "txt_id";
            txt_id.ReadOnly = true;
            txt_id.Size = new Size(289, 28);
            txt_id.TabIndex = 0;
            // 
            // Frm_Producto_Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1027, 765);
            Controls.Add(groupBox1);
            Controls.Add(btn_guardar);
            Name = "Frm_Producto_Register";
            Text = "Frm_Producto_Register";
            Load += Frm_Producto_Register_Load;
            Controls.SetChildIndex(btn_salir, 0);
            Controls.SetChildIndex(btn_exit, 0);
            Controls.SetChildIndex(btn_maximizar, 0);
            Controls.SetChildIndex(btn_minimizar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btn_guardar, 0);
            Controls.SetChildIndex(groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_guardar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btn_guardar;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private TextBox txt_cantidad;
        private TextBox txt_descripcion;
        private TextBox txt_id;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txt_precio_unitario;
        private TextBox txt_precio_venta;
        private TextBox txt_precio_compra;
        private TextBox txt_stock;
        private Label label6;
        private DateTimePicker dtp_fecha_actualizacion;
        private ComboBox cb_unidad;
        private ComboBox cb_categoria;
    }
}