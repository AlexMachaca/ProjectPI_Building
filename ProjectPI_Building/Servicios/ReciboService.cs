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
    public class ReciboService
    {
        private string connectionString;
        public ReciboService()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }

        public string ConnectionString => connectionString;


        // Insertar el recibo principal con transacción
        public int InsertarRecibo(CRecibo nuevoRecibo, SqlTransaction transaction)
        {
            try
            {
                string query = "INSERT INTO Recibo (idRecibo, tipoRecibo, idSucursal, fechaemision, hora, Totalgravado, IGV, Total, TotalLetras, Formapago, idPersonal, tipomoneda, idCliente, NroRecibo, tipoServicio) " +
                               "VALUES (@idRecibo, @tipoRecibo, @idSucursal, @fechaemision, @hora, @Totalgravado, @IGV, @Total, @TotalLetras, @Formapago, @idPersonal, @tipomoneda, @idCliente, @NroRecibo, @tipoServicio)";
                using (SqlCommand command = new SqlCommand(query, transaction.Connection, transaction))
                {
                    command.Parameters.AddWithValue("@idRecibo", nuevoRecibo.IdRecibo);
                    command.Parameters.AddWithValue("@tipoRecibo", nuevoRecibo.TipoRecibo);
                    command.Parameters.AddWithValue("@idSucursal", nuevoRecibo.IdSucursal);
                    command.Parameters.AddWithValue("@fechaemision", nuevoRecibo.FechaEmision);
                    command.Parameters.AddWithValue("@hora", nuevoRecibo.Hora);
                    command.Parameters.AddWithValue("@Totalgravado", nuevoRecibo.TotalGravado);
                    command.Parameters.AddWithValue("@IGV", nuevoRecibo.IGV);
                    command.Parameters.AddWithValue("@Total", nuevoRecibo.Total);
                    command.Parameters.AddWithValue("@TotalLetras", nuevoRecibo.TotalLetras);
                    command.Parameters.AddWithValue("@Formapago", nuevoRecibo.FormaPago);
                    command.Parameters.AddWithValue("@idPersonal", nuevoRecibo.IdPersonal);
                    command.Parameters.AddWithValue("@tipomoneda", nuevoRecibo.TipoMoneda);
                    command.Parameters.AddWithValue("@idCliente", nuevoRecibo.IdCliente);
                    command.Parameters.AddWithValue("@NroRecibo", nuevoRecibo.NroRecibo);
                    command.Parameters.AddWithValue("@tipoServicio", nuevoRecibo.TipoServicio);

                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el recibo: " + ex.Message);
                return 0; // Devuelve 0 si hubo un error
            }
        }
        // Insertar el detalle del recibo con transacción
        public int InsertarDetalleRecibo(CDetalleRecibo detalle, SqlTransaction transaction)
        {
            try
            {
                string query = "INSERT INTO Detalle_recibo (idDetallerecibo, cantidad, subtotal, idRecibo, tipoproductoservicio, codigo, precioVenta) " +
                               "VALUES (@idDetallerecibo, @cantidad, @subtotal, @idRecibo, @tipoproductoservicio, @codigo, @precioVenta)";
                using (SqlCommand command = new SqlCommand(query, transaction.Connection, transaction))
                {
                    command.Parameters.AddWithValue("@idDetallerecibo", detalle.IdDetalleRecibo);
                    command.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    command.Parameters.AddWithValue("@subtotal", detalle.Subtotal);
                    command.Parameters.AddWithValue("@idRecibo", detalle.IdRecibo);
                    command.Parameters.AddWithValue("@tipoproductoservicio", detalle.TipoProductoServicio);
                    command.Parameters.AddWithValue("@codigo", detalle.Codigo);
                    command.Parameters.AddWithValue("@precioVenta", detalle.PrecioVenta);

                    int result = command.ExecuteNonQuery();
                    return result > 0 ? 1 : 0; // Devuelve 1 si se realizó correctamente, 0 si hubo error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el detalle del recibo: " + ex.Message);
                return 0; // Devuelve 0 si hubo un error
            }
        }

        public int ObtenerUltimoNumero(string tipoRecibo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT UltimoNumero FROM ReciboNumeracion WHERE TipoRecibo = @TipoRecibo", connection);
                command.Parameters.AddWithValue("@TipoRecibo", tipoRecibo);
                var result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0; // Retorna 0 si no existe
            }
        }

        public void ActualizarUltimoNumero(string tipoRecibo, int nuevoNumero)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("IF EXISTS (SELECT * FROM ReciboNumeracion WHERE TipoRecibo = @TipoRecibo) " +
                                              "UPDATE ReciboNumeracion SET UltimoNumero = @NuevoNumero WHERE TipoRecibo = @TipoRecibo " +
                                              "ELSE INSERT INTO ReciboNumeracion (TipoRecibo, UltimoNumero) VALUES (@TipoRecibo, @NuevoNumero)", connection);
                command.Parameters.AddWithValue("@TipoRecibo", tipoRecibo);
                command.Parameters.AddWithValue("@NuevoNumero", nuevoNumero);
                command.ExecuteNonQuery();
            }
        }

        public string GenerarNumeroRecibo(string tipoRecibo)
        {
            string prefijo = tipoRecibo == "Boleta" ? "BV-" : "FV-";
            int ultimoNumero = ObtenerUltimoNumero(tipoRecibo);
            int nuevoNumero = ultimoNumero + 1;

            // Actualizar el último número en la base de datos
            ActualizarUltimoNumero(tipoRecibo, nuevoNumero);

            // Formatear el número de recibo
            return prefijo + nuevoNumero.ToString("D4"); // Formato con ceros a la izquierda
        }

        public bool ActualizarStockProducto(int idProducto, int cantidadVendida, SqlTransaction transaction)
        {
            try
            {
                string query = "UPDATE Producto SET stock = stock - @cantidadVendida WHERE idProducto = @idProducto";
                using (SqlCommand command = new SqlCommand(query, transaction.Connection, transaction))
                {
                    command.Parameters.AddWithValue("@cantidadVendida", cantidadVendida);
                    command.Parameters.AddWithValue("@idProducto", idProducto);

                    int result = command.ExecuteNonQuery();
                    return result > 0; // Devuelve true si la actualización fue exitosa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el stock del producto: " + ex.Message);
                return false;
            }
        }

        public bool VerificarStockDisponible(int idProducto, int cantidadRequerida, SqlTransaction transaction)
        {
            try
            {
                string query = "SELECT stock FROM Producto WHERE idProducto = @idProducto";
                using (SqlCommand command = new SqlCommand(query, transaction.Connection, transaction))
                {
                    command.Parameters.AddWithValue("@idProducto", idProducto);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        int stockActual = Convert.ToInt32(result);
                        return stockActual >= cantidadRequerida; // Devuelve true si hay suficiente stock
                    }
                    return false; // Si no se encuentra el producto, asumimos que no hay stock
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el stock del producto: " + ex.Message);
                return false;
            }
        }


        public DataTable ObtenerReportes(DateTime fechaInicio, DateTime fechaFin, string tipoRecibo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Recibo WHERE fechaemision BETWEEN @fechaInicio AND @fechaFin";
                if (!string.IsNullOrEmpty(tipoRecibo))
                {
                    query += " AND tipoRecibo = @tipoRecibo";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);
                    if (!string.IsNullOrEmpty(tipoRecibo))
                    {
                        command.Parameters.AddWithValue("@tipoRecibo", tipoRecibo);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

    }
}
