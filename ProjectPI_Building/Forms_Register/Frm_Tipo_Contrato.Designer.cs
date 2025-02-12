namespace ProjectPI_Building.Forms_Register
{
    partial class Frm_Tipo_Contrato
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
            dgv_tipo_contrato = new DataGridView();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            txt_sueldo = new TextBox();
            txt_categoria = new TextBox();
            btn_insertar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_tipo_contrato).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_insertar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(118, 30);
            label1.Size = new Size(419, 34);
            label1.Text = "Registro de Tipo de Contrato";
            // 
            // dgv_tipo_contrato
            // 
            dgv_tipo_contrato.AllowUserToAddRows = false;
            dgv_tipo_contrato.AllowUserToDeleteRows = false;
            dgv_tipo_contrato.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_tipo_contrato.Location = new Point(527, 141);
            dgv_tipo_contrato.Name = "dgv_tipo_contrato";
            dgv_tipo_contrato.ReadOnly = true;
            dgv_tipo_contrato.RowHeadersWidth = 51;
            dgv_tipo_contrato.Size = new Size(476, 237);
            dgv_tipo_contrato.TabIndex = 0;
            dgv_tipo_contrato.CellDoubleClick += dgv_tipo_contrato_CellDoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Gainsboro;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_sueldo);
            groupBox1.Controls.Add(txt_categoria);
            groupBox1.Location = new Point(138, 141);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(341, 233);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Tipo de Contrato";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 119);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 4;
            label3.Text = "Sueldo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 34);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 3;
            label2.Text = "Categoria";
            // 
            // txt_sueldo
            // 
            txt_sueldo.Location = new Point(28, 152);
            txt_sueldo.Name = "txt_sueldo";
            txt_sueldo.Size = new Size(238, 27);
            txt_sueldo.TabIndex = 2;
            // 
            // txt_categoria
            // 
            txt_categoria.Location = new Point(28, 67);
            txt_categoria.Name = "txt_categoria";
            txt_categoria.Size = new Size(238, 27);
            txt_categoria.TabIndex = 0;
            // 
            // btn_insertar
            // 
            btn_insertar.BackColor = Color.Transparent;
            btn_insertar.Location = new Point(903, 598);
            btn_insertar.Name = "btn_insertar";
            btn_insertar.Size = new Size(137, 60);
            btn_insertar.TabIndex = 2;
            btn_insertar.TabStop = false;
            btn_insertar.Click += btn_insertar_Click;
            // 
            // Frm_Tipo_Contrato
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1204, 674);
            Controls.Add(btn_insertar);
            Controls.Add(groupBox1);
            Controls.Add(dgv_tipo_contrato);
            Name = "Frm_Tipo_Contrato";
            Text = "Frm_Tipo_Contrato";
            Load += Frm_Tipo_Contrato_Load;
            Controls.SetChildIndex(dgv_tipo_contrato, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(btn_insertar, 0);
            Controls.SetChildIndex(btn_salir, 0);
            Controls.SetChildIndex(btn_exit, 0);
            Controls.SetChildIndex(btn_maximizar, 0);
            Controls.SetChildIndex(btn_minimizar, 0);
            Controls.SetChildIndex(label1, 0);
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_tipo_contrato).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btn_insertar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_tipo_contrato;
        private GroupBox groupBox1;
        private TextBox txt_sueldo;
        private TextBox txt_categoria;
        private PictureBox btn_insertar;
        private Label label3;
        private Label label2;
    }
}