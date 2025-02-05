namespace ProjectPI_Building.Forms_Register
{
    partial class Frm_Proveedor_Register
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
            btn_guardar = new PictureBox();
            groupBox1 = new GroupBox();
            cb_tipo_doc = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            txt_correo = new TextBox();
            txt_celular = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txt_direcion = new TextBox();
            txt_nombre = new TextBox();
            txt_nro_doc = new TextBox();
            txt_id = new TextBox();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_guardar).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(278, 13);
            label1.Size = new Size(328, 34);
            label1.Text = "Registro de Proveedor";
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(839, 675);
            // 
            // btn_guardar
            // 
            btn_guardar.BackColor = Color.Transparent;
            btn_guardar.Location = new Point(648, 675);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(156, 62);
            btn_guardar.TabIndex = 8;
            btn_guardar.TabStop = false;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.PaleGreen;
            groupBox1.Controls.Add(cb_tipo_doc);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txt_correo);
            groupBox1.Controls.Add(txt_celular);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_direcion);
            groupBox1.Controls.Add(txt_nombre);
            groupBox1.Controls.Add(txt_nro_doc);
            groupBox1.Controls.Add(txt_id);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(209, 175);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(570, 352);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Proveedor";
            // 
            // cb_tipo_doc
            // 
            cb_tipo_doc.FormattingEnabled = true;
            cb_tipo_doc.Items.AddRange(new object[] { "DNI", "RUC", "Pasaporte" });
            cb_tipo_doc.Location = new Point(142, 88);
            cb_tipo_doc.Name = "cb_tipo_doc";
            cb_tipo_doc.Size = new Size(388, 28);
            cb_tipo_doc.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 260);
            label7.Name = "label7";
            label7.Size = new Size(55, 20);
            label7.TabIndex = 13;
            label7.Text = "Correo";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(39, 227);
            label8.Name = "label8";
            label8.Size = new Size(59, 20);
            label8.TabIndex = 12;
            label8.Text = "Celular";
            // 
            // txt_correo
            // 
            txt_correo.Location = new Point(142, 253);
            txt_correo.Name = "txt_correo";
            txt_correo.Size = new Size(388, 28);
            txt_correo.TabIndex = 11;
            // 
            // txt_celular
            // 
            txt_celular.Location = new Point(142, 220);
            txt_celular.Name = "txt_celular";
            txt_celular.Size = new Size(388, 28);
            txt_celular.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 194);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 9;
            label6.Text = "Direccion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 161);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 8;
            label5.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 128);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 7;
            label4.Text = "Nro. Doc.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 95);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 6;
            label3.Text = "Tipo Doc.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 62);
            label2.Name = "label2";
            label2.Size = new Size(22, 20);
            label2.TabIndex = 5;
            label2.Text = "Id";
            // 
            // txt_direcion
            // 
            txt_direcion.Location = new Point(142, 187);
            txt_direcion.Name = "txt_direcion";
            txt_direcion.Size = new Size(388, 28);
            txt_direcion.TabIndex = 4;
            // 
            // txt_nombre
            // 
            txt_nombre.Location = new Point(142, 154);
            txt_nombre.Name = "txt_nombre";
            txt_nombre.Size = new Size(388, 28);
            txt_nombre.TabIndex = 3;
            // 
            // txt_nro_doc
            // 
            txt_nro_doc.Location = new Point(142, 121);
            txt_nro_doc.Name = "txt_nro_doc";
            txt_nro_doc.Size = new Size(388, 28);
            txt_nro_doc.TabIndex = 2;
            // 
            // txt_id
            // 
            txt_id.Location = new Point(142, 55);
            txt_id.Name = "txt_id";
            txt_id.ReadOnly = true;
            txt_id.Size = new Size(388, 28);
            txt_id.TabIndex = 0;
            // 
            // Frm_Proveedor_Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1026, 765);
            Controls.Add(btn_guardar);
            Controls.Add(groupBox1);
            Name = "Frm_Proveedor_Register";
            Text = "Frm_Proveedor_Register";
            Controls.SetChildIndex(btn_salir, 0);
            Controls.SetChildIndex(btn_exit, 0);
            Controls.SetChildIndex(btn_maximizar, 0);
            Controls.SetChildIndex(btn_minimizar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(btn_guardar, 0);
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_guardar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btn_guardar;
        private GroupBox groupBox1;
        private Label label7;
        private Label label8;
        private TextBox txt_correo;
        private TextBox txt_celular;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txt_direcion;
        private TextBox txt_nombre;
        private TextBox txt_nro_doc;
        private TextBox txt_id;
        private ComboBox cb_tipo_doc;
    }
}