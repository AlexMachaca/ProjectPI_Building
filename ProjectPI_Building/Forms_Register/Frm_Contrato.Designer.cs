namespace ProjectPI_Building.Forms_Register
{
    partial class Frm_Contrato
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
            groupBox1 = new GroupBox();
            cb_tipo_contrato = new ComboBox();
            dtp_fecha_termino = new DateTimePicker();
            dtp_fecha_ingreso = new DateTimePicker();
            cb_personal = new ComboBox();
            btn_guardar = new PictureBox();
            btn_registro_tipo_contrato = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_guardar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_registro_tipo_contrato).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_registro_tipo_contrato);
            groupBox1.Controls.Add(cb_tipo_contrato);
            groupBox1.Controls.Add(dtp_fecha_termino);
            groupBox1.Controls.Add(dtp_fecha_ingreso);
            groupBox1.Controls.Add(cb_personal);
            groupBox1.Location = new Point(55, 73);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(508, 303);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Contrato";
            // 
            // cb_tipo_contrato
            // 
            cb_tipo_contrato.FormattingEnabled = true;
            cb_tipo_contrato.Location = new Point(24, 231);
            cb_tipo_contrato.Name = "cb_tipo_contrato";
            cb_tipo_contrato.Size = new Size(363, 28);
            cb_tipo_contrato.TabIndex = 3;
            // 
            // dtp_fecha_termino
            // 
            dtp_fecha_termino.Location = new Point(24, 169);
            dtp_fecha_termino.Name = "dtp_fecha_termino";
            dtp_fecha_termino.Size = new Size(268, 27);
            dtp_fecha_termino.TabIndex = 2;
            // 
            // dtp_fecha_ingreso
            // 
            dtp_fecha_ingreso.Location = new Point(24, 112);
            dtp_fecha_ingreso.Name = "dtp_fecha_ingreso";
            dtp_fecha_ingreso.Size = new Size(268, 27);
            dtp_fecha_ingreso.TabIndex = 1;
            // 
            // cb_personal
            // 
            cb_personal.FormattingEnabled = true;
            cb_personal.Location = new Point(24, 54);
            cb_personal.Name = "cb_personal";
            cb_personal.Size = new Size(366, 28);
            cb_personal.TabIndex = 0;
            // 
            // btn_guardar
            // 
            btn_guardar.BackColor = SystemColors.ActiveCaption;
            btn_guardar.Location = new Point(650, 295);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(125, 62);
            btn_guardar.TabIndex = 1;
            btn_guardar.TabStop = false;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // btn_registro_tipo_contrato
            // 
            btn_registro_tipo_contrato.Location = new Point(406, 211);
            btn_registro_tipo_contrato.Name = "btn_registro_tipo_contrato";
            btn_registro_tipo_contrato.Size = new Size(81, 73);
            btn_registro_tipo_contrato.TabIndex = 4;
            btn_registro_tipo_contrato.TabStop = false;
            btn_registro_tipo_contrato.Click += btn_registro_tipo_contrato_Click;
            // 
            // Frm_Contrato
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_guardar);
            Controls.Add(groupBox1);
            Name = "Frm_Contrato";
            Text = "Frm_Contrato";
            Load += Frm_Contrato_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_guardar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_registro_tipo_contrato).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cb_tipo_contrato;
        private DateTimePicker dtp_fecha_termino;
        private DateTimePicker dtp_fecha_ingreso;
        private ComboBox cb_personal;
        private PictureBox btn_guardar;
        private PictureBox btn_registro_tipo_contrato;
    }
}