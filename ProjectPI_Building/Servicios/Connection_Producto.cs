using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjectPI_Building.Clases;

namespace ProjectPI_Building.Servicios
{
    internal class Connection_Producto
    {
        private string connectionString;

        public Connection_Producto()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }
        public DataSet fillProducto()
        {
            DataSet dataSet = new DataSet();
            try
            {
                // Consulta SQL
                string query = "SELECT * FROM Producto";
                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataSet, "Producto");
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
                return null;
            }
        }

        public int insert_producto(CProducto p)
        {
            int rowaffected = 0;
            try
            {
                string fecha = p.FechaActualizacion.ToString("yyyy-MM-dd");//yyyy-MM-dd HH:mm:ss
                // Consulta SQL
                string query = " INSERT INTO  Producto VALUES(" + p.IdProducto + ",'" + p.Categoria + "','" + p.Descripcion + "','" + p.Unidad + "'," + p.Cantidad + "," + p.Stock + "," + p.PrecioCompra + "," + p.PrecioVenta + "," + p.PrecioUnitario + ",'" + fecha + "')";
                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    rowaffected = command.ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la insercion de datos: {ex.Message}");

            }
            return rowaffected;
        }

        public int update_producto(CProducto p)
        {
            int rowaffected = 0;
            try
            {
                // Consulta SQL
                string fecha = p.FechaActualizacion.ToString("yyyy-MM-dd");
                string query = " update Producto set " +
                    "categoria='" + p.Categoria + "'," +
                    "descripcion='" + p.Descripcion + "'," +
                    "unidad='" + p.Unidad + "'," +
                    "cantidad=" + p.Cantidad + "," +
                    "stock=" + p.Stock + "," +
                    "preciocompra=" + p.PrecioCompra + "," +
                    "precioventa=" + p.PrecioVenta + "," +
                    "preciounitario=" + p.PrecioUnitario + "," +
                    "fechaactualizacion='" + fecha + "' where idProducto=" + p.IdProducto + "";
                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    rowaffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la modificación de datos: {ex.Message}");
                Console.WriteLine("Error: " + ex);
            }
            return rowaffected;
        }

        public int delete_producto(int idproducto)
        {
            int rowaffected = 0;
            try
            {
                // Consulta SQL para eliminar un producto
                string query = "DELETE FROM Producto WHERE idProducto = @idproducto";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Añadir parámetro
                        command.Parameters.AddWithValue("@idproducto", idproducto);

                        // Ejecutar la consulta
                        rowaffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}");
                Console.WriteLine("Error: " + ex);
            }
            return rowaffected; // Retorna el número de filas afectadas
        }

        public int count_product()
        {
            int count = 0;
            try
            {
                string query = "SELECT TOP 1 idProducto +1 FROM Producto ORDER BY idProducto DESC;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                count = -1;
            }
            return count;
        }
    }
}
