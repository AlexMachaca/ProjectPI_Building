namespace ProjectPI_Building.Forms_Register
{
    partial class Frm_Login_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login_Admin));
            txt_usuario = new TextBox();
            txt_contrasenia = new TextBox();
            btn_login = new PictureBox();
            btn_togglePassword = new PictureBox();
            btn_regresar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_login).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_togglePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_regresar).BeginInit();
            SuspendLayout();
            // 
            // txt_usuario
            // 
            txt_usuario.Location = new Point(430, 250);
            txt_usuario.Multiline = true;
            txt_usuario.Name = "txt_usuario";
            txt_usuario.Size = new Size(293, 58);
            txt_usuario.TabIndex = 0;
            // 
            // txt_contrasenia
            // 
            txt_contrasenia.Location = new Point(430, 346);
            txt_contrasenia.Multiline = true;
            txt_contrasenia.Name = "txt_contrasenia";
            txt_contrasenia.Size = new Size(250, 56);
            txt_contrasenia.TabIndex = 1;
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.Transparent;
            btn_login.Location = new Point(430, 438);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(294, 52);
            btn_login.TabIndex = 2;
            btn_login.TabStop = false;
            btn_login.Click += btn_login_Click;
            // 
            // btn_togglePassword
            // 
            btn_togglePassword.BackColor = Color.Transparent;
            btn_togglePassword.Location = new Point(682, 346);
            btn_togglePassword.Name = "btn_togglePassword";
            btn_togglePassword.Size = new Size(41, 25);
            btn_togglePassword.TabIndex = 3;
            btn_togglePassword.TabStop = false;
            btn_togglePassword.Click += btn_togglePassword_Click;
            // 
            // btn_regresar
            // 
            btn_regresar.BackColor = Color.Transparent;
            btn_regresar.Location = new Point(429, 497);
            btn_regresar.Name = "btn_regresar";
            btn_regresar.Size = new Size(294, 52);
            btn_regresar.TabIndex = 4;
            btn_regresar.TabStop = false;
            btn_regresar.Click += btn_regresar_Click;
            // 
            // Frm_Login_Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1154, 666);
            Controls.Add(btn_regresar);
            Controls.Add(btn_togglePassword);
            Controls.Add(btn_login);
            Controls.Add(txt_contrasenia);
            Controls.Add(txt_usuario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Login_Admin";
            Text = "Frm_Login_Admni";
            ((System.ComponentModel.ISupportInitialize)btn_login).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_togglePassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_regresar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_usuario;
        private TextBox txt_contrasenia;
        private PictureBox btn_login;
        private PictureBox btn_togglePassword;
        private PictureBox btn_regresar;
    }
}