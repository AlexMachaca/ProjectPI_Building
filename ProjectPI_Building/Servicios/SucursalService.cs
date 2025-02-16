using ProjectPI_Building.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Servicios
{
    public class SucursalService
    {
        private string connectionString;
        public SucursalService()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }
        private DataSet dataSet = new DataSet();

        public string ConnectionString => connectionString;

        /*********************************+SUCURSAL**************************/
        public DataSet GetSucursales()
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Sucursal";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds, "Sucursal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en GetSucursales: {ex.Message}");
            }

            return ds;
        }

        public int InsertSucursal(CSucursal sucursal)
        {
            try
            {
                string query = "INSERT INTO Sucursal (idSucursal, direccion, telefono, RUC) " +
                               "VALUES (@idSucursal, @direccion, @telefono, @RUC)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idSucursal", sucursal.IdSucursal);
                    command.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                    command.Parameters.AddWithValue("@telefono", sucursal.Telefono);
                    command.Parameters.AddWithValue("@RUC", sucursal.RUC);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la sucursal: " + ex.Message);
                return 0;
            }
        }

        public int UpdateSucursal(CSucursal sucursal)
        {
            try
            {
                string query = "UPDATE Sucursal SET direccion = @direccion, telefono = @telefono, RUC = @RUC " +
                               "WHERE idSucursal = @idSucursal";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idSucursal", sucursal.IdSucursal);
                    command.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                    command.Parameters.AddWithValue("@telefono", sucursal.Telefono);
                    command.Parameters.AddWithValue("@RUC", sucursal.RUC);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la sucursal: " + ex.Message);
                return 0;
            }
        }

        public int DeleteSucursal(int idSucursal)
        {
            try
            {
                string query = "DELETE FROM Sucursal WHERE idSucursal = @idSucursal";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idSucursal", idSucursal);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la sucursal: " + ex.Message);
                return 0;
            }
        }

        public void FiltroDataGridViewSucursal(DataGridView dgv, string name)
        {
            try
            {
                // Desvincular el DataSource
                dgv.DataSource = null;

                // Crear un nuevo DataTable para almacenar los resultados
                DataTable filteredTable = new DataTable();

                // Crear conexión y consulta para filtrar
                string query = $"SELECT * FROM Sucursal WHERE direccion LIKE '%{name}%'";
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

        public int GetNextSucursalId()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(idSucursal), 0) + 1 FROM Sucursal";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el siguiente ID: " + ex.Message);
                return 1; // Si falla, por defecto empezará en 1
            }
        }

        public void fillComboBoxSucursal(ComboBox cmbSucursal)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT idSucursal, direccion FROM Sucursal";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<KeyValuePair<string, string>> sucursalList = new List<KeyValuePair<string, string>>();

                        while (reader.Read())
                        {
                            string idSucursal = reader["idSucursal"].ToString();
                            string nombreCompleto = reader["direccion"].ToString();

                            sucursalList.Add(new KeyValuePair<string, string>(idSucursal, nombreCompleto));
                        }

                        cmbSucursal.DataSource = new BindingSource(sucursalList, null);
                        cmbSucursal.DisplayMember = "Value"; // Muestra la dirección y teléfono
                        cmbSucursal.ValueMember = "Key"; // Guarda el idSucursal
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursales: " + ex.Message);
            }
        }


    }
}
