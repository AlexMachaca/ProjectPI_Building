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
    public partial class Frm_SearchPersonal : Frmtemplate_Search
    {
        public int fila = 0;
        private PersonalService conection = new PersonalService();
        public Frm_SearchPersonal()
        {
            InitializeComponent();
            LoadData();
            CargarPersonas();
            GenerarIDPersonal();
            btnUpdate.Enabled = false;
        }

        public void LoadData()
        {
            try
            {
                dgv_personal.DataSource = null;

                DataSet ds = conection.fillPersonal();
                if (ds != null && ds.Tables["Personal"] != null)
                {
                    dgv_personal.DataSource = ds.Tables["Personal"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private void ClearInputs()
        {
            cb_turno.SelectedIndex = 0;
            cbCategoria.SelectedIndex = 0;
            txtHorasTrabajo.Clear();
            cbPersona.SelectedIndex = 0;
            txt_contrasena.Clear();
            txt_usuario.Clear();
            txt_confirmar_contra.Clear();
        }
        private void CargarPersonas()
        {
            try
            {
                DataSet ds = conection.fillPersona(); // Método que debes crear en el servicio
                if (ds != null && ds.Tables["Persona"].Rows.Count > 0)
                {
                    cbPersona.DataSource = ds.Tables["Persona"];
                    cbPersona.DisplayMember = "nombre"; // Nombre visible en el ComboBox
                    cbPersona.ValueMember = "idPersona"; // Valor oculto asociado (idPersona)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataGridViewRow selectedRow;

        private void dgv_personal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgv_personal.Rows[e.RowIndex];
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                txtIdPersonal.Text = selectedRow.Cells["idpersonal"].Value.ToString();
                cbCategoria.Text = selectedRow.Cells["categoria"].Value.ToString();
                cb_turno.Text = selectedRow.Cells["turno"].Value.ToString();
                txtHorasTrabajo.Text = selectedRow.Cells["horastrabajo"].Value.ToString();
                cbPersona.Text = selectedRow.Cells["nombre"].Value.ToString();
                txt_usuario.Text = selectedRow.Cells["usuario"].Value.ToString();
                txt_contrasena.Text = selectedRow.Cells["contrasena"].Value.ToString();
                btnUpdate.Enabled = true;

            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila antes de presionar el botón Actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bool temp = CamposVacios();
            if (temp == false)
            {
                return;
            }
            try
            {
                CPersonal personal = new CPersonal
                {
                    IdPersonal = Convert.ToInt32(txtIdPersonal.Text),
                    Categoria = cbCategoria.SelectedItem.ToString(),
                    Turno = cb_turno.SelectedItem.ToString(),
                    HorasTrabajo = Convert.ToInt32(txtHorasTrabajo.Text),
                    IdPersona = (int)cbPersona.SelectedValue, // Obtener el idPersona del ComboBox
                    Usuario= txt_usuario.Text.Trim(),
                    Pasword = txt_contrasena.Text.Trim()
                };

                int result = conection.InsertPersonal(personal);
                if (result == 1)
                {
                    MessageBox.Show("Personal insertado correctamente.");
                    LoadData();
                    ClearInputs();
                    GenerarIDPersonal();
                }
                else
                {
                    MessageBox.Show("Error al insertar el personal.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool temp = CamposVacios();
            if (temp == false)
            {
                return;
            }
            CPersonal personal = new CPersonal
            {
                IdPersonal = Convert.ToInt32(txtIdPersonal.Text),
                Categoria = cbCategoria.SelectedItem.ToString(),
                Turno = cb_turno.SelectedItem.ToString(),
                HorasTrabajo = Convert.ToInt32(txtHorasTrabajo.Text),
                IdPersona = (int)cbPersona.SelectedValue,
                Usuario = txt_usuario.Text.Trim(),
                Pasword = txt_contrasena.Text.Trim()
            };

            int result = conection.update_personal(personal);
            if (result == 1)
            {
                MessageBox.Show("Personal actualizado correctamente.");
                LoadData();
                ClearInputs();
                GenerarIDPersonal();
            }
            else
            {
                MessageBox.Show("Error al actualizar el personal.");
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
                        int idpersona = int.Parse(selectedRow.Cells["idpersonal"].Value.ToString());
                        int eliminado = conection.delete_personal(idpersona);

                        if (eliminado == 1)
                        {
                            MessageBox.Show("Personal eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgv_personal.Rows.Remove(selectedRow);
                            selectedRow = null;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el Personal. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el Personal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un personal para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //funcion para verificar los campos vacios
        private bool CamposVacios()
        {
            if (txtIdPersonal.Text == "")
            {
                MessageBox.Show("Por favor, ingrese el ID del personal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbCategoria.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cb_turno.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, seleccione un turno.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtHorasTrabajo.Text == "")
            {
                MessageBox.Show("Por favor, ingrese las horas de trabajo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbPersona.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, seleccione una persona.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txt_usuario.Text == "")
            {
                MessageBox.Show("Por favor, ingrese el usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txt_contrasena.Text == "")
            {
                MessageBox.Show("Por favor, ingrese la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txt_confirmar_contra.Text == "")
            {
                MessageBox.Show("Por favor, confirme la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txt_contrasena.Text != txt_confirmar_contra.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //Funcion para generar el nuevo ID
        private void GenerarIDPersonal()
        {
            try
            {
                int id = conection.GetNextIdPersonal();
                txtIdPersonal.Text = (id).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
