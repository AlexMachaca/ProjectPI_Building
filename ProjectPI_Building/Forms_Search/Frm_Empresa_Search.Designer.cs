namespace ProjectPI_Building.Forms_Search
{
    partial class Frm_Empresa_Search
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
            dgv_empresa = new DataGridView();
            btn_eliminar = new PictureBox();
            btn_modificar = new PictureBox();
            btn_nuevo = new PictureBox();
            txt_filtrar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_empresa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_eliminar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_modificar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_nuevo).BeginInit();
            SuspendLayout();
            // 
            // dgv_empresa
            // 
            dgv_empresa.AllowUserToAddRows = false;
            dgv_empresa.AllowUserToDeleteRows = false;
            dgv_empresa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_empresa.Location = new Point(12, 240);
            dgv_empresa.Name = "dgv_empresa";
            dgv_empresa.ReadOnly = true;
            dgv_empresa.RowHeadersWidth = 51;
            dgv_empresa.Size = new Size(1002, 350);
            dgv_empresa.TabIndex = 4;
            dgv_empresa.CellMouseClick += dgv_empresa_CellMouseClick;
            // 
            // btn_eliminar
            // 
            btn_eliminar.BackColor = Color.Transparent;
            btn_eliminar.Location = new Point(662, 667);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(154, 62);
            btn_eliminar.TabIndex = 5;
            btn_eliminar.TabStop = false;
            btn_eliminar.Click += btn_eliminar_Click;
            // 
            // btn_modificar
            // 
            btn_modificar.BackColor = Color.Transparent;
            btn_modificar.Location = new Point(474, 667);
            btn_modificar.Name = "btn_modificar";
            btn_modificar.Size = new Size(154, 62);
            btn_modificar.TabIndex = 6;
            btn_modificar.TabStop = false;
            btn_modificar.Click += btn_modificar_Click;
            // 
            // btn_nuevo
            // 
            btn_nuevo.BackColor = Color.Transparent;
            btn_nuevo.Location = new Point(291, 667);
            btn_nuevo.Name = "btn_nuevo";
            btn_nuevo.Size = new Size(154, 62);
            btn_nuevo.TabIndex = 7;
            btn_nuevo.TabStop = false;
            btn_nuevo.Click += btn_nuevo_Click;
            // 
            // txt_filtrar
            // 
            txt_filtrar.BackColor = SystemColors.InactiveBorder;
            txt_filtrar.Location = new Point(152, 122);
            txt_filtrar.Multiline = true;
            txt_filtrar.Name = "txt_filtrar";
            txt_filtrar.Size = new Size(762, 48);
            txt_filtrar.TabIndex = 8;
            txt_filtrar.TextChanged += txt_filtrar_TextChanged;
            // 
            // Frm_Empresa_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 761);
            Controls.Add(txt_filtrar);
            Controls.Add(btn_nuevo);
            Controls.Add(btn_modificar);
            Controls.Add(btn_eliminar);
            Controls.Add(dgv_empresa);
            Name = "Frm_Empresa_Search";
            Text = "Frm_Empresa_Search";
            Controls.SetChildIndex(btn_salir, 0);
            Controls.SetChildIndex(btn_exit, 0);
            Controls.SetChildIndex(btn_maximizar, 0);
            Controls.SetChildIndex(btn_minimizar, 0);
            Controls.SetChildIndex(dgv_empresa, 0);
            Controls.SetChildIndex(btn_eliminar, 0);
            Controls.SetChildIndex(btn_modificar, 0);
            Controls.SetChildIndex(btn_nuevo, 0);
            Controls.SetChildIndex(txt_filtrar, 0);
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_empresa).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_eliminar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_modificar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_nuevo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_empresa;
        private PictureBox btn_eliminar;
        private PictureBox btn_modificar;
        private PictureBox btn_nuevo;
        private TextBox txt_filtrar;
    }
}