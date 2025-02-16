using ProjectPI_Building;
using ProjectPI_Building.Clases;
using ProjectPI_Building.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPI_Building
{
    public partial class Frm_SearchCliente : Frm_TemplateSearch
    {
        public int fila = 0;
        ClienteService conection = new ClienteService();
        public Frm_SearchCliente()
        {
            InitializeComponent();
            LoadData();
            btnUpdate.Enabled = false;
            conection.fillComboBoxPersonas(cbIdPersona);
            generarIdCliente();
        }

        public void LoadData()
        {
            try
            {
                dgv_cliente.DataSource = null;

                DataSet ds = conection.fillCliente();
                if (ds != null && ds.Tables["Cliente"] != null)
                {
                    dgv_cliente.DataSource = ds.Tables["Cliente"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private void ClearInputs()
        {
            txtIdCliente.Clear();
            //cbIdPersona.Items.Clear();
            txtCorreo.Clear();
            cbIdPersona.SelectedIndex = 0;
        }

        private DataGridViewRow selectedRow;

        private void dgv_cliente_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgv_cliente.Rows[e.RowIndex];
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bool temp = verificarCampos();
            if (temp == false)
            {
                return;
            }
            CCliente cliente = new CCliente
            {
                Idcliente = txtIdCliente.Text,
                IdPersona = cbIdPersona.SelectedValue.ToString(), // Obtener el IDPERSONA seleccionado
                Correoelectronico = txtCorreo.Text
            };

            if (conection.insert_cliente(cliente) == 1)
            {
                MessageBox.Show("Cliente registrado correctamente.");
                ClearInputs();
                LoadData();
                generarIdCliente();
            }
            else
            {
                MessageBox.Show("Error al registrar el cliente.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                txtIdCliente.Text = selectedRow.Cells["idcliente"].Value.ToString();
                cbIdPersona.Text = selectedRow.Cells["IDPERSONA"].Value.ToString();
                txtCorreo.Text = selectedRow.Cells["correoelectronico"].Value.ToString();
                txtIdCliente.Enabled = false;
                cbIdPersona.Enabled = false;
                btnUpdate.Enabled = true;

            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila antes de presionar el botón Actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool temp = verificarCampos();
            if (temp == false)
            {
                return;
            }
            CCliente cliente = new CCliente
            {
                Idcliente = txtIdCliente.Text,
                IdPersona = cbIdPersona.SelectedValue.ToString(), // Obtener el IDPERSONA seleccionado
                Correoelectronico = txtCorreo.Text
            };

            if (conection.update_cliente(cliente) == 1)
            {
                MessageBox.Show("Cliente actualizado correctamente.");
                ClearInputs();
                LoadData();
                txtIdCliente.Enabled = true;
                cbIdPersona.Enabled = true;
                btnUpdate.Enabled = false;
                generarIdCliente();
            }
            else
            {
                MessageBox.Show("Error al actualizar el cliente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                DialogResult confirmResult = MessageBox.Show(
                    "¿Está seguro de que desea elimina? ",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        string idcliente = selectedRow.Cells["idCliente"].Value.ToString();
                        int eliminado = conection.delete_cliente(idcliente);

                        if (eliminado == 1)
                        {
                            MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgv_cliente.Rows.Remove(selectedRow);
                            selectedRow = null;
                            generarIdCliente();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el Cliente. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el Cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnNuevaPersona_Click(object sender, EventArgs e)
        {
            Frm_SearchPersona frm = new Frm_SearchPersona();
            frm.ShowDialog();
        }

        //Funcion para verificar los campos
        private bool verificarCampos()
        {
            if (txtIdCliente.Text == "" || cbIdPersona.Text == "" || txtCorreo.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //Usamos la funcion de validacion de correo
            if (!Validator.ValidarCorreo(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, ingrese un correo válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //funcion para obtener el siguiente id
        private void generarIdCliente()
        {
            int id = conection.nextIdCliente();
            txtIdCliente.Text = id.ToString();
        }

        private void dgv_cliente_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //obtener los datos de la fila seleccionada para que el formulario de venta, pueda obtener los datos
            /*if (e.RowIndex >= 0)
            {
                IdCliente = Convert.ToInt32(dgv_cliente.Rows[fila].Cells["idCliente"].Value);
                //responder ok
                this.DialogResult = DialogResult.OK;


            }*/
        }
    }
}
