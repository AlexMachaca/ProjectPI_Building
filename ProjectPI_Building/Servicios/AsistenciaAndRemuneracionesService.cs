using System.Data.SqlClient;
using System.Data;
using ProjectPI_Building;

public class AsistenciaAndRemuneracionesService
{
    private readonly string connectionString ;

    public AsistenciaAndRemuneracionesService()
    {
        // Obtener la cadena de conexión desde AppConfig
        connectionString = AppConfig.ConnectionString;
    }

    // Método mejorado para obtener empleados
    public DataTable ObtenerEmpleados()
    {
        DataTable dt = new DataTable();
        string query = @"
            SELECT 
                p.idPersonal, 
                CONCAT(pe.nombre, ' ', pe.apellidos) AS NombreCompleto, 
                pe.tipodocumento, 
                pe.numerodocumento
            FROM Persona pe
            INNER JOIN Personal p ON pe.idPersona = p.idPersona";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        catch (SqlException ex)
        {
            throw new Exception($"Error al obtener empleados: {ex.Message}", ex);
        }
    }

    // Método mejorado para obtener datos de empleado
    public DataRow ObtenerDatosEmpleado(int idPersonal)
    {
        string query = @"
            SELECT Persona.tipoDocumento, Persona.numerodocumento
            FROM Persona 
            INNER JOIN Personal ON Persona.idPersona = Personal.idPersona 
            WHERE Personal.idPersonal = @idPersonal";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@idPersonal", SqlDbType.Int).Value = idPersonal;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            throw new Exception($"Error al obtener datos del empleado {idPersonal}: {ex.Message}", ex);
        }
    }

    public void RegistrarEntrada(int idPersonal)
    {
        string query = @"
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @idControl INT;
        SELECT @idControl = ISNULL(MAX(idControl), 0) + 1 
        FROM Control_asistencia WITH (TABLOCKX);
        
        INSERT INTO Control_asistencia (idControl, idPersonal, HoraIngreso, FechaTrabajo) 
        VALUES (@idControl, @idPersonal, @horaIngreso, @fecha);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@idPersonal", SqlDbType.Int).Value = idPersonal;
                    cmd.Parameters.Add("@horaIngreso", SqlDbType.DateTime2).Value = DateTime.Now;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = DateTime.Now.Date;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException ex)
        {
            throw new Exception($"Error al registrar entrada del empleado {idPersonal}: {ex.Message}", ex);
        }
    }

    // Método mejorado para registrar salida
    public void RegistrarSalida(int idPersonal)
    {
        string query = @"
            UPDATE Control_asistencia 
            SET HoraSalida = @horaSalida, Horasextras = @horasExtras 
            WHERE idPersonal = @idPersonal AND FechaTrabajo = @fecha AND HoraSalida IS NULL";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    DateTime horaSalida = DateTime.Now;
                    DateTime? horaIngreso = ObtenerHoraIngreso(idPersonal);

                    if (horaIngreso.HasValue)
                    {
                        TimeSpan horasTrabajadas = horaSalida - horaIngreso.Value;

                        // Convertir correctamente las horas extras
                        int horasExtras = (int)Math.Floor(horasTrabajadas.TotalHours) > 8 ? (int)Math.Floor(horasTrabajadas.TotalHours) - 8 : 0;

                        cmd.Parameters.Add("@horaSalida", SqlDbType.DateTime2).Value = horaSalida;
                        cmd.Parameters.Add("@horasExtras", SqlDbType.Int).Value = horasExtras;
                        cmd.Parameters.Add("@idPersonal", SqlDbType.Int).Value = idPersonal;
                        cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = DateTime.Now.Date;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            throw new Exception($"Error al registrar salida del empleado {idPersonal}: {ex.Message}", ex);
        }
    }

    // Método auxiliar para obtener hora de ingreso
    private DateTime? ObtenerHoraIngreso(int idPersonal)
    {
        string query = @"
            SELECT HoraIngreso 
            FROM Control_asistencia 
            WHERE idPersonal = @idPersonal 
            AND FechaTrabajo = @fecha 
            AND HoraSalida IS NULL";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@idPersonal", SqlDbType.Int).Value = idPersonal;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = DateTime.Now.Date;

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? (DateTime)result : (DateTime?)null;
                }
            }
        }
        catch (SqlException ex)
        {
            throw new Exception($"Error al obtener hora de ingreso del empleado {idPersonal}: {ex.Message}", ex);
        }
    }

    public DataTable ObtenerTodasLasAsistencias(DateTime fecha)
    {
        DataTable dt = new DataTable();
        string query = @"
        SELECT 
            p.idPersonal,
            CONCAT(pe.nombre, ' ', pe.apellidos) AS NombreCompleto,
            ca.HoraIngreso, 
            ISNULL(TRY_CONVERT(VARCHAR, ca.HoraSalida, 120), 'No registrado') AS HoraSalida, 
            ca.HorasExtras 
        FROM 
            Control_asistencia ca
        INNER JOIN 
            Personal p ON ca.idPersonal = p.idPersonal
        INNER JOIN 
            Persona pe ON p.idPersona = pe.idPersona
        WHERE 
            TRY_CONVERT(DATE, ca.FechaTrabajo) = @fecha";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        catch (SqlException ex)
        {
            throw new Exception($"Error al obtener todas las asistencias: {ex.Message}", ex);
        }
    }
    
    public string ObtenerEstadoAsistencia(int idPersonal, DateTime fecha)
    {
        string query = @"
            SELECT HoraIngreso, HoraSalida 
            FROM Control_asistencia 
            WHERE idPersonal = @idPersonal 
            AND FechaTrabajo = @fecha";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@idPersonal", SqlDbType.Int).Value = idPersonal;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime? horaIngreso = reader["HoraIngreso"] as DateTime?;
                            DateTime? horaSalida = reader["HoraSalida"] as DateTime?;

                            if (horaIngreso.HasValue && !horaSalida.HasValue)
                            {
                                return "En jornada";
                            }
                            else if (horaIngreso.HasValue && horaSalida.HasValue)
                            {
                                return "Finalizó jornada";
                            }
                        }
                    }
                }
            }
            return "Sin asistencia";
        }
        catch (SqlException ex)
        {
            throw new Exception($"Error al obtener estado de asistencia: {ex.Message}", ex);
        }
    }
}