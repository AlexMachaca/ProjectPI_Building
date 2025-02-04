using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPI_Building.Clases;
using System.Xml.Linq;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Register
{
    public partial class Frm_Empresa_Register : Frm_Template_Register
    {
        public int option { get; set; }
        Conection_Empresa con = new Conection_Empresa();
        public Frm_Empresa_Register()
        {
            InitializeComponent();
        }

        public void filldata(CEmpresa empresa)
        {
            txt_ruc.Text = empresa.RUC;
            txt_nombre.Text = empresa.Nombre;
            txt_pagina_web.Text = empresa.PaginaWeb;
            txt_facebook.Text = empresa.Facebook;
            txt_youtube.Text = empresa.Youtube;

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            string ruc = txt_ruc.Text.Trim();
            string nombre = txt_nombre.Text.Trim();
            string pagina_web = txt_pagina_web.Text.Trim();
            string facebook = txt_facebook.Text.Trim();
            string youtube = txt_youtube.Text.Trim();
            // Validación general de campos
            if (string.IsNullOrWhiteSpace(ruc) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(pagina_web) ||
                string.IsNullOrWhiteSpace(facebook) ||
                string.IsNullOrWhiteSpace(youtube))

            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método
            }

            // Validaciones específicas
            if (!Validator.ValidarRUC(ruc))
            {
                MessageBox.Show("El RUC debe comenzar con 20, 10, 15, 16 o 17, seguido de 8 dígitos y un dígito verificador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ruc.Focus();
                return;
            }

            if (!Validator.ValidarURL(pagina_web))
            {
                MessageBox.Show("La Página Web no es válida. Debe tener un formato correcto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pagina_web.Focus();
                return;
            }

            CEmpresa empresa = new CEmpresa();

            empresa.RUC = ruc;
            empresa.Nombre = nombre;
            empresa.PaginaWeb = pagina_web;
            empresa.Facebook = facebook;
            empresa.Youtube = youtube;

            if (option == 0)
            {
                if (con.insert_empresa(empresa) == 1)
                {
                    MessageBox.Show("Se agregó un nuevo registro.");
                    this.DialogResult = DialogResult.OK; // Establecer resultado del diálogo como OK
                    this.Close(); // Cerrar el formulario
                }
                else
                {
                    MessageBox.Show("Error en la inserción.");
                }
            }
            else if (option == 1)
            {
                if (con.update_empresa(empresa) == 1)
                {
                    MessageBox.Show("Se modificó un registro.");
                    this.DialogResult = DialogResult.OK; // Establecer resultado del diálogo como OK
                    this.Close(); // Cerrar el formulario
                }
                else
                {
                    MessageBox.Show("Error en la modificación.");
                }
            }
        }
    }
}
