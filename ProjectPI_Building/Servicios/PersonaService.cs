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
    public class PersonaService
    {
        private string connectionString;
        public PersonaService()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }
        private DataSet dataSet = new DataSet();

        public string ConnectionString => connectionString;

        /*********************************+PERSONA**************************/
        public DataSet fillPersona()
        {
            DataSet ds = new DataSet(); // Crear un nuevo DataSet cada vez
            string query = "select * from Persona"; // Consulta para obtener datos

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds, "Persona");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en fillPersona: {ex.Message}");
            }

            return ds;
        }

        public int insert_persona(CPersona persona)
        {
            try
            {
                string query = "INSERT INTO Persona (IDPERSONA, apellidos, nombre, genero, fechaNac, celular, tipodocumento, numerodocumento) " +
                               "VALUES (@IDPERSONA, @apellidos, @nombre, @genero, @fechaNac, @celular, @tipodocumento, @numerodocumento)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDPERSONA", persona.Idpersona);
                    command.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                    command.Parameters.AddWithValue("@nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@genero", persona.Genero);
                    command.Parameters.AddWithValue("@fechaNac", persona.FechaNac);
                    command.Parameters.AddWithValue("@celular", persona.Celular);
                    command.Parameters.AddWithValue("@tipodocumento", persona.Tipodocumento);
                    command.Parameters.AddWithValue("@numerodocumento", persona.Numerodocumento);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la persona: " + ex.Message);
                return 2; // Devuelve 2 si hubo un error
            }
        }

        public int update_persona(CPersona persona)
        {
            try
            {
                string query = "UPDATE Persona SET apellidos = @apellidos, nombre = @nombre, genero = @genero, " +
                               "fechaNac = @fechaNac, celular = @celular, tipodocumento = @tipodocumento, " +
                               "numerodocumento = @numerodocumento WHERE IDPERSONA = @IDPERSONA";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDPERSONA", persona.Idpersona);
                    command.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                    command.Parameters.AddWithValue("@nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@genero", persona.Genero);
                    command.Parameters.AddWithValue("@fechaNac", persona.FechaNac);
                    command.Parameters.AddWithValue("@celular", persona.Celular);
                    command.Parameters.AddWithValue("@tipodocumento", persona.Tipodocumento);
                    command.Parameters.AddWithValue("@numerodocumento", persona.Numerodocumento);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la persona: " + ex.Message);
                return 0; // Devuelve 0 si hubo un error
            }
        }

        /*public int delete_persona(string idpersona)
        {
            try
            {
                string query = "DELETE FROM Persona WHERE IDPERSONA = @IDPERSONA";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDPERSONA", idpersona);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la persona: " + ex.Message);
                return 0; // Devuelve 0 si hubo un error
            }
        }*/

        public int delete_persona(string idpersona)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar si la persona tiene registros en Cliente, Usuario o Personal
                    string checkQuery = @"SELECT 
                    (SELECT COUNT(*) FROM Cliente WHERE IDPERSONA = @IDPERSONA) AS ClienteCount,
                    (SELECT COUNT(*) FROM Usuario WHERE IDPERSONA = @IDPERSONA) AS UsuarioCount,
                    (SELECT COUNT(*) FROM Personal WHERE idpersonal = @IDPERSONA) AS PersonalCount";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@IDPERSONA", idpersona);

                        using (SqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (reader.Read()) // Si hay resultados en la consulta
                            {
                                int clienteCount = Convert.ToInt32(reader["ClienteCount"]);
                                int usuarioCount = Convert.ToInt32(reader["UsuarioCount"]);
                                int personalCount = Convert.ToInt32(reader["PersonalCount"]);

                                reader.Close(); // Cerrar el lector antes de ejecutar otras consultas

                                if (clienteCount == 0 && usuarioCount == 0 && personalCount == 0)
                                {
                                    // Si no tiene registros en Cliente, Usuario ni Personal, eliminar Persona directamente
                                    string deletePersona = "DELETE FROM Persona WHERE IDPERSONA = @IDPERSONA";
                                    using (SqlCommand cmdPersona = new SqlCommand(deletePersona, connection))
                                    {
                                        cmdPersona.Parameters.AddWithValue("@IDPERSONA", idpersona);
                                        int result = cmdPersona.ExecuteNonQuery();
                                        return result > 0 ? 1 : 0;
                                    }
                                }
                                else
                                {
                                    // Si tiene registros en otras tablas, eliminarlos antes
                                    string deleteCliente = "DELETE FROM Cliente WHERE IDPERSONA = @IDPERSONA";
                                    string deleteUsuario = "DELETE FROM Usuario WHERE IDPERSONA = @IDPERSONA";
                                    string deletePersonal = "DELETE FROM Personal WHERE idpersonal = @IDPERSONA";

                                    using (SqlCommand cmdCliente = new SqlCommand(deleteCliente, connection))
                                    using (SqlCommand cmdUsuario = new SqlCommand(deleteUsuario, connection))
                                    using (SqlCommand cmdPersonal = new SqlCommand(deletePersonal, connection))
                                    {
                                        cmdCliente.Parameters.AddWithValue("@IDPERSONA", idpersona);
                                        cmdUsuario.Parameters.AddWithValue("@IDPERSONA", idpersona);
                                        cmdPersonal.Parameters.AddWithValue("@IDPERSONA", idpersona);

                                        cmdCliente.ExecuteNonQuery();
                                        cmdUsuario.ExecuteNonQuery();
                                        cmdPersonal.ExecuteNonQuery();
                                    }

                                    // Luego eliminar Persona
                                    string deletePersona = "DELETE FROM Persona WHERE IDPERSONA = @IDPERSONA";
                                    using (SqlCommand cmdPersona = new SqlCommand(deletePersona, connection))
                                    {
                                        cmdPersona.Parameters.AddWithValue("@IDPERSONA", idpersona);
                                        int result = cmdPersona.ExecuteNonQuery();
                                        return result > 0 ? 1 : 0;
                                    }
                                }
                            }
                        }
                    }

                    // Si el lector no encuentra registros, devolver 0 (caso en que el IDPERSONA no existe)
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la persona: " + ex.Message);
                return 0;
            }
        }

        public void search_persona_by_name(DataGridView dgv, string name)
        {
            try
            {
                // Desvincular el DataSource
                dgv.DataSource = null;

                // Crear un nuevo DataTable para almacenar los resultados
                DataTable filteredTable = new DataTable();

                // Crear conexión y consulta para filtrar
                string query = $"SELECT * FROM Persona WHERE nombre LIKE '%{name}%'";
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
    }
}
