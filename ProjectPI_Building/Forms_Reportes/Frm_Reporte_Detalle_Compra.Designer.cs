namespace ProjectPI_Building.Forms_Reportes
{
    partial class Frm_Reporte_Detalle_Compra
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
            dgv_detalle_compra = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_detalle_compra).BeginInit();
            SuspendLayout();
            // 
            // dgv_detalle_compra
            // 
            dgv_detalle_compra.AllowUserToAddRows = false;
            dgv_detalle_compra.AllowUserToDeleteRows = false;
            dgv_detalle_compra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_detalle_compra.Location = new Point(22, 65);
            dgv_detalle_compra.Name = "dgv_detalle_compra";
            dgv_detalle_compra.ReadOnly = true;
            dgv_detalle_compra.RowHeadersWidth = 51;
            dgv_detalle_compra.Size = new Size(902, 272);
            dgv_detalle_compra.TabIndex = 0;
            // 
            // Frm_Reporte_Detalle_Compra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 450);
            Controls.Add(dgv_detalle_compra);
            Name = "Frm_Reporte_Detalle_Compra";
            Text = "Frm_Reporte_Detalle_Compra";
            Load += Frm_Reporte_Detalle_Compra_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_detalle_compra).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_detalle_compra;
    }
}