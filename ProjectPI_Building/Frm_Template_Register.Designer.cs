namespace ProjectPI_Building
{
    partial class Frm_Template_Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Template_Register));
            btn_salir = new PictureBox();
            btn_exit = new PictureBox();
            btn_maximizar = new PictureBox();
            btn_minimizar = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            SuspendLayout();
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Transparent;
            btn_salir.Location = new Point(835, 680);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(157, 62);
            btn_salir.TabIndex = 0;
            btn_salir.TabStop = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.Transparent;
            btn_exit.Location = new Point(977, -1);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(49, 48);
            btn_exit.TabIndex = 1;
            btn_exit.TabStop = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.BackColor = Color.Transparent;
            btn_maximizar.Location = new Point(922, -1);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(49, 48);
            btn_maximizar.TabIndex = 2;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_minimizar
            // 
            btn_minimizar.BackColor = Color.Transparent;
            btn_minimizar.Location = new Point(867, -1);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(49, 48);
            btn_minimizar.TabIndex = 3;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SpringGreen;
            label1.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(388, 16);
            label1.Name = "label1";
            label1.Size = new Size(95, 34);
            label1.TabIndex = 4;
            label1.Text = "Texto";
            // 
            // Frm_Template_Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1026, 754);
            Controls.Add(label1);
            Controls.Add(btn_minimizar);
            Controls.Add(btn_maximizar);
            Controls.Add(btn_exit);
            Controls.Add(btn_salir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Template_Register";
            Text = "Frm_Template_Register";
            MouseDown += Frm_Template_Register_MouseDown;
            MouseMove += Frm_Template_Register_MouseMove;
            MouseUp += Frm_Template_Register_MouseUp;
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label label1;
        public PictureBox btn_salir;
        public PictureBox btn_exit;
        public PictureBox btn_maximizar;
        public PictureBox btn_minimizar;
    }
}