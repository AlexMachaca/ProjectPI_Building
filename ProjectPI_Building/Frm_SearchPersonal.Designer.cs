namespace ProjectPI_Building
{
    partial class Frm_SearchPersonal
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
            dgv_personal = new DataGridView();
            label2 = new Label();
            txtIdPersonal = new TextBox();
            txtHorasTrabajo = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cbCategoria = new ComboBox();
            btnUpdate = new Button();
            cbPersona = new ComboBox();
            label7 = new Label();
            cb_turno = new ComboBox();
            label8 = new Label();
            txt_usuario = new TextBox();
            txt_contrasena = new TextBox();
            label9 = new Label();
            txt_confirmar_contra = new TextBox();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_personal).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(254, 44);
            label1.Size = new Size(304, 38);
            label1.Text = "Búsqueda de Personal";
            // 
            // btnNuevo
            // 
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNuevo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnActualizar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgv_personal
            // 
            dgv_personal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_personal.Location = new Point(49, 342);
            dgv_personal.Name = "dgv_personal";
            dgv_personal.RowHeadersWidth = 51;
            dgv_personal.Size = new Size(701, 207);
            dgv_personal.TabIndex = 9;
            dgv_personal.CellMouseClick += dgv_personal_CellMouseClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(262, 170);
            label2.Name = "label2";
            label2.Size = new Size(187, 23);
            label2.TabIndex = 10;
            label2.Text = "REGISTRAR PERSONAL";
            // 
            // txtIdPersonal
            // 
            txtIdPersonal.Location = new Point(49, 212);
            txtIdPersonal.Name = "txtIdPersonal";
            txtIdPersonal.ReadOnly = true;
            txtIdPersonal.Size = new Size(154, 27);
            txtIdPersonal.TabIndex = 11;
            // 
            // txtHorasTrabajo
            // 
            txtHorasTrabajo.Location = new Point(584, 212);
            txtHorasTrabajo.Name = "txtHorasTrabajo";
            txtHorasTrabajo.Size = new Size(160, 27);
            txtHorasTrabajo.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(49, 189);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 15;
            label3.Text = "ID Personal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(49, 243);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 16;
            label4.Text = "Categoria";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(209, 189);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 17;
            label5.Text = "Turno";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.Location = new Point(599, 189);
            label6.Name = "label6";
            label6.Size = new Size(126, 20);
            label6.TabIndex = 18;
            label6.Text = "Horas Trabajadas";
            // 
            // cbCategoria
            // 
            cbCategoria.DisplayMember = "Trabajdor Normal; Jefe;";
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Items.AddRange(new object[] { "Normal", "Jefe", "Secretaria", "Administrativo", "Vendedor" });
            cbCategoria.Location = new Point(49, 266);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(167, 28);
            cbCategoria.TabIndex = 19;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Cyan;
            btnUpdate.Location = new Point(570, 307);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(157, 29);
            btnUpdate.TabIndex = 21;
            btnUpdate.Text = "Guardar Cambios";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cbPersona
            // 
            cbPersona.DisplayMember = "Trabajdor Normal; Jefe;";
            cbPersona.FormattingEnabled = true;
            cbPersona.Items.AddRange(new object[] { "Normal", "Jefe", "Secretaria", "Administrativo" });
            cbPersona.Location = new Point(391, 212);
            cbPersona.Name = "cbPersona";
            cbPersona.Size = new Size(187, 28);
            cbPersona.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.Location = new Point(391, 189);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 23;
            label7.Text = "Persona";
            // 
            // cb_turno
            // 
            cb_turno.FormattingEnabled = true;
            cb_turno.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" });
            cb_turno.Location = new Point(209, 212);
            cb_turno.Name = "cb_turno";
            cb_turno.Size = new Size(170, 28);
            cb_turno.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label8.Location = new Point(229, 243);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 25;
            label8.Text = "Usuario";
            label8.Click += label8_Click;
            // 
            // txt_usuario
            // 
            txt_usuario.Location = new Point(229, 267);
            txt_usuario.Name = "txt_usuario";
            txt_usuario.Size = new Size(166, 27);
            txt_usuario.TabIndex = 26;
            // 
            // txt_contrasena
            // 
            txt_contrasena.Location = new Point(402, 267);
            txt_contrasena.Name = "txt_contrasena";
            txt_contrasena.Size = new Size(169, 27);
            txt_contrasena.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.Location = new Point(402, 243);
            label9.Name = "label9";
            label9.Size = new Size(86, 20);
            label9.TabIndex = 27;
            label9.Text = "Contraseña";
            // 
            // txt_confirmar_contra
            // 
            txt_confirmar_contra.Location = new Point(580, 267);
            txt_confirmar_contra.Name = "txt_confirmar_contra";
            txt_confirmar_contra.Size = new Size(169, 27);
            txt_confirmar_contra.TabIndex = 30;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label10.Location = new Point(580, 243);
            label10.Name = "label10";
            label10.Size = new Size(159, 20);
            label10.TabIndex = 29;
            label10.Text = "Confirmar Contraseña";
            // 
            // Frm_SearchPersonal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(798, 676);
            Controls.Add(txt_confirmar_contra);
            Controls.Add(label10);
            Controls.Add(txt_contrasena);
            Controls.Add(label9);
            Controls.Add(txt_usuario);
            Controls.Add(label8);
            Controls.Add(cb_turno);
            Controls.Add(label7);
            Controls.Add(cbPersona);
            Controls.Add(btnUpdate);
            Controls.Add(cbCategoria);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtHorasTrabajo);
            Controls.Add(txtIdPersonal);
            Controls.Add(label2);
            Controls.Add(dgv_personal);
            DoubleBuffered = true;
            Name = "Frm_SearchPersonal";
            Text = "Frm_SearchPersonal";
            Controls.SetChildIndex(dgv_personal, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(txtIdPersonal, 0);
            Controls.SetChildIndex(txtHorasTrabajo, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(cbCategoria, 0);
            Controls.SetChildIndex(btnNuevo, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btnActualizar, 0);
            Controls.SetChildIndex(btnEliminar, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(cbPersona, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(cb_turno, 0);
            Controls.SetChildIndex(label8, 0);
            Controls.SetChildIndex(txt_usuario, 0);
            Controls.SetChildIndex(label9, 0);
            Controls.SetChildIndex(txt_contrasena, 0);
            Controls.SetChildIndex(label10, 0);
            Controls.SetChildIndex(txt_confirmar_contra, 0);
            ((System.ComponentModel.ISupportInitialize)dgv_personal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_personal;
        private Label label2;
        private TextBox txtIdPersonal;
        private TextBox txtHorasTrabajo;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cbCategoria;
        private Button btnUpdate;
        private ComboBox cbPersona;
        private Label label7;
        private ComboBox cb_turno;
        private Label label8;
        private TextBox txt_usuario;
        private TextBox txt_contrasena;
        private Label label9;
        private TextBox txt_confirmar_contra;
        private Label label10;
    }
}