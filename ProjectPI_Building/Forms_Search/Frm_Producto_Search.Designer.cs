namespace ProjectPI_Building.Forms_Search
{
    partial class Frm_Producto_Search
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
            dgv_productos = new DataGridView();
            txt_filtrar = new TextBox();
            btn_eliminar = new PictureBox();
            btn_modificar = new PictureBox();
            btn_nuevo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_productos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_eliminar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_modificar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_nuevo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(269, 21);
            label1.Size = new Size(332, 34);
            label1.Text = "Busqueda de Producto";
            // 
            // dgv_productos
            // 
            dgv_productos.AllowUserToAddRows = false;
            dgv_productos.AllowUserToDeleteRows = false;
            dgv_productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_productos.Location = new Point(12, 201);
            dgv_productos.Name = "dgv_productos";
            dgv_productos.ReadOnly = true;
            dgv_productos.RowHeadersWidth = 51;
            dgv_productos.Size = new Size(1003, 401);
            dgv_productos.TabIndex = 5;
            dgv_productos.CellContentClick += dgv_productos_CellContentClick;
            dgv_productos.CellMouseClick += dgv_productos_CellMouseClick;
            // 
            // txt_filtrar
            // 
            txt_filtrar.BackColor = SystemColors.GradientInactiveCaption;
            txt_filtrar.Location = new Point(150, 121);
            txt_filtrar.Multiline = true;
            txt_filtrar.Name = "txt_filtrar";
            txt_filtrar.Size = new Size(765, 55);
            txt_filtrar.TabIndex = 6;
            txt_filtrar.TextChanged += txt_filtrar_TextChanged;
            // 
            // btn_eliminar
            // 
            btn_eliminar.BackColor = Color.Transparent;
            btn_eliminar.Location = new Point(660, 667);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(157, 62);
            btn_eliminar.TabIndex = 7;
            btn_eliminar.TabStop = false;
            btn_eliminar.Click += btn_eliminar_Click;
            // 
            // btn_modificar
            // 
            btn_modificar.BackColor = Color.Transparent;
            btn_modificar.Location = new Point(475, 667);
            btn_modificar.Name = "btn_modificar";
            btn_modificar.Size = new Size(157, 62);
            btn_modificar.TabIndex = 8;
            btn_modificar.TabStop = false;
            btn_modificar.Click += btn_modificar_Click;
            // 
            // btn_nuevo
            // 
            btn_nuevo.BackColor = Color.Transparent;
            btn_nuevo.Location = new Point(291, 667);
            btn_nuevo.Name = "btn_nuevo";
            btn_nuevo.Size = new Size(157, 62);
            btn_nuevo.TabIndex = 9;
            btn_nuevo.TabStop = false;
            btn_nuevo.Click += btn_nuevo_Click;
            // 
            // Frm_Producto_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 763);
            Controls.Add(btn_nuevo);
            Controls.Add(btn_modificar);
            Controls.Add(btn_eliminar);
            Controls.Add(txt_filtrar);
            Controls.Add(dgv_productos);
            Name = "Frm_Producto_Search";
            Text = "Frm_Producto_Search";
            Controls.SetChildIndex(btn_salir, 0);
            Controls.SetChildIndex(btn_exit, 0);
            Controls.SetChildIndex(btn_maximizar, 0);
            Controls.SetChildIndex(btn_minimizar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(dgv_productos, 0);
            Controls.SetChildIndex(txt_filtrar, 0);
            Controls.SetChildIndex(btn_eliminar, 0);
            Controls.SetChildIndex(btn_modificar, 0);
            Controls.SetChildIndex(btn_nuevo, 0);
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_productos).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_eliminar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_modificar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_nuevo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_productos;
        private TextBox txt_filtrar;
        private PictureBox btn_eliminar;
        private PictureBox btn_modificar;
        private PictureBox btn_nuevo;
    }
}