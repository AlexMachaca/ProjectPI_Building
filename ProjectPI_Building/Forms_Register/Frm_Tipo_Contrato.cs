using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Register
{
    public partial class Frm_Tipo_Contrato : Frm_Template_Register
    {
        public int IdTipoContratoSeleccionado { get; set; }
        public string InfoTipoContratoSeleccionado { get; set; }
        public Frm_Tipo_Contrato()
        {
            InitializeComponent();
        }

        //llenar datagridview
        private void fill_data()
        {
            try
            {
                Connection_Contrato connection = new Connection_Contrato();
                DataTable dataTable = connection.ListarTiposContrato();
                dgv_tipo_contrato.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }
        //funcion para limpiar los campos
        private void clear_fields()
        {
            txt_categoria.Text = "";
            txt_sueldo.Text = "";
        }


        private void Frm_Tipo_Contrato_Load(object sender, EventArgs e)
        {
            fill_data();
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            Connection_Contrato connection = new Connection_Contrato();
            int id = connection.count_tipo_contrato();
            //validar sii no son nulos
            if (id < 0 || txt_categoria.Text == "" || txt_sueldo.Text == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
                return;
            }
            try
            {
                string categoria = txt_categoria.Text;
                decimal sueldo = Convert.ToDecimal(txt_sueldo.Text);
                bool result = connection.InsertarTipoContrato(id, categoria, sueldo);
                if (result)
                {
                    MessageBox.Show("Tipo de Contrato insertado correctamente");
                    fill_data();
                    clear_fields();
                }
                else
                {
                    MessageBox.Show("Error al insertar Tipo de Contrato");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar Tipo de Contrato: " + ex.Message);
            }
        }

        private void dgv_tipo_contrato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener el ID y la información del tipo de contrato seleccionado
                IdTipoContratoSeleccionado = Convert.ToInt32(dgv_tipo_contrato.Rows[e.RowIndex].Cells["idTipocontrato"].Value); // Reemplaza "idTipocontrato" si el nombre de la columna es diferente
                InfoTipoContratoSeleccionado = dgv_tipo_contrato.Rows[e.RowIndex].Cells["categoria"].Value.ToString() + " - S/" + dgv_tipo_contrato.Rows[e.RowIndex].Cells["Sueldo"].Value.ToString(); // Reemplaza "categoria" y "Sueldo" si los nombres de las columnas son diferentes

                // Cerrar el formulario
                this.DialogResult = DialogResult.OK; // Indica que el usuario seleccionó un registro
                this.Close();
            }
        }


    }
}
