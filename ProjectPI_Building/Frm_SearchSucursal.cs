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
    public partial class Frm_SearchSucursal : Frmtemplate_Search
    {
        private SucursalService conection;
        public Frm_SearchSucursal()
        {
            InitializeComponent();
            conection = new SucursalService();
            LoadData();
            CargarEmpresas();
            cbRuc.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
        }

        public void LoadData()
        {
            try
            {
                dgv_Sucursal.DataSource = null;
                dgv_Sucursal.Rows.Clear();
                dgv_Sucursal.Columns.Clear();

                DataSet ds = conection.GetSucursales();
                if (ds != null)
                {
                    dgv_Sucursal.DataSource = ds.Tables["Sucursal"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            conection.FiltroDataGridViewSucursal(dgv_Sucursal, txtSearchName.Text);
        }

        private DataGridViewRow selectedRow;
        private void dgv_Sucursal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgv_Sucursal.Rows[e.RowIndex];
            }
        }

        private void CargarEmpresas()
        {
            try
            {
                DataSet ds = conection.fillEmpresa();
                if (ds != null && ds.Tables["Empresa"].Rows.Count > 0)
                {
                    cbRuc.DataSource = ds.Tables["Empresa"];
                    cbRuc.DisplayMember = "nombre"; // Nombre visible en el ComboBox
                    cbRuc.ValueMember = "RUC"; // Valor oculto asociado (RUC)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empresas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Obtener el siguiente ID disponible
                int nuevoIdSucursal = conection.GetNextSucursalId();

                // Crear el objeto CSucursal con los datos ingresados
                CSucursal nuevaSucursal = new CSucursal
                {
                    IdSucursal = nuevoIdSucursal,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    RUC = cbRuc.SelectedValue.ToString() // Obtiene el RUC de la empresa seleccionada en el ComboBox
                };

                // Llamar al método InsertSucursal pasando el objeto CSucursal
                int resultado = conection.InsertSucursal(nuevaSucursal);

                if (resultado == 1)
                {
                    MessageBox.Show("Sucursal registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Error al registrar la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la sucursal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                // Llenar los campos del formulario con los valores seleccionados
                int idSucursal = Convert.ToInt32(selectedRow.Cells["idSucursal"].Value);
                txtDireccion.Text = selectedRow.Cells["direccion"].Value.ToString();
                txtTelefono.Text = selectedRow.Cells["telefono"].Value.ToString();
                cbRuc.Text = selectedRow.Cells["RUC"].Value.ToString();

                // Crear el objeto CSucursal con los datos ingresados
                CSucursal sucursalActualizada = new CSucursal
                {
                    IdSucursal = idSucursal,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    RUC = cbRuc.SelectedValue.ToString()
                };

                // Llamar al método UpdateSucursal
                int resultado = conection.UpdateSucursal(sucursalActualizada);

                if (resultado == 1)
                {
                    MessageBox.Show("Sucursal actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refrescar el DataGridView
                }
                else
                {
                    MessageBox.Show("Error al actualizar la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila antes de presionar el botón Actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            cbRuc.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_SearchEmpresa frm = new Frm_SearchEmpresa();
            frm.ShowDialog();
        }
    }
}
