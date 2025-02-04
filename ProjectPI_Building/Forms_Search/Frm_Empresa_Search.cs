using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ProjectPI_Building.Clases;
using ProjectPI_Building.Forms_Register;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Search
{
    public partial class Frm_Empresa_Search : Frm_Template_Search
    {
        string connectionString;
        public int fila = 0;
        private DataSet dsBuilding;
        private SqlDataAdapter dtaEmpresa;
        public CEmpresa empresa = new CEmpresa();
        public Frm_Empresa_Search()
        {
            InitializeComponent();
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;

            try
            {
                dsBuilding = new DataSet();
                fill_empresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void fill_empresa()
        {
            try
            {
                Conection_Empresa con = new Conection_Empresa();
                var dataSet = con.fillEmpresa();

                if (dataSet == null || !dataSet.Tables.Contains("Empresa"))
                {
                    MessageBox.Show("No se pudieron cargar los datos o la tabla 'Empresa' no existe.");
                    return; // Salir del método si no hay datos
                }

                dgv_empresa.DataSource = dataSet.Tables["Empresa"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarFiltroDataGridView(String name)
        {
            try
            {
                if (dsBuilding.Tables.Contains("Empresa"))
                {
                    dsBuilding.Tables["Empresa"].Clear();
                }
                // Crear conexión y consulta
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Empresa WHERE Nombre like '%" + name + "%' or RUC like '%" + name + "%'";
                    dtaEmpresa = new SqlDataAdapter(query, connection);

                    // Llenar el DataSet con los datos de la tabla Empresa
                    dtaEmpresa.Fill(dsBuilding, "Empresa");
                    // Asignar la tabla Empresa al DataGridView
                    dgv_empresa.DataSource = dsBuilding.Tables["Empresa"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el DataGridView: " + ex.Message);
            }
        }

        private void txt_filtrar_TextChanged(object sender, EventArgs e)
        {
            LlenarFiltroDataGridView(txt_filtrar.Text);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Frm_Empresa_Register frmEmpresa = new Frm_Empresa_Register();
            frmEmpresa.option = 0;
            if (frmEmpresa.ShowDialog() == DialogResult.OK)
            {
                fill_empresa();
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                try
                {
                    empresa.RUC = dgv_empresa[0, fila].Value.ToString();
                    empresa.Nombre = dgv_empresa[1, fila].Value.ToString();
                    empresa.PaginaWeb = dgv_empresa[2, fila].Value.ToString();
                    empresa.Facebook = dgv_empresa[3, fila].Value.ToString();
                    empresa.Youtube = dgv_empresa[4, fila].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La celda está vacía.");
                }

                //MessageBox.Show("id: "+producto.IdProducto+"fila: "+fila);
                Frm_Empresa_Register frmEmpresa = new Frm_Empresa_Register();
                frmEmpresa.option = 1;
                frmEmpresa.filldata(empresa);
                if (frmEmpresa.ShowDialog() == DialogResult.OK)
                {
                    fill_empresa();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para editar.");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (fila >= 0) // Asegúrate de que haya una fila seleccionada
            {
                string ruc = dgv_empresa[0, fila].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta empresa?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conection_Empresa con = new Conection_Empresa();
                    if (con.delete_empresa(ruc) == 1)
                    {
                        MessageBox.Show("Empresa eliminada exitosamente.");
                        fill_empresa();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la empresa.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una empresa para eliminar.");
            }
        }

        private void dgv_empresa_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Verificamos que el índice de fila sea válido
            if (e.RowIndex >= 0) // Aseguramos que no se haga clic en el encabezado
            {
                fila = e.RowIndex; // Asignamos el índice de fila a la variable 'fila'

            }
            else
            {
                MessageBox.Show("Clic en área no válida.");
                Console.WriteLine("Clic en área no válida.");
            }
        }
    }
}
