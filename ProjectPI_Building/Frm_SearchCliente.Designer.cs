namespace ProjectPI_Building
{
    partial class Frm_SearchCliente
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
            label2 = new Label();
            cbIdPersona = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtIdCliente = new TextBox();
            txtCorreo = new TextBox();
            dgv_cliente = new DataGridView();
            btnUpdate = new Button();
            btnNuevaPersona = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_cliente).BeginInit();
            SuspendLayout();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(12, 209);
            label2.Name = "label2";
            label2.Size = new Size(167, 23);
            label2.TabIndex = 11;
            label2.Text = "REGISTRAR CLIENTE";
            // 
            // cbIdPersona
            // 
            cbIdPersona.FormattingEnabled = true;
            cbIdPersona.Location = new Point(12, 343);
            cbIdPersona.Name = "cbIdPersona";
            cbIdPersona.Size = new Size(216, 28);
            cbIdPersona.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(12, 317);
            label3.Name = "label3";
            label3.Size = new Size(181, 23);
            label3.TabIndex = 13;
            label3.Text = "Nombre de la persona";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(12, 245);
            label4.Name = "label4";
            label4.Size = new Size(27, 23);
            label4.TabIndex = 14;
            label4.Text = "ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.Location = new Point(12, 392);
            label5.Name = "label5";
            label5.Size = new Size(62, 23);
            label5.TabIndex = 15;
            label5.Text = "Correo";
            // 
            // txtIdCliente
            // 
            txtIdCliente.Location = new Point(12, 271);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.ReadOnly = true;
            txtIdCliente.Size = new Size(216, 27);
            txtIdCliente.TabIndex = 16;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(12, 418);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(216, 27);
            txtCorreo.TabIndex = 17;
            // 
            // dgv_cliente
            // 
            dgv_cliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_cliente.Location = new Point(295, 245);
            dgv_cliente.Name = "dgv_cliente";
            dgv_cliente.RowHeadersWidth = 51;
            dgv_cliente.Size = new Size(421, 289);
            dgv_cliente.TabIndex = 18;
            dgv_cliente.CellMouseClick += dgv_cliente_CellMouseClick;
            dgv_cliente.CellMouseDoubleClick += dgv_cliente_CellMouseDoubleClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(12, 470);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(216, 29);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Guardar cambios";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnNuevaPersona
            // 
            btnNuevaPersona.Location = new Point(12, 617);
            btnNuevaPersona.Name = "btnNuevaPersona";
            btnNuevaPersona.Size = new Size(128, 29);
            btnNuevaPersona.TabIndex = 20;
            btnNuevaPersona.Text = "Nueva persona";
            btnNuevaPersona.UseVisualStyleBackColor = true;
            btnNuevaPersona.Click += btnNuevaPersona_Click;
            // 
            // Frm_SearchCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 673);
            Controls.Add(btnNuevaPersona);
            Controls.Add(btnUpdate);
            Controls.Add(dgv_cliente);
            Controls.Add(txtCorreo);
            Controls.Add(txtIdCliente);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbIdPersona);
            Controls.Add(label2);
            Name = "Frm_SearchCliente";
            Text = "Frm_SearchCliente";
            Controls.SetChildIndex(btnNuevo, 0);
            Controls.SetChildIndex(btnActualizar, 0);
            Controls.SetChildIndex(btnEliminar, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(cbIdPersona, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtIdCliente, 0);
            Controls.SetChildIndex(txtCorreo, 0);
            Controls.SetChildIndex(dgv_cliente, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnNuevaPersona, 0);
            ((System.ComponentModel.ISupportInitialize)dgv_cliente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ComboBox cbIdPersona;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtIdCliente;
        private TextBox txtCorreo;
        private DataGridView dgv_cliente;
        private Button btnUpdate;
        private Button btnNuevaPersona;
    }
}