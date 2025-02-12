using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProjectPI_Building.Servicios
{
    internal class Connection_Temporal
    {
        private string connectionString;

        public Connection_Temporal()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }

        // Función para Listar todos los personales
        public DataSet fillPersonal()
        {
            DataSet dataSet = new DataSet();
            try
            {
                // Consulta SQL
                string query = "SELECT p.idPersonal,pe.nombre, pe.apellidos,pe.numerodocumento\r\nFROM Personal p inner join Persona pe on p.idPersona=pe.idPersona";
                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataSet, "Personal");
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
                return null;
            }
        }

    }
}
