using ProjectPI_Building.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Servicios
{
    public class ProductService
    {
        private string connectionString;
        public ProductService()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }
        private DataSet dataSet = new DataSet();

        public string ConnectionString => connectionString;

        public int insert_producto(CProducto p)
        {
            try
            {
                string query = "INSERT INTO Producto (idProducto, categoria, descripcion, unidad, cantidad, stock, preciocompra, precioventa, preciounitario, fechaactualizacion) " +
                               "VALUES (@idproducto, @categoria, @descripcion, @unidad, @cantidad, @stock, @preciocompra, @precioventa, @preciounitario, @fechaactualizacion)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@idproducto", p.Idproducto);
                    command.Parameters.AddWithValue("@categoria", p.Categoria);
                    command.Parameters.AddWithValue("@descripcion", p.Descripcion);
                    command.Parameters.AddWithValue("@unidad", p.Unidad);
                    command.Parameters.AddWithValue("@cantidad", p.Cantidad);
                    command.Parameters.AddWithValue("@stock", p.Stock);
                    command.Parameters.AddWithValue("@preciocompra", p.Preciocompra);
                    command.Parameters.AddWithValue("@precioventa", p.Precioventa);
                    command.Parameters.AddWithValue("@preciounitario", p.Preciounitario);
                    command.Parameters.AddWithValue("@fechaactualizacion", p.Fechaactualizacion.ToString("yyyy-MM-dd"));

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error específico para depuración
                MessageBox.Show("Error al insertar el producto: " + ex.Message);
                Console.WriteLine(ex.Message);
                return 2; // Devuelve 2 si hubo un error
            }
        }

        /**********************************************DELETE PRODUCTO*/
        public int delete_producto(string idproducto)
        {
            try
            {
                string query = $"delete from Producto where idProducto ='{idproducto}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error específico para depuración
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                return 2; // Devuelve 2 si hubo un error
            }
        }

        /**********************************************UPDATE PRODUCTO*/
        public int update_producto(CProducto p)
        {
            try
            {
                string query = "UPDATE Producto SET categoria = @categoria, descripcion = @descripcion, unidad = @unidad, cantidad = @cantidad, " +
                               "stock = @stock, preciocompra = @preciocompra, precioventa = @precioventa, preciounitario = @preciounitario, " +
                               "fechaactualizacion = @fechaactualizacion WHERE idProducto = @idproducto";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@idproducto", p.Idproducto);
                    command.Parameters.AddWithValue("@categoria", p.Categoria);
                    command.Parameters.AddWithValue("@descripcion", p.Descripcion);
                    command.Parameters.AddWithValue("@unidad", p.Unidad);
                    command.Parameters.AddWithValue("@cantidad", p.Cantidad);
                    command.Parameters.AddWithValue("@stock", p.Stock);
                    command.Parameters.AddWithValue("@preciocompra", p.Preciocompra);
                    command.Parameters.AddWithValue("@precioventa", p.Precioventa);
                    command.Parameters.AddWithValue("@preciounitario", p.Preciounitario);
                    command.Parameters.AddWithValue("@fechaactualizacion", p.Fechaactualizacion.ToString("yyyy-MM-dd"));

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch
            {
                return 0; // Devuelve 0 si hubo un error
            }
        }

        public void FiltroDataGridViewProducto(DataGridView dgv, string name)
        {
            try
            {
                // Desvincular el DataSource
                dgv.DataSource = null;

                // Crear un nuevo DataTable para almacenar los resultados
                DataTable filteredTable = new DataTable();

                // Crear conexión y consulta para filtrar
                string query = $"SELECT * FROM Producto WHERE descripcion LIKE '%{name}%'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Cargar el DataTable con los resultados
                        filteredTable.Load(reader);
                    }
                }

                // Asignar el DataTable filtrado al DataGridView
                dgv.DataSource = filteredTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}");
            }
        }

        public List<string> searchProductoByDescripcion(string searchText)
        {
            List<string> resultados = new List<string>();
            string query = "SELECT descripcion FROM Producto WHERE descripcion LIKE @searchText";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultados.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}");
            }

            return resultados;
        }

        public CProducto GetProductoDetails(string idProducto)
        {
            CProducto producto = null;
            string query = "SELECT * FROM Producto WHERE idProducto = @idProducto";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        producto = new CProducto
                        {
                            Idproducto = reader["idProducto"].ToString(),
                            Categoria = reader["categoria"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Unidad = reader["unidad"].ToString(),
                            Cantidad = Convert.ToInt32(reader["cantidad"]),
                            Stock = Convert.ToInt32(reader["stock"]),
                            Preciocompra = Convert.ToDecimal(reader["preciocompra"]),
                            Precioventa = Convert.ToDecimal(reader["precioventa"]),
                            Preciounitario = Convert.ToDecimal(reader["preciounitario"]),
                            Fechaactualizacion = Convert.ToDateTime(reader["fechaactualizacion"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles del producto: " + ex.Message);
            }

            return producto;
        }

        public void fillComboBoxProductos(ComboBox cmb)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT idProducto, descripcion FROM Producto";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<KeyValuePair<string, string>> productos = new List<KeyValuePair<string, string>>();

                        while (reader.Read())
                        {
                            string idProducto = reader["idProducto"].ToString();
                            string descripcion = reader["descripcion"].ToString();

                            productos.Add(new KeyValuePair<string, string>(idProducto, descripcion));
                        }

                        cmb.DataSource = new BindingSource(productos, null);
                        cmb.DisplayMember = "Value"; // Muestra la descripción
                        cmb.ValueMember = "Key"; // Guarda el idProducto
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }
    }
}
