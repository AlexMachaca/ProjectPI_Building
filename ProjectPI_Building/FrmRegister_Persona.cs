using ProjectPI_Building.Clases;
using ProjectPI_Building.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPI_Building
{
    public partial class FrmRegister_Persona : Frmtemplate_Insertar
    {
        public int Option;
        PersonaService conection = new PersonaService();
        public FrmRegister_Persona()
        {
            InitializeComponent();
        }

        public void option_get(int option)
        {
            this.Option = option;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CPersona persona = new CPersona
            {
                Idpersona = txtIdPersona.Text,
                Apellidos = txtApellidos.Text,
                Nombre = txtNombre.Text,
                Genero = txtGenero.Text,
                //FechaNac = txtFechaNac.Value,
                Celular = txtCelular.Text,
                Tipodocumento = txtTipoDocumento.Text,
                Numerodocumento = txtNumeroDocumento.Text
            };
            if (!DateTime.TryParseExact(
                    txtFechaNac.Text,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime fechaNac))
            {
                MessageBox.Show("La fecha no tiene el formato correcto (dd/MM/yyyy).");
                return;
            }
            persona.FechaNac = fechaNac;

            if (Option == 0) // Insertar
            {
                int result = conection.insert_persona(persona);
                if (result == 1)
                {
                    MessageBox.Show("Persona insertada correctamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar la persona. Verifique los datos e inténtelo nuevamente.");
                }
            }
            else if (Option == 1) // Actualizar
            {
                int result = conection.update_persona(persona);
                if (result == 1)
                {
                    MessageBox.Show("Persona actualizada correctamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la persona. Verifique los datos e inténtelo nuevamente.");
                }
            }
        }

        private void FrmRegister_Persona_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_SearchPersona searchForm = Application.OpenForms.OfType<Frm_SearchPersona>().FirstOrDefault();
            searchForm?.LoadData();
        }
    }
}
