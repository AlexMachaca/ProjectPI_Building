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
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Register
{
    public partial class Frm_Contrato : Form
    {
        public Frm_Contrato()
        {
            InitializeComponent();
            LlenarComboBoxPersonal();
            LlenarComboBoxTipoContrato();
        }

        //llenar los combobox personal
        private void LlenarComboBoxPersonal()
        {
            try
            {
                Connection_Temporal conection = new Connection_Temporal();
                DataSet personalDataSet = conection.fillPersonal();
                if (personalDataSet?.Tables.Count > 0)
                {
                    DataTable personalTable = personalDataSet.Tables["Personal"];

                    // Desvincula y limpia el ComboBox
                    cb_personal.DataSource = null;
                    cb_personal.Items.Clear();

                    // Verifica si la columna InfoProveedor ya existe antes de agregarla
                    if (!personalTable.Columns.Contains("InfoPersonal"))
                    {
                        personalTable.Columns.Add("InfoPersonal", typeof(string), "nombre + ' ' + apellidos+' '+numerodocumento");
                    }

                    // Configura el ComboBox
                    cb_personal.DisplayMember = "InfoPersonal";
                    cb_personal.ValueMember = "idPersonal";
                    cb_personal.DataSource = personalTable;

                    // Refresca el ComboBox
                    cb_personal.Refresh();
                }
                else
                {
                    MessageBox.Show("No se encontraron personal registrados.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el ComboBox: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        //llenar el comboBox de tipo de contrato
        private void LlenarComboBoxTipoContrato()
        {
            try
            {
                Connection_Contrato conection = new Connection_Contrato();
                DataSet tipoContratoDataSet = conection.fillTipoContrato();
                if (tipoContratoDataSet?.Tables.Count > 0)
                {
                    DataTable tipoContratoTable = tipoContratoDataSet.Tables["TipoContrato"];

                    // Desvincula y limpia el ComboBox
                    cb_tipo_contrato.DataSource = null;
                    cb_tipo_contrato.Items.Clear();

                    // Verifica si la columna InfoProveedor ya existe antes de agregarla
                    if (!tipoContratoTable.Columns.Contains("InfoTipoContrato"))
                    {
                        tipoContratoTable.Columns.Add("InfoTipoContrato", typeof(string), "categoria + ' - S/' + Sueldo");
                    }

                    // Configura el ComboBox
                    cb_tipo_contrato.DisplayMember = "InfoTipoContrato";
                    cb_tipo_contrato.ValueMember = "idTipocontrato";
                    cb_tipo_contrato.DataSource = tipoContratoTable;

                    // Refresca el ComboBox
                    cb_personal.Refresh();
                }
                else
                {
                    MessageBox.Show("No se encontraron tipo contrato registrados.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el ComboBox: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        //Verificar si los campos estan llenos
        private bool CamposLlenos()
        {
            if (cb_personal.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un personal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cb_tipo_contrato.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de contrato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string fechaInicio = dtp_fecha_ingreso.Value.ToString();
            if (string.IsNullOrWhiteSpace(fechaInicio))
            {
                MessageBox.Show("Ingrese una fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string fechaFin = dtp_fecha_termino.Value.ToString();
            if (string.IsNullOrWhiteSpace(fechaFin))
            {
                MessageBox.Show("Ingrese una fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (CamposLlenos() == false)
            {
                return;
            }
            try
            {
                Connection_Contrato conection = new Connection_Contrato();
                int idPersonal = (int)cb_personal.SelectedValue;
                int idTipoContrato = (int)cb_tipo_contrato.SelectedValue;
                string fechaInicio = dtp_fecha_ingreso.Value.ToString("yyyy-MM-dd");
                string fechaFin = dtp_fecha_termino.Value.ToString("yyyy-MM-dd");
                int idContrato = conection.count_contrato() + 1;
                CContrato contrato = new CContrato();
                contrato.IdContrato = idContrato;
                contrato.IdPersonal = idPersonal;
                contrato.IdTipocontrato = idTipoContrato;
                contrato.FechaIngreso = DateTime.Parse(fechaInicio);
                contrato.FechaTermino = DateTime.Parse(fechaFin);

                bool result = conection.InsertarContrato(contrato);
                if (result)
                {
                    MessageBox.Show("Contrato registrado correctamente.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar el contrato.",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el contrato: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void Frm_Contrato_Load(object sender, EventArgs e)
        {

            // Obtener el primer día del mes siguiente
            DateTime primerDiaDelMesSiguiente = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
            dtp_fecha_ingreso.Value = primerDiaDelMesSiguiente;

            // Obtener el último día del mes siguiente
            DateTime ultimoDiaDelMesSiguiente = primerDiaDelMesSiguiente.AddMonths(1).AddDays(-1);
            dtp_fecha_termino.Value = ultimoDiaDelMesSiguiente;

        }

        private void btn_registro_tipo_contrato_Click(object sender, EventArgs e)
        {
            //abrir el formulario de registro de tipo de contrato
            Frm_Tipo_Contrato frm_Registro_Tipo_Contrato = new Frm_Tipo_Contrato();
            DialogResult result = frm_Registro_Tipo_Contrato.ShowDialog();

            // Verificar si se seleccionó un tipo de contrato
            if (result == DialogResult.OK)
            {
                // Obtener el ID y la información del tipo de contrato seleccionado desde el formulario Frm_Tipo_Contrato
                int idTipoContratoSeleccionado = frm_Registro_Tipo_Contrato.IdTipoContratoSeleccionado;
                string infoTipoContratoSeleccionado = frm_Registro_Tipo_Contrato.InfoTipoContratoSeleccionado;

                // Llenar el ComboBox con el nuevo tipo de contrato seleccionado
                LlenarComboBoxTipoContrato();

                // Seleccionar el elemento en el ComboBox
                cb_tipo_contrato.SelectedValue = idTipoContratoSeleccionado;
            }
            else
            {
                // Refrescar el ComboBox
                LlenarComboBoxTipoContrato();
            }

            // Refrescar el ComboBox
            cb_tipo_contrato.Refresh();
        }
    }
}
