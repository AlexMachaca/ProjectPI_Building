namespace ProjectPI_Building
{
    partial class Frm_Page_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Page_Admin));
            lb_userName = new Label();
            btn_compra_producto = new PictureBox();
            btn_contrato_personal = new PictureBox();
            btn_reporte_producto = new PictureBox();
            btn_reporte_compras = new PictureBox();
            btn_minimizar = new PictureBox();
            btn_maximizar = new PictureBox();
            btn_salir = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_compra_producto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_contrato_personal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_reporte_producto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_reporte_compras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            SuspendLayout();
            // 
            // lb_userName
            // 
            lb_userName.AutoSize = true;
            lb_userName.BackColor = Color.Transparent;
            lb_userName.Font = new Font("Script MT Bold", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lb_userName.ForeColor = Color.Transparent;
            lb_userName.Location = new Point(385, 31);
            lb_userName.Name = "lb_userName";
            lb_userName.Size = new Size(141, 57);
            lb_userName.TabIndex = 0;
            lb_userName.Text = "David";
            // 
            // btn_compra_producto
            // 
            btn_compra_producto.BackColor = Color.Transparent;
            btn_compra_producto.Location = new Point(52, 122);
            btn_compra_producto.Name = "btn_compra_producto";
            btn_compra_producto.Size = new Size(319, 231);
            btn_compra_producto.TabIndex = 1;
            btn_compra_producto.TabStop = false;
            btn_compra_producto.Click += btn_compra_producto_Click;
            // 
            // btn_contrato_personal
            // 
            btn_contrato_personal.BackColor = Color.Transparent;
            btn_contrato_personal.Location = new Point(489, 122);
            btn_contrato_personal.Name = "btn_contrato_personal";
            btn_contrato_personal.Size = new Size(319, 231);
            btn_contrato_personal.TabIndex = 2;
            btn_contrato_personal.TabStop = false;
            btn_contrato_personal.Click += btn_contrato_personal_Click;
            // 
            // btn_reporte_producto
            // 
            btn_reporte_producto.BackColor = Color.Transparent;
            btn_reporte_producto.Location = new Point(920, 499);
            btn_reporte_producto.Name = "btn_reporte_producto";
            btn_reporte_producto.Size = new Size(336, 109);
            btn_reporte_producto.TabIndex = 3;
            btn_reporte_producto.TabStop = false;
            btn_reporte_producto.Click += btn_reporte_producto_Click;
            // 
            // btn_reporte_compras
            // 
            btn_reporte_compras.BackColor = Color.Transparent;
            btn_reporte_compras.Location = new Point(920, 614);
            btn_reporte_compras.Name = "btn_reporte_compras";
            btn_reporte_compras.Size = new Size(336, 109);
            btn_reporte_compras.TabIndex = 4;
            btn_reporte_compras.TabStop = false;
            btn_reporte_compras.Click += btn_reporte_compras_Click;
            // 
            // btn_minimizar
            // 
            btn_minimizar.BackColor = Color.Transparent;
            btn_minimizar.Location = new Point(1101, 19);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(50, 55);
            btn_minimizar.TabIndex = 5;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.BackColor = Color.Transparent;
            btn_maximizar.Location = new Point(1162, 19);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(50, 55);
            btn_maximizar.TabIndex = 6;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Transparent;
            btn_salir.Location = new Point(1227, 19);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(50, 55);
            btn_salir.TabIndex = 7;
            btn_salir.TabStop = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // Frm_Page_Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1283, 800);
            Controls.Add(btn_salir);
            Controls.Add(btn_maximizar);
            Controls.Add(btn_minimizar);
            Controls.Add(btn_reporte_compras);
            Controls.Add(btn_reporte_producto);
            Controls.Add(btn_contrato_personal);
            Controls.Add(btn_compra_producto);
            Controls.Add(lb_userName);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Page_Admin";
            Text = "Frm_Page_Admin";
            Load += Frm_Page_Admin_Load;
            ((System.ComponentModel.ISupportInitialize)btn_compra_producto).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_contrato_personal).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_reporte_producto).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_reporte_compras).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_userName;
        private PictureBox btn_compra_producto;
        private PictureBox btn_contrato_personal;
        private PictureBox btn_reporte_producto;
        private PictureBox btn_reporte_compras;
        private PictureBox btn_minimizar;
        private PictureBox btn_maximizar;
        private PictureBox btn_salir;
    }
}