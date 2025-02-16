namespace ProjectPI_Building
{
    partial class Frm_Administracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Administracion));
            btn_persona = new PictureBox();
            btn_personal = new PictureBox();
            btn_cliente = new PictureBox();
            btn_empresa = new PictureBox();
            btn_producto = new PictureBox();
            btn_sucursal = new PictureBox();
            btn_proveedor = new PictureBox();
            btn_minimizar = new PictureBox();
            btn_maximizar = new PictureBox();
            btn_salir = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_persona).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_personal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_cliente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_empresa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_producto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_sucursal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_proveedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_salir).BeginInit();
            SuspendLayout();
            // 
            // btn_persona
            // 
            btn_persona.BackColor = Color.Transparent;
            btn_persona.Location = new Point(87, 109);
            btn_persona.Name = "btn_persona";
            btn_persona.Size = new Size(178, 169);
            btn_persona.TabIndex = 0;
            btn_persona.TabStop = false;
            btn_persona.Click += btn_persona_Click;
            // 
            // btn_personal
            // 
            btn_personal.BackColor = Color.Transparent;
            btn_personal.Location = new Point(87, 284);
            btn_personal.Name = "btn_personal";
            btn_personal.Size = new Size(178, 169);
            btn_personal.TabIndex = 1;
            btn_personal.TabStop = false;
            btn_personal.Click += btn_personal_Click;
            // 
            // btn_cliente
            // 
            btn_cliente.BackColor = Color.Transparent;
            btn_cliente.Location = new Point(87, 459);
            btn_cliente.Name = "btn_cliente";
            btn_cliente.Size = new Size(178, 169);
            btn_cliente.TabIndex = 2;
            btn_cliente.TabStop = false;
            btn_cliente.Click += btn_cliente_Click;
            // 
            // btn_empresa
            // 
            btn_empresa.BackColor = Color.Transparent;
            btn_empresa.Location = new Point(343, 284);
            btn_empresa.Name = "btn_empresa";
            btn_empresa.Size = new Size(178, 169);
            btn_empresa.TabIndex = 3;
            btn_empresa.TabStop = false;
            btn_empresa.Click += btn_empresa_Click;
            // 
            // btn_producto
            // 
            btn_producto.BackColor = Color.Transparent;
            btn_producto.Location = new Point(343, 109);
            btn_producto.Name = "btn_producto";
            btn_producto.Size = new Size(178, 169);
            btn_producto.TabIndex = 4;
            btn_producto.TabStop = false;
            btn_producto.Click += btn_producto_Click;
            // 
            // btn_sucursal
            // 
            btn_sucursal.BackColor = Color.Transparent;
            btn_sucursal.Location = new Point(343, 459);
            btn_sucursal.Name = "btn_sucursal";
            btn_sucursal.Size = new Size(178, 169);
            btn_sucursal.TabIndex = 5;
            btn_sucursal.TabStop = false;
            btn_sucursal.Click += btn_sucursal_Click;
            // 
            // btn_proveedor
            // 
            btn_proveedor.BackColor = Color.Transparent;
            btn_proveedor.Location = new Point(596, 109);
            btn_proveedor.Name = "btn_proveedor";
            btn_proveedor.Size = new Size(178, 169);
            btn_proveedor.TabIndex = 6;
            btn_proveedor.TabStop = false;
            btn_proveedor.Click += btn_proveedor_Click;
            // 
            // btn_minimizar
            // 
            btn_minimizar.BackColor = Color.Transparent;
            btn_minimizar.Location = new Point(1030, 14);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(46, 49);
            btn_minimizar.TabIndex = 7;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.BackColor = Color.Transparent;
            btn_maximizar.Location = new Point(1087, 12);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(46, 49);
            btn_maximizar.TabIndex = 8;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Transparent;
            btn_salir.Location = new Point(1144, 14);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(46, 49);
            btn_salir.TabIndex = 9;
            btn_salir.TabStop = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // Frm_Administracion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1202, 670);
            Controls.Add(btn_salir);
            Controls.Add(btn_maximizar);
            Controls.Add(btn_minimizar);
            Controls.Add(btn_proveedor);
            Controls.Add(btn_sucursal);
            Controls.Add(btn_producto);
            Controls.Add(btn_empresa);
            Controls.Add(btn_cliente);
            Controls.Add(btn_personal);
            Controls.Add(btn_persona);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Administracion";
            Text = "Frm_Administracion";
            MouseDown += Frm_Administracion_MouseDown;
            MouseMove += Frm_Administracion_MouseMove;
            MouseUp += Frm_Administracion_MouseUp;
            ((System.ComponentModel.ISupportInitialize)btn_persona).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_personal).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_cliente).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_empresa).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_producto).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_sucursal).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_proveedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_salir).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox btn_persona;
        private PictureBox btn_personal;
        private PictureBox btn_cliente;
        private PictureBox btn_empresa;
        private PictureBox btn_producto;
        private PictureBox btn_sucursal;
        private PictureBox btn_proveedor;
        private PictureBox btn_minimizar;
        private PictureBox btn_maximizar;
        private PictureBox btn_salir;
    }
}