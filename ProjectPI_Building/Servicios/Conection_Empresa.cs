using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjectPI_Building.Clases;

namespace ProjectPI_Building.Servicios
{
    internal class Conection_Empresa
    {
        private string connectionString;

        public Conection_Empresa()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }

        public DataSet fillEmpresa()
        {
            DataSet dataSet = new DataSet();
            try
            {
                // Consulta SQL
                string query = "SELECT * FROM Empresa";
                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataSet, "Empresa"); // Llenar el DataSet con la tabla "Empresa"
                }
                // Enlazar el DataSet al DataGridView
                //dataGridView1.DataSource = dataSet.Tables["Usuarios"];
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
                return null;
            }
        }

        public int insert_empresa(CEmpresa e)
        {
            int rowaffected = 0;
            try
            {
                // Consulta SQL
                string query = " INSERT INTO  EMPRESA VALUES('" + e.RUC + "','" + e.Nombre + "','" + e.PaginaWeb + "','" + e.Facebook + "','" + e.Youtube + "')";
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

        public int update_empresa(CEmpresa e)
        {
            int rowaffected = 0;
            try
            {
                // Consulta SQL

                string query = " update empresa set " +
                    "nombre='" + e.Nombre + "'," +
                    "paginaweb='" + e.PaginaWeb + "'," +
                    "facebook='" + e.Facebook + "'," +
                    "youtube='" + e.Youtube + "' where RUC='" + e.RUC + "'";
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

        public int delete_empresa(string Ruc)
        {
            int rowaffected = 0;
            try
            {
                // Consulta SQL para eliminar un producto
                string query = "DELETE FROM Empresa WHERE RUC = @ruc";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Añadir parámetro
                        command.Parameters.AddWithValue("@ruc", Ruc);

                        // Ejecutar la consulta
                        rowaffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la empresa: {ex.Message}");
                Console.WriteLine("Error: " + ex);
            }
            return rowaffected; // Retorna el número de filas afectadas
        }
    }
}
