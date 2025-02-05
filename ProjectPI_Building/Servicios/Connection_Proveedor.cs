using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjectPI_Building.Clases;

namespace ProjectPI_Building.Servicios
{

    internal class Connection_Proveedor
    {
        private string connectionString;

        public Connection_Proveedor()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }

        public DataSet fillProveedor()
        {
            DataSet dataSet = new DataSet();
            try
            {
                // Consulta SQL
                string query = "SELECT * FROM Proveedor";
                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataSet, "Proveedor");
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
                return null;
            }
        }

        public int insert_proveedor(CProveedor p)
        {
            int rowaffected = 0;
            try
            {
                // Consulta SQL
                string query = " INSERT INTO  proveedor VALUES(" + p.IdProveedor + ",'" + p.TipoDocumento + "','" + p.NroDocumento + "','" + p.Nombre + "','" + p.Direccion + "','" + p.Celular + "','" + p.CorreoElectronico + "')";
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

        public int update_proveedor(CProveedor p)
        {
            int rowaffected = 0;
            try
            {
                // Consulta SQL

                string query = " update Proveedor set " +
                    "tipodocumento='" + p.TipoDocumento + "'," +
                    "Nrodocumento='" + p.NroDocumento + "'," +
                    "nombre='" + p.Nombre + "'," +
                    "direccion='" + p.Direccion + "'," +
                    "celular='" + p.Celular + "'," +
                    "correoelectronico='" + p.CorreoElectronico + "' where idProveedor=" + p.IdProveedor + "";
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

            }
            return rowaffected;
        }

        public int delete_proveedor(int idProveedor)
        {
            int rowaffected = 0;
            try
            {
                // Consulta SQL para eliminar un producto
                string query = "DELETE FROM Proveedor WHERE idProveedor = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Añadir parámetro
                        command.Parameters.AddWithValue("@id", idProveedor);

                        // Ejecutar la consulta
                        rowaffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}");
                Console.WriteLine("Error: " + ex);
            }
            return rowaffected; // Retorna el número de filas afectadas
        }

        public int count_proveedor()
        {
            int count = 0;
            try
            {
                string query = "SELECT TOP 1 idProveedor +1 FROM Proveedor ORDER BY idProveedor DESC;";
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
