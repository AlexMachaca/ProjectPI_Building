namespace ProjectPI_Building.Forms_Search
{
    partial class Frm_Proveedor_Search
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
            btn_nuevo = new PictureBox();
            btn_modificar = new PictureBox();
            btn_eliminar = new PictureBox();
            txt_filtrar = new TextBox();
            dgv_proveedores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_nuevo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_modificar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_eliminar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_proveedores).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(265, 21);
            label1.Size = new Size(380, 34);
            label1.Text = "Busqueda ed Proveedores";
            // 
            // btn_nuevo
            // 
            btn_nuevo.BackColor = Color.Transparent;
            btn_nuevo.Location = new Point(290, 667);
            btn_nuevo.Name = "btn_nuevo";
            btn_nuevo.Size = new Size(157, 62);
            btn_nuevo.TabIndex = 14;
            btn_nuevo.TabStop = false;
            btn_nuevo.Click += btn_nuevo_Click;
            // 
            // btn_modificar
            // 
            btn_modificar.BackColor = Color.Transparent;
            btn_modificar.Location = new Point(474, 667);
            btn_modificar.Name = "btn_modificar";
            btn_modificar.Size = new Size(157, 62);
            btn_modificar.TabIndex = 13;
            btn_modificar.TabStop = false;
            btn_modificar.Click += btn_modificar_Click;
            // 
            // btn_eliminar
            // 
            btn_eliminar.BackColor = Color.Transparent;
            btn_eliminar.Location = new Point(659, 667);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(157, 62);
            btn_eliminar.TabIndex = 12;
            btn_eliminar.TabStop = false;
            btn_eliminar.Click += btn_eliminar_Click;
            // 
            // txt_filtrar
            // 
            txt_filtrar.BackColor = SystemColors.GradientInactiveCaption;
            txt_filtrar.Location = new Point(149, 121);
            txt_filtrar.Multiline = true;
            txt_filtrar.Name = "txt_filtrar";
            txt_filtrar.Size = new Size(765, 55);
            txt_filtrar.TabIndex = 11;
            txt_filtrar.TextChanged += txt_filtrar_TextChanged;
            // 
            // dgv_proveedores
            // 
            dgv_proveedores.AllowUserToAddRows = false;
            dgv_proveedores.AllowUserToDeleteRows = false;
            dgv_proveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_proveedores.Location = new Point(11, 201);
            dgv_proveedores.Name = "dgv_proveedores";
            dgv_proveedores.ReadOnly = true;
            dgv_proveedores.RowHeadersWidth = 51;
            dgv_proveedores.Size = new Size(1003, 401);
            dgv_proveedores.TabIndex = 10;
            dgv_proveedores.CellMouseClick += dgv_proveedores_CellMouseClick;
            // 
            // Frm_Proveedor_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 763);
            Controls.Add(btn_nuevo);
            Controls.Add(btn_modificar);
            Controls.Add(btn_eliminar);
            Controls.Add(txt_filtrar);
            Controls.Add(dgv_proveedores);
            Name = "Frm_Proveedor_Search";
            Text = "Frm_Proveedor_Search";
            Controls.SetChildIndex(btn_salir, 0);
            Controls.SetChildIndex(btn_exit, 0);
            Controls.SetChildIndex(btn_maximizar, 0);
            Controls.SetChildIndex(btn_minimizar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(dgv_proveedores, 0);
            Controls.SetChildIndex(txt_filtrar, 0);
            Controls.SetChildIndex(btn_eliminar, 0);
            Controls.SetChildIndex(btn_modificar, 0);
            Controls.SetChildIndex(btn_nuevo, 0);
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_nuevo).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_modificar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_eliminar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_proveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btn_nuevo;
        private PictureBox btn_modificar;
        private PictureBox btn_eliminar;
        private TextBox txt_filtrar;
        private DataGridView dgv_proveedores;
    }
}