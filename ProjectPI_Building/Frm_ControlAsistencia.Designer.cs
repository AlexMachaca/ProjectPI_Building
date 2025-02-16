namespace ProjectPI_Building
{
    partial class Frm_ControlAsistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ControlAsistencia));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.txtTDocumento = new System.Windows.Forms.TextBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            this.lblEstadoAsistencia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(831, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 38);
            this.btnClose.TabIndex = 24;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(735, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(28, 38);
            this.btnMinimizar.TabIndex = 25;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(148, 167);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(339, 28);
            this.cmbEmpleado.TabIndex = 26;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // btnEntrada
            // 
            this.btnEntrada.BackColor = System.Drawing.Color.Transparent;
            this.btnEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEntrada.FlatAppearance.BorderSize = 0;
            this.btnEntrada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEntrada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.Location = new System.Drawing.Point(172, 312);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(231, 55);
            this.btnEntrada.TabIndex = 27;
            this.btnEntrada.UseVisualStyleBackColor = false;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.BackColor = System.Drawing.Color.Transparent;
            this.btnSalida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSalida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.Location = new System.Drawing.Point(475, 312);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(231, 55);
            this.btnSalida.TabIndex = 28;
            this.btnSalida.UseVisualStyleBackColor = false;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(647, 167);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(178, 27);
            this.dtpFecha.TabIndex = 29;
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(647, 209);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(178, 27);
            this.dtpHora.TabIndex = 30;
            this.dtpHora.ValueChanged += new System.EventHandler(this.dtpHora_ValueChanged);
            // 
            // txtTDocumento
            // 
            this.txtTDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDocumento.Location = new System.Drawing.Point(185, 209);
            this.txtTDocumento.Name = "txtTDocumento";
            this.txtTDocumento.Size = new System.Drawing.Size(125, 27);
            this.txtTDocumento.TabIndex = 31;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroDoc.Location = new System.Drawing.Point(362, 209);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(125, 27);
            this.txtNroDoc.TabIndex = 32;
            // 
            // dgvAsistencias
            // 
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencias.Location = new System.Drawing.Point(157, 490);
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.RowHeadersWidth = 51;
            this.dgvAsistencias.RowTemplate.Height = 29;
            this.dgvAsistencias.Size = new System.Drawing.Size(549, 240);
            this.dgvAsistencias.TabIndex = 33;
            // 
            // lblEstadoAsistencia
            // 
            this.lblEstadoAsistencia.AutoSize = true;
            this.lblEstadoAsistencia.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoAsistencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEstadoAsistencia.Location = new System.Drawing.Point(299, 409);
            this.lblEstadoAsistencia.Name = "lblEstadoAsistencia";
            this.lblEstadoAsistencia.Size = new System.Drawing.Size(40, 28);
            this.lblEstadoAsistencia.TabIndex = 34;
            this.lblEstadoAsistencia.Text = "👻";
            // 
            // Frm_ControlAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(878, 769);
            this.Controls.Add(this.lblEstadoAsistencia);
            this.Controls.Add(this.dgvAsistencias);
            this.Controls.Add(this.txtNroDoc);
            this.Controls.Add(this.txtTDocumento);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.btnEntrada);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_ControlAsistencia";
            this.Text = "Frm_ControlAsistencia";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_ControlAsistencia_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Frm_ControlAsistencia_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Frm_ControlAsistencia_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Button btnClose;
        public Button btnMinimizar;
        private ComboBox cmbEmpleado;
        public Button btnEntrada;
        public Button btnSalida;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHora;
        private TextBox txtTDocumento;
        private TextBox txtNroDoc;
        private DataGridView dgvAsistencias;
        private Label lblEstadoAsistencia;
    }
}