namespace ProjectPI_Building
{
    partial class Frm_home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_home));
            btn_Compra = new PictureBox();
            btn_Venta = new PictureBox();
            btn_salir = new PictureBox();
            btn_maximizar = new PictureBox();
            btn_minimizar = new PictureBox();
            btn_contacto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_Compra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Venta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_contacto).BeginInit();
            SuspendLayout();
            // 
            // btn_Compra
            // 
            btn_Compra.BackColor = Color.Transparent;
            btn_Compra.Location = new Point(473, 12);
            btn_Compra.Name = "btn_Compra";
            btn_Compra.Size = new Size(135, 164);
            btn_Compra.TabIndex = 0;
            btn_Compra.TabStop = false;
            btn_Compra.Click += btn_Compra_Click;
            // 
            // btn_Venta
            // 
            btn_Venta.BackColor = Color.Transparent;
            btn_Venta.Location = new Point(643, 12);
            btn_Venta.Name = "btn_Venta";
            btn_Venta.Size = new Size(166, 164);
            btn_Venta.TabIndex = 1;
            btn_Venta.TabStop = false;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Transparent;
            btn_salir.Location = new Point(1136, 20);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(39, 42);
            btn_salir.TabIndex = 2;
            btn_salir.TabStop = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.BackColor = Color.Transparent;
            btn_maximizar.Location = new Point(1079, 20);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(39, 42);
            btn_maximizar.TabIndex = 3;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_minimizar
            // 
            btn_minimizar.BackColor = Color.Transparent;
            btn_minimizar.Location = new Point(1022, 20);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(39, 42);
            btn_minimizar.TabIndex = 4;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // btn_contacto
            // 
            btn_contacto.BackColor = Color.Transparent;
            btn_contacto.Location = new Point(841, 12);
            btn_contacto.Name = "btn_contacto";
            btn_contacto.Size = new Size(160, 164);
            btn_contacto.TabIndex = 5;
            btn_contacto.TabStop = false;
            // 
            // Frm_home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1185, 692);
            Controls.Add(btn_contacto);
            Controls.Add(btn_minimizar);
            Controls.Add(btn_maximizar);
            Controls.Add(btn_salir);
            Controls.Add(btn_Venta);
            Controls.Add(btn_Compra);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_home";
            Text = "Frm_home";
            MouseDown += Frm_home_MouseDown;
            MouseMove += Frm_home_MouseMove;
            MouseUp += Frm_home_MouseUp;
            ((System.ComponentModel.ISupportInitialize)btn_Compra).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Venta).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_contacto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox btn_Compra;
        private PictureBox btn_Venta;
        private PictureBox btn_salir;
        private PictureBox btn_maximizar;
        private PictureBox btn_minimizar;
        private PictureBox btn_contacto;
    }
}