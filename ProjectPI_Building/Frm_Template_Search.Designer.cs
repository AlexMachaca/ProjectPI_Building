namespace ProjectPI_Building
{
    partial class Frm_Template_Search
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
            btn_salir.Location = new Point(847, 667);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(153, 67);
            btn_salir.TabIndex = 0;
            btn_salir.TabStop = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.Transparent;
            btn_exit.Location = new Point(977, 0);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(49, 55);
            btn_exit.TabIndex = 1;
            btn_exit.TabStop = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.BackColor = Color.Transparent;
            btn_maximizar.Location = new Point(927, 0);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(49, 55);
            btn_maximizar.TabIndex = 2;
            btn_maximizar.TabStop = false;
            // 
            // btn_minimizar
            // 
            btn_minimizar.BackColor = Color.Transparent;
            btn_minimizar.Location = new Point(872, 0);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(49, 55);
            btn_minimizar.TabIndex = 3;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightGreen;
            label1.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(389, 21);
            label1.Name = "label1";
            label1.Size = new Size(95, 34);
            label1.TabIndex = 4;
            label1.Text = "Texto";
            // 
            // Frm_Template_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Page1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1026, 762);
            Controls.Add(label1);
            Controls.Add(btn_minimizar);
            Controls.Add(btn_maximizar);
            Controls.Add(btn_exit);
            Controls.Add(btn_salir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Template_Search";
            Text = "Frm_Template_Search";
            MouseDown += Frm_Template_Search_MouseDown;
            MouseMove += Frm_Template_Search_MouseMove;
            MouseUp += Frm_Template_Search_MouseUp;
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public PictureBox btn_salir;
        public PictureBox btn_exit;
        public PictureBox btn_maximizar;
        public PictureBox btn_minimizar;
        public Label label1;
    }
}