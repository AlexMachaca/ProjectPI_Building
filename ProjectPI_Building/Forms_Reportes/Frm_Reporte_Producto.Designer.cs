namespace ProjectPI_Building.Forms_Reportes
{
    partial class Frm_Reporte_Producto
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
            dgv_producto = new DataGridView();
            cb_categoria = new ComboBox();
            btn_imprimir = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_producto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_imprimir).BeginInit();
            SuspendLayout();
            // 
            // dgv_producto
            // 
            dgv_producto.AllowUserToAddRows = false;
            dgv_producto.AllowUserToDeleteRows = false;
            dgv_producto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_producto.Location = new Point(29, 108);
            dgv_producto.Name = "dgv_producto";
            dgv_producto.ReadOnly = true;
            dgv_producto.RowHeadersWidth = 51;
            dgv_producto.Size = new Size(910, 529);
            dgv_producto.TabIndex = 0;
            // 
            // cb_categoria
            // 
            cb_categoria.FormattingEnabled = true;
            cb_categoria.Items.AddRange(new object[] { "Electrónica", "Ropa", "Alimentos", "Muebles", "Juguetes", "Libros", "Herramientas", "Artículos de oficina", "Cosméticos", "Deportes" });
            cb_categoria.Location = new Point(960, 108);
            cb_categoria.Name = "cb_categoria";
            cb_categoria.Size = new Size(215, 28);
            cb_categoria.TabIndex = 1;
            cb_categoria.SelectedIndexChanged += cb_categoria_SelectedIndexChanged;
            // 
            // btn_imprimir
            // 
            btn_imprimir.BackColor = Color.Transparent;
            btn_imprimir.Location = new Point(960, 460);
            btn_imprimir.Name = "btn_imprimir";
            btn_imprimir.Size = new Size(196, 78);
            btn_imprimir.TabIndex = 2;
            btn_imprimir.TabStop = false;
            btn_imprimir.Click += btn_imprimir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(245, 45);
            label1.Name = "label1";
            label1.Size = new Size(595, 46);
            label1.TabIndex = 4;
            label1.Text = "Reporte de Productos por Categoria";
            // 
            // Frm_Reporte_Producto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 667);
            Controls.Add(label1);
            Controls.Add(btn_imprimir);
            Controls.Add(cb_categoria);
            Controls.Add(dgv_producto);
            Name = "Frm_Reporte_Producto";
            Text = "Frm_Reporte_Producto";
            Load += Frm_Reporte_Producto_Load;
            Controls.SetChildIndex(dgv_producto, 0);
            Controls.SetChildIndex(cb_categoria, 0);
            Controls.SetChildIndex(btn_imprimir, 0);
            Controls.SetChildIndex(btn_salir, 0);
            Controls.SetChildIndex(btn_maximizar, 0);
            Controls.SetChildIndex(btn_minimizar, 0);
            Controls.SetChildIndex(btn_exit, 0);
            Controls.SetChildIndex(label1, 0);
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_producto).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_imprimir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_producto;
        private ComboBox cb_categoria;
        private PictureBox btn_imprimir;
        private Label label1;
    }
}