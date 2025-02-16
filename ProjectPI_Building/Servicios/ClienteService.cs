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
    public class ClienteService
    {
        private string connectionString;
        public ClienteService()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }
        private DataSet dataSet = new DataSet();

        public string ConnectionString => connectionString;
        //--------------------------------------------CLIENTES------------>
        public DataSet fillCliente()
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Cliente";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds, "Cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en fillCliente: {ex.Message}");
            }

            return ds;
        }

        public int insert_cliente(CCliente cliente)
        {
            try
            {
                string query = "INSERT INTO Cliente (idCliente, correoElectronico, idPersona) " +
                               "VALUES (@idCliente, @correoElectronico, @idPersona)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCliente", cliente.Idcliente);
                    command.Parameters.AddWithValue("@correoElectronico", cliente.Correoelectronico);
                    command.Parameters.AddWithValue("@idPersona", cliente.IdPersona);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar cliente: " + ex.Message);
                return 0;
            }
        }

        public int update_cliente(CCliente cliente)
        {
            try
            {
                string query = "UPDATE Cliente SET correoElectronico = @correoelectronico, idPersona = @IDPERSONA " +
                               "WHERE idCliente = @idcliente";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idcliente", cliente.Idcliente);
                    command.Parameters.AddWithValue("@correoelectronico", cliente.Correoelectronico);
                    command.Parameters.AddWithValue("@IDPERSONA", cliente.IdPersona);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                return 0;
            }
        }

        public int delete_cliente(string idCliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Cliente WHERE idCliente = @idcliente";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idcliente", idCliente);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0 ? 1 : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
                return 0;
            }
        }

        public void fillComboBoxPersonas(ComboBox cmb)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT idPersona, nombre + ' ' + apellidos AS NombreCompleto FROM Persona";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<KeyValuePair<string, string>> personas = new List<KeyValuePair<string, string>>();

                        while (reader.Read())
                        {
                            string idPersona = reader["idPersona"].ToString();
                            string nombreCompleto = reader["NombreCompleto"].ToString();

                            personas.Add(new KeyValuePair<string, string>(idPersona, nombreCompleto));
                        }

                        cmb.DataSource = new BindingSource(personas, null);
                        cmb.DisplayMember = "Value"; // Muestra el nombre completo
                        cmb.ValueMember = "Key"; // Guarda el IDPERSONA
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personas: " + ex.Message);
            }
        }

        public void fillComboBoxClientes(ComboBox cmbClientes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT c.idCliente, 
                       p.nombre + ' ' + p.apellidos AS NombreCompleto, 
                       p.tipoDocumento, 
                       p.numeroDocumento 
                FROM Cliente c 
                INNER JOIN Persona p ON c.idPersona = p.idPersona";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<ClienteInfo> clientes = new List<ClienteInfo>();

                        while (reader.Read())
                        {
                            string idCliente = reader["idCliente"].ToString();
                            string nombreCompleto = reader["NombreCompleto"].ToString();
                            string tipoDocumento = reader["tipoDocumento"].ToString();
                            string numeroDocumento = reader["numeroDocumento"].ToString();

                            clientes.Add(new ClienteInfo
                            {
                                IdCliente = idCliente,
                                NombreCompleto = nombreCompleto,
                                TipoDocumento = tipoDocumento,
                                NumeroDocumento = numeroDocumento
                            });
                        }

                        cmbClientes.DataSource = new BindingSource(clientes, null);
                        cmbClientes.DisplayMember = "NombreCompleto"; // Muestra el nombre completo
                        cmbClientes.ValueMember = "IdCliente"; // Guarda el idCliente
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        //metodo para buscar el siguiente idCliente
        public int nextIdCliente()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ISNULL(MAX(idCliente), 0) + 1 FROM Cliente";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el siguiente idCliente: " + ex.Message);
                return 0;
            }
        }

        // Clase para almacenar la información del cliente
        public class ClienteInfo
        {
            public string IdCliente { get; set; }
            public string NombreCompleto { get; set; }
            public string TipoDocumento { get; set; }
            public string NumeroDocumento { get; set; }
        }
    }
}
