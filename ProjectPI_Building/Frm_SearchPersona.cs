using ProjectPI_Building;
using ProjectPI_Building.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPI_Building
{
    public partial class Frm_SearchPersona : Frm_TemplateSearch
    {
        public int fila = 0;
        PersonaService conection = new PersonaService();
        private string connectionString = "Server=LAPTOP-61ISN71R\\SQLEXPRESS;Database=BDBuilding1;User=sa;Password=111;Encrypt=False;TrustServerCertificate=True;";
        public Frm_SearchPersona()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                dgv_persona.DataSource = null;

                DataSet ds = conection.fillPersona();
                if (ds != null && ds.Tables["Persona"] != null)
                {
                    dgv_persona.DataSource = ds.Tables["Persona"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmRegister_Persona frmProveedor = new FrmRegister_Persona();
            frmProveedor.option_get(0);
            frmProveedor.ShowDialog();
        }

        private DataGridViewRow selectedRow;

        private void dgv_persona_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgv_persona.Rows[e.RowIndex];
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                FrmRegister_Persona frmPersona = new FrmRegister_Persona();
                frmPersona.option_get(1); // Establece la opción para actualizar

                // Asigna los valores de la fila seleccionada a los controles del formulario
                frmPersona.txtIdPersona.Text = selectedRow.Cells["idPersona"].Value.ToString();
                frmPersona.txtApellidos.Text = selectedRow.Cells["apellidos"].Value.ToString();
                frmPersona.txtNombre.Text = selectedRow.Cells["nombre"].Value.ToString();
                frmPersona.txtGenero.Text = selectedRow.Cells["genero"].Value.ToString();
                frmPersona.txtFechaNac.Text = selectedRow.Cells["fechaNac"].Value.ToString();
                frmPersona.txtCelular.Text = selectedRow.Cells["celular"].Value.ToString();
                frmPersona.txtTipoDocumento.Text = selectedRow.Cells["tipodocumento"].Value.ToString();
                frmPersona.txtNumeroDocumento.Text = selectedRow.Cells["numerodocumento"].Value.ToString();

                frmPersona.ShowDialog();
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
                string idpersona = selectedRow.Cells["IDPERSONA"].Value.ToString();
                string nombre = selectedRow.Cells["nombre"].Value.ToString();

                // Verificar si la persona tiene registros relacionados antes de eliminar
                int clienteCount, usuarioCount, personalCount;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string checkQuery = @"SELECT 
                    (SELECT COUNT(*) FROM Cliente WHERE IDPERSONA = @IDPERSONA) AS ClienteCount,
                    (SELECT COUNT(*) FROM Usuario WHERE IDPERSONA = @IDPERSONA) AS UsuarioCount,
                    (SELECT COUNT(*) FROM Personal WHERE idpersonal = @IDPERSONA) AS PersonalCount";

                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                        {
                            checkCmd.Parameters.AddWithValue("@IDPERSONA", idpersona);

                            using (SqlDataReader reader = checkCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    clienteCount = Convert.ToInt32(reader["ClienteCount"]);
                                    usuarioCount = Convert.ToInt32(reader["UsuarioCount"]);
                                    personalCount = Convert.ToInt32(reader["PersonalCount"]);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo verificar la información de la persona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al verificar la información de la persona: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Construir el mensaje de advertencia si hay registros relacionados
                string advertencia = $"¿Está seguro de que desea eliminar a {nombre}?";
                if (clienteCount > 0 || usuarioCount > 0 || personalCount > 0)
                {
                    advertencia += "\n\n⚠ Esta persona tiene registros en:";
                    if (clienteCount > 0) advertencia += $"\n - Cliente ({clienteCount} registros)";
                    if (usuarioCount > 0) advertencia += $"\n - Usuario ({usuarioCount} registros)";
                    if (personalCount > 0) advertencia += $"\n - Personal ({personalCount} registros)";
                    advertencia += "\n\nEstos registros también serán eliminados.";
                }

                DialogResult confirmResult = MessageBox.Show(
                    advertencia,
                    "Confirmar eliminación (⚠esta operacion será irreversible)",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        int eliminado = conection.delete_persona(idpersona);

                        if (eliminado == 1)
                        {
                            MessageBox.Show("Persona eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgv_persona.Rows.Remove(selectedRow);
                            selectedRow = null;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la persona. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la persona: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una persona para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            conection.search_persona_by_name(dgv_persona, txtSearchName.Text);
        }
    }
}
