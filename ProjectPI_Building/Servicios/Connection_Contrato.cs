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
    internal class Connection_Contrato
    {
        private string connectionString;

        public Connection_Contrato()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }

        // Función para Insertar un nuevo Tipo de Contrato
        public bool InsertarTipoContrato(int idTipocontrato, string categoria, decimal sueldo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO TipoContrato (idTipocontrato, categoria, Sueldo) VALUES (@idTipocontrato, @categoria, @sueldo)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idTipocontrato", idTipocontrato);
                        command.Parameters.AddWithValue("@categoria", categoria);
                        command.Parameters.AddWithValue("@sueldo", sueldo);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Retorna true si la inserción fue exitosa
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar TipoContrato: " + ex.Message);
                return false; // Retorna false si hubo un error
            }
        }

        // Función para Listar todos los Tipos de Contrato
        public DataTable ListarTiposContrato()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idTipocontrato, categoria, Sueldo FROM TipoContrato";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable); // Llena el DataTable con los resultados de la consulta
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar Tipos de Contrato: " + ex.Message);
                return null; // Retorna null si hubo un error
            }
            return dataTable;
        }

        public int count_tipo_contrato()
        {
            int count = 0;
            try
            {
                string query = "SELECT TOP 1 idTipocontrato +1 FROM TipoContrato ORDER BY idTipocontrato DESC;";
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

        public DataSet fillTipoContrato()
        {
            DataSet dataSet = new DataSet();
            try
            {
                // Consulta SQL
                string query = "SELECT * FROM TipoContrato";
                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataSet, "TipoContrato");
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
                return null;
            }
        }
        public int count_contrato()
        {
            int count = 0;
            try
            {
                string query = "SELECT TOP 1 idContrato FROM Contrato ORDER BY idContrato DESC;";
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
            }
            return count;
        }

        public bool InsertarContrato(CContrato contrato)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO Contrato (idContrato, FechaIngreso, FechaTermino, idPersonal, idTipocontrato)
                        VALUES (@idContrato, @fechaIngreso, @fechaTermino, @idPersonal, @idTipocontrato)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idContrato", contrato.IdContrato);
                        command.Parameters.AddWithValue("@fechaIngreso", contrato.FechaIngreso);
                        command.Parameters.AddWithValue("@fechaTermino", contrato.FechaTermino);
                        command.Parameters.AddWithValue("@idPersonal", contrato.IdPersonal);
                        command.Parameters.AddWithValue("@idTipocontrato", contrato.IdTipocontrato);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Retorna true si la inserción fue exitosa
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar Contrato: " + ex.Message);
                return false; // Retorna false si hubo un error
            }
        }
    }
}

