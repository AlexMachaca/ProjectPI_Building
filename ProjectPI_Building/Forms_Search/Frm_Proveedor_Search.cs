using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ProjectPI_Building.Clases;
using ProjectPI_Building.Forms_Register;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Search
{
    public partial class Frm_Proveedor_Search : Frm_Template_Search
    {
        private string connectionString;
        public int fila = 0;
        public int fila2 = 0;
        public CProveedor proveedor = new CProveedor();

        public CProveedor ProveedorSeleccionado { get; internal set; }

        public Frm_Proveedor_Search()
        {
            InitializeComponent();
            fill_proveedor();
            connectionString = AppConfig.ConnectionString;
        }

        public void fill_proveedor()
        {
            try
            {
                Connection_Proveedor con = new Connection_Proveedor();
                dgv_proveedores.DataSource = con.fillProveedor().Tables["Proveedor"];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarFiltroDataGridView(string name)
        {
            try
            {
                // Limpiar el DataTable existente si ya existe
                if (dgv_proveedores.DataSource != null)
                {
                    DataTable dt = (DataTable)dgv_proveedores.DataSource;
                    dt.Clear();
                }

                // Crear conexión y consulta
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Consulta SQL para filtrar productos
                    string query = "SELECT * FROM Proveedor WHERE " +
                                   "nombre LIKE @name OR " +
                                   "Nrodocumento LIKE @name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Añadir el parámetro de búsqueda
                        command.Parameters.AddWithValue("@name", "%" + name + "%");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataSet ds = new DataSet();

                        // Llenar el DataSet con los datos filtrados
                        dataAdapter.Fill(ds, "Proveedor");

                        // Asignar la tabla filtrada al DataGridView
                        dgv_proveedores.DataSource = ds.Tables["Proveedor"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el DataGridView: " + ex.Message);
            }
        }

        private void dgv_proveedores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
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

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Frm_Proveedor_Register frmProvider = new Frm_Proveedor_Register();
            frmProvider.option = 0;
            if (frmProvider.ShowDialog() == DialogResult.OK) // Verificar si se agregó un nuevo proveedor
            {
                fill_proveedor(); // Actualizar la tabla de proveedores
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                try
                {
                    proveedor.IdProveedor = int.Parse(dgv_proveedores[0, fila].Value.ToString());
                    proveedor.TipoDocumento = dgv_proveedores[1, fila].Value.ToString();
                    proveedor.NroDocumento = dgv_proveedores[2, fila].Value.ToString();
                    proveedor.Nombre = dgv_proveedores[3, fila].Value.ToString();
                    proveedor.Direccion = dgv_proveedores[4, fila].Value.ToString();
                    proveedor.Celular = dgv_proveedores[5, fila].Value.ToString();
                    proveedor.CorreoElectronico = dgv_proveedores[6, fila].Value.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("La celda está vacía. No se puede convertir a número.");
                }

                //MessageBox.Show("id: "+producto.IdProducto+"fila: "+fila);
                Frm_Proveedor_Register frmProvider = new Frm_Proveedor_Register();
                frmProvider.option = 1;
                frmProvider.filldata(proveedor);
                if (frmProvider.ShowDialog() == DialogResult.OK) // Verificar si se modificó un producto
                {
                    fill_proveedor(); // Actualizar la tabla de productos
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un proveedor para editar.");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (fila >= 0) // Asegúrate de que haya una fila seleccionada
            {
                int id = int.Parse(dgv_proveedores[0, fila].Value.ToString());

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este proveedor?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Connection_Proveedor con = new Connection_Proveedor();
                    if (con.delete_proveedor(id) == 1)
                    {
                        MessageBox.Show("Proveedor eliminado exitosamente.");
                        fill_proveedor(); // Refrescar la lista de productos
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el prroveedor.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un proveedor para eliminar.");
            }
        }

        private void txt_filtrar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txt_filtrar.Text.Trim(); // Obtener el texto del cuadro de búsqueda
            LlenarFiltroDataGridView(searchTerm); // Llamar a la función para filtrar
        }

        private void dgv_proveedores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                fila2 = e.RowIndex;
                ProveedorSeleccionado = new CProveedor
                {
                    IdProveedor = int.Parse(dgv_proveedores[0, fila2].Value.ToString()),
                    TipoDocumento = dgv_proveedores[1, fila2].Value.ToString(),
                    NroDocumento = dgv_proveedores[2, fila2].Value.ToString(),
                    Nombre = dgv_proveedores[3, fila2].Value.ToString(),
                    Direccion = dgv_proveedores[4, fila2].Value.ToString(),
                    Celular = dgv_proveedores[5, fila2].Value.ToString(),
                    CorreoElectronico = dgv_proveedores[6, fila2].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
