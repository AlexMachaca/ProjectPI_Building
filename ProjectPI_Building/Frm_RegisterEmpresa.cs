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
    public partial class Frm_RegisterEmpresa : Frmtemplate_Insertar
    {
        public int Option;
        private EmpresaService conection = new EmpresaService();
        public Frm_RegisterEmpresa()
        {
            InitializeComponent();
        }

        public void option_get(int option)
        {
            this.Option = option;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CEmpresa empresa = new CEmpresa
                {
                    Ruc = txtRuc.Text,
                    Name = txtNombre.Text,
                    Webpage = txtWebPage.Text,
                    Facebook = txtFacebook.Text,
                    Youtube = txtYoutube.Text
                };

                if (Option == 0) // Insertar nueva empresa
                {
                    int result = conection.insert_empresa(empresa); // Asegúrate de tener este método en tu clase Conection
                    if (result == 1)
                    {
                        MessageBox.Show("Empresa insertada correctamente.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar la empresa. Verifique los datos e inténtelo nuevamente.");
                    }
                }
                else if (Option == 1) // Actualizar empresa existente
                {
                    int result = conection.update_empresa(empresa); // Asegúrate de tener este método en tu clase Conection
                    if (result == 1)
                    {
                        MessageBox.Show("Empresa actualizada correctamente.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la empresa. Verifique los datos e inténtelo nuevamente.");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en el formato de los datos. Verifique las entradas.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}");
            }
        }

        private void Frm_RegisterEmpresa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_SearchEmpresa searchForm = Application.OpenForms.OfType<Frm_SearchEmpresa>().FirstOrDefault();
            searchForm?.LoadData();
        }
    }
}
