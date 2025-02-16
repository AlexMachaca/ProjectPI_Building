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
    public class PersonalService
    {
        private string connectionString;
        public PersonalService()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }
        private DataSet dataSet = new DataSet();

        public string ConnectionString => connectionString;

        /*********************************+PERSONAL**************************/
        public DataSet fillPersonal()
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Personal";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds, "Personal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en fillPersonal: {ex.Message}");
            }

            return ds;
        }

        public int InsertPersonal(CPersonal nuevoPersonal)
        {
            try
            {
                string query = "INSERT INTO Personal (idPersonal, categoria, turno, horastrabajo, usuario, pasword, idPersona) " +
                               "VALUES (@idPersonal, @categoria, @turno, @horastrabajo, @usuario, @pasword, @idPersona)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPersonal", nuevoPersonal.IdPersonal);
                    command.Parameters.AddWithValue("@categoria", nuevoPersonal.Categoria);
                    command.Parameters.AddWithValue("@turno", nuevoPersonal.Turno);
                    command.Parameters.AddWithValue("@horastrabajo", nuevoPersonal.HorasTrabajo);
                    command.Parameters.AddWithValue("@usuario", nuevoPersonal.Usuario);
                    command.Parameters.AddWithValue("@pasword", nuevoPersonal.Pasword);
                    command.Parameters.AddWithValue("@idPersona", nuevoPersonal.IdPersona);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el personal: " + ex.Message);
                return 0; // Devuelve 0 si hubo un error
            }
        }

        public int update_personal(CPersonal personal)
        {
            try
            {
                string query = "UPDATE Personal SET categoria = @categoria, turno = @turno, horastrabajo = @horastrabajo, usuario=@usuario, pasword=@pasword" +
                               "WHERE idpersonal = @idpersonal";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idpersonal", personal.IdPersonal);
                    command.Parameters.AddWithValue("@categoria", personal.Categoria);
                    command.Parameters.AddWithValue("@turno", personal.Turno);
                    command.Parameters.AddWithValue("@horastrabajo", personal.HorasTrabajo);
                    command.Parameters.AddWithValue("@usuario", personal.Usuario);
                    command.Parameters.AddWithValue("@pasword", personal.Pasword);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el personal: " + ex.Message);
                return 0;
            }
        }

        public int delete_personal(int idpersonal)
        {
            try
            {
                string query = "DELETE FROM Personal WHERE idpersonal = @idpersonal";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idpersonal", idpersonal);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el personal: " + ex.Message);
                return 0;
            }
        }

        public DataSet fillPersona()
        {
            DataSet ds = new DataSet();
            string query = "SELECT idPersona, nombre FROM Persona"; // Asegúrate de seleccionar el idPersona y el nombre

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

        public void fillComboBoxPersonal(ComboBox cmbPersonal)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT p.idPersonal, p.usuario + ' (' + p.categoria + ')' AS NombreCompleto " +
                                   "FROM Personal p";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<KeyValuePair<string, string>> personalList = new List<KeyValuePair<string, string>>();

                        while (reader.Read())
                        {
                            string idPersonal = reader["idPersonal"].ToString();
                            string nombreCompleto = reader["NombreCompleto"].ToString();

                            personalList.Add(new KeyValuePair<string, string>(idPersonal, nombreCompleto));
                        }

                        cmbPersonal.DataSource = new BindingSource(personalList, null);
                        cmbPersonal.DisplayMember = "Value"; // Muestra el nombre completo
                        cmbPersonal.ValueMember = "Key"; // Guarda el idPersonal
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personal: " + ex.Message);
            }
        }

        // Método para obtener el siguiente ID de Personal
        public int GetNextIdPersonal()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(idPersonal), 0) + 1 FROM Personal";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el siguiente ID de Personal: " + ex.Message);
                return 0;
            }
        }

    }
}
