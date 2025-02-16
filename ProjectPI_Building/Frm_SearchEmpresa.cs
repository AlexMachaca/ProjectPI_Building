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
    public partial class Frm_SearchEmpresa : Frm_TemplateSearch
    {
        private EmpresaService conection;
        public Frm_SearchEmpresa()
        {
            InitializeComponent();
            conection = new EmpresaService();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                dgv_Empresa.DataSource = null;
                dgv_Empresa.Rows.Clear();
                dgv_Empresa.Columns.Clear();

                DataSet ds = conection.fillEmpresa();
                if (ds != null)
                {
                    dgv_Empresa.DataSource = ds.Tables["Empresa"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            conection.LlenarFiltroDataGridView(dgv_Empresa, txtSearchName.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Frm_RegisterEmpresa frmRegister = new Frm_RegisterEmpresa();

            frmRegister.ShowDialog();
        }

        private DataGridViewRow selectedRow;

        private void dgv_Empresa_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgv_Empresa.Rows[e.RowIndex];
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                Frm_RegisterEmpresa frmEmpresa = new Frm_RegisterEmpresa();
                frmEmpresa.option_get(1);

                frmEmpresa.txtRuc.Text = selectedRow.Cells["RUC"].Value.ToString();
                frmEmpresa.txtNombre.Text = selectedRow.Cells["nombre"].Value.ToString();
                frmEmpresa.txtWebPage.Text = selectedRow.Cells["paginaweb"].Value.ToString();
                frmEmpresa.txtFacebook.Text = selectedRow.Cells["facebook"].Value.ToString();
                frmEmpresa.txtYoutube.Text = selectedRow.Cells["youtube"].Value.ToString();

                frmEmpresa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila antes de presionar el botón Actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                DialogResult confirmResult = MessageBox.Show(
                    "¿Está seguro de que desea eliminar?\nEmpresa: " + selectedRow.Cells["nombre"].Value.ToString(),
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        string RUC = selectedRow.Cells["RUC"].Value.ToString();
                        int eliminado = conection.delete_empresa(RUC);

                        if (eliminado == 1)
                        {
                            MessageBox.Show("Empresa eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgv_Empresa.Rows.Remove(selectedRow);
                            selectedRow = null;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar Empresa. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el empresa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una empresa para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
