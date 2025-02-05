using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPI_Building.Clases;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Register
{
    public partial class Frm_Proveedor_Register : Frm_Template_Register
    {
        public int option { get; set; }
        private Connection_Proveedor con = new Connection_Proveedor();
        public Frm_Proveedor_Register()
        {
            InitializeComponent();
            if (option == 0)
            {
                generateID();
            }
        }

        public void filldata(CProveedor proveedor)
        {
            txt_id.Text = proveedor.IdProveedor.ToString();
            cb_tipo_doc.SelectedItem = proveedor.TipoDocumento;
            txt_nro_doc.Text = proveedor.NroDocumento;
            txt_nombre.Text = proveedor.Nombre;
            txt_direcion.Text = proveedor.Direccion;
            txt_celular.Text = proveedor.Celular;
            txt_correo.Text = proveedor.CorreoElectronico;

        }

        public void generateID()
        {
            int count = con.count_proveedor();
            txt_id.Text = count.ToString();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string idproveedor = txt_id.Text.Trim();
            if (cb_tipo_doc.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de documento.");
                return;
            }
            string tipo_doc = cb_tipo_doc.SelectedItem.ToString();
            string nro_doc = txt_nro_doc.Text.Trim();
            if (tipo_doc == "DNI")
            {
                if (!Validator.ValidarDNI(nro_doc))
                {
                    MessageBox.Show("El DNI no es valido. Debe ser de 8 digitos.");
                    return;
                }
            }
            else if (tipo_doc == "RUC")
            {
                if (!Validator.ValidarRUC(nro_doc))
                {
                    MessageBox.Show("El RUC no es valido.Debe ser de 11 digitos.");
                    return;
                }
            }
            else if (tipo_doc == "Pasaporte")
            {
                if (!Validator.ValidarPasaporte(nro_doc))
                {
                    MessageBox.Show("El Pasaporte no es valido");
                    return;
                }
            }

            string nombre = txt_nombre.Text.Trim();
            string direccion = txt_direcion.Text.Trim();
            string celular = txt_celular.Text.Trim();
            string correo = txt_correo.Text.Trim();

            if (idproveedor == "" || tipo_doc == "" || nro_doc == "" || nombre == "" || direccion == "" || celular == "" || correo == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if (!Validator.ValidarCelular(celular))
            {
                MessageBox.Show("El celular no es valido");
                return;
            }
            if (!Validator.ValidarCorreo(correo))
            {
                MessageBox.Show("El correo no es valido");
                return;
            }

            CProveedor proveedor = new CProveedor();
            proveedor.IdProveedor = int.Parse(idproveedor);
            proveedor.TipoDocumento = cb_tipo_doc.SelectedItem.ToString();
            proveedor.NroDocumento = txt_nro_doc.Text;
            proveedor.Nombre = txt_nombre.Text;
            proveedor.Direccion = txt_direcion.Text;
            proveedor.Celular = txt_celular.Text;
            proveedor.CorreoElectronico = txt_correo.Text;

            if (option == 0)
            {
                //Conection con = new Conection();
                if (con.insert_proveedor(proveedor) == 1)
                {
                    MessageBox.Show("Se Agrego un nuevo provedor ");
                    this.DialogResult = DialogResult.OK; // Establecer resultado del diálogo como OK
                    this.Close(); // Cerrar el formulario
                }
                else
                {
                    MessageBox.Show("Error al insertar el proveedor ");
                }
            }
            else if (option == 1)
            {
                if (con.update_proveedor(proveedor) == 1)
                {
                    MessageBox.Show("Se modifico el proveedor");
                    this.DialogResult = DialogResult.OK; // Establecer resultado del diálogo como OK
                    this.Close(); // Cerrar el formulario
                }
                else
                {
                    MessageBox.Show("Error al modificar el provedor ");
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
