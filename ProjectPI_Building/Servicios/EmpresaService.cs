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
    public class EmpresaService
    {
        private string connectionString;
        public EmpresaService()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }
        private DataSet dataSet = new DataSet();

        public string ConnectionString => connectionString; // Propiedad para acceder a la cadena de conexión

        public DataSet fillEmpresa()
        {
            DataSet ds = new DataSet(); // Crear un nuevo DataSet cada vez
            string query = "SELECT * FROM Empresa"; // Consulta para obtener datos

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds, "Empresa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en fillEmpresa: {ex.Message}");
            }

            return ds;
        }

        public DataSet fillProducto()
        {
            string query = "SELECT * FROM producto"; // Asegúrate de que esta consulta no cause duplicados
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(ds, "producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar datos: {ex.Message}");
            }

            return ds;
        }

        public int count_product()
        {
            int count = 0;
            try
            {
                string query = "SELECT COUNT(*) + 1 FROM producto";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    count = Convert.ToInt32(cmd.ExecuteScalar());  // Obtener el resultado correcto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                count = 0;
            }
            return count;
        }


        public void LlenarFiltroDataGridView(DataGridView dgv, string name)
        {
            try
            {
                // Desvincular el DataSource
                dgv.DataSource = null;

                // Crear un nuevo DataTable para almacenar los resultados
                DataTable filteredTable = new DataTable();

                // Crear conexión y consulta para filtrar
                string query = $"SELECT * FROM Empresa WHERE Nombre LIKE '%{name}%'";
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

        public int insert_empresa(CEmpresa empresa)
        {
            try
            {
                string query = "INSERT INTO empresa (Nombre, RUC, paginaweb, facebook, youtube) " +
                               "VALUES (@name, @ruc, @webpage, @facebook, @youtube)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ruc", empresa.Ruc);
                    command.Parameters.AddWithValue("@name", empresa.Name);
                    command.Parameters.AddWithValue("@webpage", empresa.Webpage);
                    command.Parameters.AddWithValue("@facebook", empresa.Facebook);
                    command.Parameters.AddWithValue("@youtube", empresa.Youtube);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la empresa: " + ex.Message);
                return 2; // Devuelve 2 si hubo un error
            }
        }

        public int update_empresa(CEmpresa empresa)
        {
            try
            {
                string query = "UPDATE empresa SET Nombre = @name, paginaweb = @webpage, facebook = @facebook, youtube = @youtube " +
                               "WHERE RUC = @ruc";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ruc", empresa.Ruc);
                    command.Parameters.AddWithValue("@name", empresa.Name);
                    command.Parameters.AddWithValue("@webpage", empresa.Webpage);
                    command.Parameters.AddWithValue("@facebook", empresa.Facebook);
                    command.Parameters.AddWithValue("@youtube", empresa.Youtube);

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

        public int delete_empresa(string RUC)
        {
            try
            {
                string query = $"delete from Empresa where RUC ='{RUC}'";

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
                MessageBox.Show("Error al eliminar Empresa: " + ex.Message);
                return 2; // Devuelve 2 si hubo un error
            }
        }
    }
}
