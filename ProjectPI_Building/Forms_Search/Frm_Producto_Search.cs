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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectPI_Building.Forms_Search
{
    public partial class Frm_Producto_Search : Frm_Template_Search
    {
        private string connectionString;
        public int fila = 0;
        public int fila2 = 0;
        public CProducto1 producto = new CProducto1();

        public CProducto1 ProductoSeleccionado { get; internal set; }

        public Frm_Producto_Search()
        {
            InitializeComponent();
            fill_Product();
            connectionString = AppConfig.ConnectionString;
        }

        public void fill_Product()
        {
            try
            {
                Connection_Producto con = new Connection_Producto();
                dgv_productos.DataSource = con.fillProducto().Tables["Producto"];


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
                if (dgv_productos.DataSource != null)
                {
                    DataTable dt = (DataTable)dgv_productos.DataSource;
                    dt.Clear();
                }

                // Crear conexión y consulta
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Consulta SQL para filtrar productos
                    string query = "SELECT * FROM Producto WHERE " +
                                   "categoria LIKE @name OR " +
                                   "descripcion LIKE @name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Añadir el parámetro de búsqueda
                        command.Parameters.AddWithValue("@name", "%" + name + "%");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataSet ds = new DataSet();

                        // Llenar el DataSet con los datos filtrados
                        dataAdapter.Fill(ds, "Producto");

                        // Asignar la tabla filtrada al DataGridView
                        dgv_productos.DataSource = ds.Tables["Producto"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el DataGridView: " + ex.Message);
            }
        }

        private void dgv_productos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void txt_filtrar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txt_filtrar.Text.Trim(); // Obtener el texto del cuadro de búsqueda
            LlenarFiltroDataGridView(searchTerm); // Llamar a la función para filtrar
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Frm_Producto_Register frmProduct = new Frm_Producto_Register();
            frmProduct.option = 0;
            if (frmProduct.ShowDialog() == DialogResult.OK) // Verificar si se agregó un nuevo producto
            {
                fill_Product(); // Actualizar la tabla de productos
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                try
                {
                    string id_string = dgv_productos[0, fila].Value.ToString();

                    producto.IdProducto = int.Parse(id_string);
                    producto.Categoria = dgv_productos[1, fila].Value.ToString();
                    producto.Descripcion = dgv_productos[2, fila].Value.ToString();
                    producto.Unidad = dgv_productos[3, fila].Value.ToString();
                    producto.Cantidad = int.Parse(dgv_productos[4, fila].Value.ToString());
                    producto.Stock = int.Parse(dgv_productos[5, fila].Value.ToString());
                    producto.PrecioCompra = float.Parse(dgv_productos[6, fila].Value.ToString());
                    producto.PrecioVenta = float.Parse(dgv_productos[7, fila].Value.ToString());
                    producto.PrecioUnitario = float.Parse(dgv_productos[8, fila].Value.ToString());
                    producto.FechaActualizacion = DateTime.Parse(dgv_productos[9, fila].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La celda está vacía.");
                }

                //MessageBox.Show("id: "+producto.IdProducto+"fila: "+fila);
                Frm_Producto_Register frmProduct = new Frm_Producto_Register();
                frmProduct.option = 1;
                frmProduct.filldata(producto);
                if (frmProduct.ShowDialog() == DialogResult.OK) // Verificar si se modificó un producto
                {
                    fill_Product(); // Actualizar la tabla de productos
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
                int idproducto = int.Parse(dgv_productos[0, fila].Value.ToString());

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Connection_Producto con = new Connection_Producto();
                    if (con.delete_producto(idproducto) == 1)
                    {
                        MessageBox.Show("Producto eliminado exitosamente.");
                        fill_Product(); // Refrescar la lista de productos
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
            }
        }

        private void dgv_productos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fila2 = e.RowIndex;
                ProductoSeleccionado = new CProducto1
                {
                    IdProducto = int.Parse(dgv_productos[0, fila2].Value.ToString()),
                    Categoria = dgv_productos[1, fila2].Value.ToString(),
                    Descripcion = dgv_productos[2, fila2].Value.ToString(),
                    Unidad = dgv_productos[3, fila2].Value.ToString(),
                    Cantidad = int.Parse(dgv_productos[4, fila2].Value.ToString()),
                    Stock = int.Parse(dgv_productos[5, fila2].Value.ToString()),
                    PrecioCompra = float.Parse(dgv_productos[6, fila2].Value.ToString()),
                    PrecioVenta = float.Parse(dgv_productos[7, fila2].Value.ToString()),
                    PrecioUnitario = float.Parse(dgv_productos[8, fila2].Value.ToString()),
                    FechaActualizacion = DateTime.Parse(dgv_productos[9, fila2].Value.ToString())
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
