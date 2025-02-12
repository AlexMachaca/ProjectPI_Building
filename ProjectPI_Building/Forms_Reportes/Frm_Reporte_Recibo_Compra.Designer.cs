namespace ProjectPI_Building.Forms_Reportes
{
    partial class Frm_Reporte_Recibo_Compra
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
            dtp_fecha_inicio = new DateTimePicker();
            dtp_fecha_fin = new DateTimePicker();
            dgv_recibo_compra = new DataGridView();
            cb_tipo_recibo = new ComboBox();
            label1 = new Label();
            btn_imprimir = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_recibo_compra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_imprimir).BeginInit();
            SuspendLayout();
            // 
            // dtp_fecha_inicio
            // 
            dtp_fecha_inicio.Location = new Point(142, 97);
            dtp_fecha_inicio.Name = "dtp_fecha_inicio";
            dtp_fecha_inicio.Size = new Size(283, 27);
            dtp_fecha_inicio.TabIndex = 0;
            dtp_fecha_inicio.ValueChanged += dtp_fecha_inicio_ValueChanged;
            // 
            // dtp_fecha_fin
            // 
            dtp_fecha_fin.Location = new Point(431, 97);
            dtp_fecha_fin.Name = "dtp_fecha_fin";
            dtp_fecha_fin.Size = new Size(283, 27);
            dtp_fecha_fin.TabIndex = 1;
            dtp_fecha_fin.ValueChanged += dtp_fecha_fin_ValueChanged;
            // 
            // dgv_recibo_compra
            // 
            dgv_recibo_compra.AllowUserToAddRows = false;
            dgv_recibo_compra.AllowUserToDeleteRows = false;
            dgv_recibo_compra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_recibo_compra.Location = new Point(142, 148);
            dgv_recibo_compra.Name = "dgv_recibo_compra";
            dgv_recibo_compra.ReadOnly = true;
            dgv_recibo_compra.RowHeadersWidth = 51;
            dgv_recibo_compra.Size = new Size(746, 413);
            dgv_recibo_compra.TabIndex = 2;
            dgv_recibo_compra.CellDoubleClick += dgv_recibo_compra_CellDoubleClick;
            // 
            // cb_tipo_recibo
            // 
            cb_tipo_recibo.FormattingEnabled = true;
            cb_tipo_recibo.Items.AddRange(new object[] { "Boleta", "Factura" });
            cb_tipo_recibo.Location = new Point(737, 96);
            cb_tipo_recibo.Name = "cb_tipo_recibo";
            cb_tipo_recibo.Size = new Size(151, 28);
            cb_tipo_recibo.TabIndex = 3;
            cb_tipo_recibo.SelectedIndexChanged += cb_tipo_recibo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(369, 32);
            label1.Name = "label1";
            label1.Size = new Size(345, 46);
            label1.TabIndex = 4;
            label1.Text = "Reporte de Compras";
            // 
            // btn_imprimir
            // 
            btn_imprimir.BackColor = Color.Transparent;
            btn_imprimir.Location = new Point(955, 459);
            btn_imprimir.Name = "btn_imprimir";
            btn_imprimir.Size = new Size(200, 80);
            btn_imprimir.TabIndex = 5;
            btn_imprimir.TabStop = false;
            btn_imprimir.Click += btn_imprimir_Click;
            // 
            // Frm_Reporte_Recibo_Compra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 668);
            Controls.Add(btn_imprimir);
            Controls.Add(label1);
            Controls.Add(cb_tipo_recibo);
            Controls.Add(dgv_recibo_compra);
            Controls.Add(dtp_fecha_fin);
            Controls.Add(dtp_fecha_inicio);
            Name = "Frm_Reporte_Recibo_Compra";
            Text = "Frm_Reporte_Recibo_Compra";
            Load += Frm_Reporte_Recibo_Compra_Load;
            Controls.SetChildIndex(btn_exit, 0);
            Controls.SetChildIndex(dtp_fecha_inicio, 0);
            Controls.SetChildIndex(dtp_fecha_fin, 0);
            Controls.SetChildIndex(dgv_recibo_compra, 0);
            Controls.SetChildIndex(cb_tipo_recibo, 0);
            Controls.SetChildIndex(btn_salir, 0);
            Controls.SetChildIndex(btn_maximizar, 0);
            Controls.SetChildIndex(btn_minimizar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btn_imprimir, 0);
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_recibo_compra).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_imprimir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtp_fecha_inicio;
        private DateTimePicker dtp_fecha_fin;
        private DataGridView dgv_recibo_compra;
        private ComboBox cb_tipo_recibo;
        private Label label1;
        private PictureBox btn_imprimir;
    }
}