namespace ProjectPI_Building
{
    partial class Frm_SearchPersona
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
            this.dgv_persona = new System.Windows.Forms.DataGridView();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_persona)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            ////this.label1.Location = new System.Drawing.Point(252, 31);
            //this.label1.Size = new System.Drawing.Size(297, 38);
            //this.label1.Text = "Busqueda de persona";
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgv_persona
            // 
            this.dgv_persona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_persona.Location = new System.Drawing.Point(40, 224);
            this.dgv_persona.Name = "dgv_persona";
            this.dgv_persona.RowHeadersWidth = 51;
            this.dgv_persona.RowTemplate.Height = 29;
            this.dgv_persona.Size = new System.Drawing.Size(710, 298);
            this.dgv_persona.TabIndex = 9;
            this.dgv_persona.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_persona_CellClick);
            // 
            // txtSearchName
            // 
            this.txtSearchName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSearchName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchName.ForeColor = System.Drawing.Color.Black;
            this.txtSearchName.Location = new System.Drawing.Point(119, 129);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(597, 27);
            this.txtSearchName.TabIndex = 11;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // Frm_SearchPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 668);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.dgv_persona);
            this.Name = "Frm_SearchPersona";
            this.Text = "Frm_SearchPersona";
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            //this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.dgv_persona, 0);
            this.Controls.SetChildIndex(this.txtSearchName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_persona)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgv_persona;
        private TextBox txtSearchName;
    }
}