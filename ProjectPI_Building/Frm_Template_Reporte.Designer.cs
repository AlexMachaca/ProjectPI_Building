namespace ProjectPI_Building
{
    partial class Frm_Template_Reporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Template_Reporte));
            btn_salir = new PictureBox();
            btn_maximizar = new PictureBox();
            btn_minimizar = new PictureBox();
            btn_exit = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            SuspendLayout();
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Transparent;
            btn_salir.Location = new Point(1151, 18);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(43, 46);
            btn_salir.TabIndex = 0;
            btn_salir.TabStop = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.BackColor = Color.Transparent;
            btn_maximizar.Location = new Point(1090, 18);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(43, 46);
            btn_maximizar.TabIndex = 1;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_minimizar
            // 
            btn_minimizar.BackColor = Color.Transparent;
            btn_minimizar.Location = new Point(1033, 18);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(43, 46);
            btn_minimizar.TabIndex = 2;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.Transparent;
            btn_exit.Location = new Point(958, 554);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(198, 94);
            btn_exit.TabIndex = 3;
            btn_exit.TabStop = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // Frm_Template_Reporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1199, 668);
            Controls.Add(btn_exit);
            Controls.Add(btn_minimizar);
            Controls.Add(btn_maximizar);
            Controls.Add(btn_salir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Template_Reporte";
            Text = "Frm_Template_Reporte";
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox btn_salir;
        public PictureBox btn_maximizar;
        public PictureBox btn_minimizar;
        public PictureBox btn_exit;
    }
}