namespace ProjectPI_Building
{
    partial class Frm_TemplateSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TemplateSearch));
            btnNuevo = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            btnExit = new Button();
            btnMinimizar = new Button();
            SuspendLayout();
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Transparent;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNuevo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Location = new Point(217, 617);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(122, 42);
            btnNuevo.TabIndex = 2;
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Transparent;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnActualizar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Location = new Point(357, 617);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(116, 38);
            btnActualizar.TabIndex = 8;
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Location = new Point(499, 617);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 38);
            btnEliminar.TabIndex = 9;
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(630, 615);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(122, 42);
            btnSalir.TabIndex = 10;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(765, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(32, 36);
            btnExit.TabIndex = 11;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.Transparent;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMinimizar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Location = new Point(692, 2);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(23, 36);
            btnMinimizar.TabIndex = 12;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // Frm_TemplateSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 671);
            ControlBox = false;
            Controls.Add(btnMinimizar);
            Controls.Add(btnExit);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnNuevo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_TemplateSearch";
            Text = "Frm_TemplateSearch";
            MouseDown += Frm_TemplateSearch_MouseDown;
            MouseMove += Frm_TemplateSearch_MouseMove;
            MouseUp += Frm_TemplateSearch_MouseUp;
            ResumeLayout(false);
        }

        #endregion

        public Button btnNuevo;
        public Button btnActualizar;
        public Button btnEliminar;
        private Button btnSalir;
        private Button btnExit;
        private Button btnMinimizar;
    }
}