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
    internal class Connection_Compra
    {
        private string connectionString;
        public Connection_Compra()
        {
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;
        }

        public bool InsertarCompra(CReciboCompra compra, List<CDetalleCompra> detallesCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insertar en recibo_compra
                    string insertRecibo = "INSERT INTO Recibo_compra (idRecibocompra, tipoRecibo, fechaingreso, idProveedor) VALUES (@idRecibo, @tipoRecibo, @fechaIngreso, @idProveedor)";
                    using (SqlCommand cmd = new SqlCommand(insertRecibo, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idRecibo", compra.IdReciboCompra);
                        cmd.Parameters.AddWithValue("@tipoRecibo", compra.TipoRecibo);
                        cmd.Parameters.AddWithValue("@fechaIngreso", compra.FechaIngreso);
                        cmd.Parameters.AddWithValue("@idProveedor", compra.IdProveedor);
                        cmd.ExecuteNonQuery();
                    }

                    // Insertar en detalle_compra (iterar sobre la lista de detalles)
                    string insertDetalle = "INSERT INTO Detalle_compra (idDetalle_compra, cantidadentrada, idProducto, idRecibocompra, subtotal, precioCompra, precioVenta) VALUES (@idDetalle, @cantidadEntrada, @idProducto, @idRecibo, @subtotal, @precioCompra, @precioVenta)";
                    foreach (CDetalleCompra detalle in detallesCompra)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertDetalle, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@idDetalle", detalle.IdDetalleCompra);
                            cmd.Parameters.AddWithValue("@cantidadEntrada", detalle.CantidadEntrada);
                            cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmd.Parameters.AddWithValue("@idRecibo", compra.IdReciboCompra); // Usar el IdReciboCompra del objeto CCompra
                            cmd.Parameters.AddWithValue("@subtotal", detalle.Subtotal);
                            cmd.Parameters.AddWithValue("@precioCompra", detalle.PrecioCompra);
                            cmd.Parameters.AddWithValue("@precioVenta", detalle.PrecioVenta);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Commit de la transacción
                    transaction.Commit();
                    return true; // Indica que la operación fue exitosa
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción si ocurre un error
                    transaction.Rollback();
                    MessageBox.Show("Error al registrar la compra: " + ex.Message);
                    return false; // Indica que hubo un error
                }
            }
        }

        public int count_detalle_compra()
        {
            int count = 0;
            try
            {
                string query = "SELECT TOP 1 idDetalle_compra FROM Detalle_compra ORDER BY idDetalle_compra DESC;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count != null)
                    {

                        count = count + 1;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                count = -1;
            }
            return count;
        }

        public string ObtenerNextIdReciboCompra_Factura()
        {
            string nextId = "FC0001"; // Valor por defecto
            try
            {
                string query = "SELECT TOP 1 idRecibocompra FROM Recibo_compra WHERE idRecibocompra like 'FC%' ORDER BY idRecibocompra DESC;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string currentId = result.ToString();
                        // Extraer el número del ID actual
                        int currentNumber = int.Parse(currentId.Substring(2)); // Ignora la 'FC'
                        nextId = "FC" + (currentNumber + 1).ToString("D4"); // Formato FC000X
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                nextId = null; // O manejar el error de otra forma
            }
            return nextId;
        }

        public string ObtenerNextIdReciboCompra_Boleta()
        {
            string nextId = "BC0001"; // Valor por defecto
            try
            {
                string query = "SELECT TOP 1 idRecibocompra FROM Recibo_compra WHERE idRecibocompra like 'BC%' ORDER BY idRecibocompra DESC;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string currentId = result.ToString();
                        // Extraer el número del ID actual
                        int currentNumber = int.Parse(currentId.Substring(2)); // Ignora la 'BC'
                        nextId = "BC" + (currentNumber + 1).ToString("D4"); // Formato BC000X
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                nextId = null; // O manejar el error de otra forma
            }
            return nextId;
        }

        public DataSet fillRecibo(List<string> listaIdReciboCompra)
        {
            DataSet dataSet = new DataSet();
            try
            {
                // Construir la consulta SQL parametrizada
                StringBuilder queryBuilder = new StringBuilder("SELECT rc.idRecibocompra as Nro_Recibo,rc.tipoRecibo as Tipo_Recibo,rc.fechaingreso as Fecha_Ingreso,pr.nombre as Proveedor,pr.Nrodocumento as Nro_documento, p.categoria as Producto_Categoria, p.descripcion as Producto_Descripcion, dc.cantidadentrada as Cantidad_Comprada, dc.precioCompra as PrecioCompra, dc.precioVenta as Precio_Venta, dc.subtotal\r\nFROM Detalle_compra dc inner join Recibo_compra rc on dc.idRecibocompra=rc.idRecibocompra\r\ninner join Producto p on dc.idProducto=p.idProducto \r\ninner join Proveedor pr on rc.idProveedor=pr.idProveedor\r\nWHERE rc.idRecibocompra  IN (");
                for (int i = 0; i < listaIdReciboCompra.Count; i++)
                {
                    queryBuilder.Append("@id" + i);
                    if (i < listaIdReciboCompra.Count - 1)
                    {
                        queryBuilder.Append(",");
                    }
                }
                queryBuilder.Append(")");
                string query = queryBuilder.ToString();

                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // Añadir parámetros
                    for (int i = 0; i < listaIdReciboCompra.Count; i++)
                    {
                        command.Parameters.AddWithValue("@id" + i, listaIdReciboCompra[i]);
                    }

                    adapter.Fill(dataSet, "ReciboCompra");
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
                return null;
            }
        }

        public bool DeleteCompra(string idReciboCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Eliminar primero de Detalle_compra
                    string deleteDetalle = "DELETE FROM Detalle_compra WHERE idRecibocompra = @idRecibo";
                    using (SqlCommand cmd = new SqlCommand(deleteDetalle, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idRecibo", idReciboCompra);
                        cmd.ExecuteNonQuery();
                    }

                    // Eliminar de Recibo_compra
                    string deleteRecibo = "DELETE FROM Recibo_compra WHERE idRecibocompra = @idRecibo";
                    using (SqlCommand cmd = new SqlCommand(deleteRecibo, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idRecibo", idReciboCompra);
                        cmd.ExecuteNonQuery();
                    }

                    // Commit de la transacción
                    transaction.Commit();
                    return true; // Indica que la operación fue exitosa
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción si ocurre un error
                    transaction.Rollback();
                    MessageBox.Show("Error al eliminar la compra: " + ex.Message);
                    return false; // Indica que hubo un error
                }
            }
        }

        public Dictionary<string, object> ObtenerDatosReciboCompraPorId(string idReciboCompra)
        {
            Dictionary<string, object> resultados = new Dictionary<string, object>();

            try
            {
                string query = @"
            SELECT 
                rc.idRecibocompra as Nro_Recibo,
                rc.tipoRecibo as Tipo_Recibo,
                rc.fechaingreso as Fecha_Ingreso,
                pr.nombre as Proveedor,
                pr.Nrodocumento as Nro_documento 
            FROM Recibo_compra rc 
            INNER JOIN Proveedor pr ON rc.idProveedor = pr.idProveedor
            WHERE rc.idRecibocompra = @idReciboCompra";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idReciboCompra", idReciboCompra);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                resultados["Nro_Recibo"] = reader["Nro_Recibo"];
                                resultados["Tipo_Recibo"] = reader["Tipo_Recibo"];
                                resultados["Fecha_Ingreso"] = reader["Fecha_Ingreso"];
                                resultados["Proveedor"] = reader["Proveedor"];
                                resultados["Nro_documento"] = reader["Nro_documento"];
                            }
                            else
                            {
                                // No se encontraron resultados para el idReciboCompra dado
                                // Puedes decidir cómo manejar esto, por ejemplo, lanzar una excepción
                                // o retornar null/un diccionario vacío.  En este caso, retornaremos un diccionario vacío.
                                resultados.Clear(); // Aseguramos que esté vacío si no hay resultados
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes personalizar esto)
                Console.WriteLine("Error al obtener datos del recibo de compra: " + ex.Message);
                // También podrías lanzar la excepción o registrarla.
                resultados.Clear(); // Aseguramos que esté vacío en caso de error.  O podrías retornar null.
            }

            return resultados;
        }

        public DataSet ObtenerDetallesCompraPorIdRecibo(string idReciboCompra)
        {
            DataSet dataSet = new DataSet();

            try
            {
                string query = @"
            SELECT 
                p.categoria as Producto_Categoria, 
                p.descripcion as Producto_Descripcion, 
                dc.cantidadentrada as Cantidad_Comprada, 
                dc.precioCompra as PrecioCompra, 
                dc.precioVenta as Precio_Venta, 
                dc.subtotal as Subtotal
            FROM Detalle_compra dc 
            INNER JOIN Recibo_compra rc ON dc.idRecibocompra = rc.idRecibocompra
            INNER JOIN Producto p ON dc.idProducto = p.idProducto 
            INNER JOIN Proveedor pr ON rc.idProveedor = pr.idProveedor
            WHERE rc.idRecibocompra = @idReciboCompra";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idReciboCompra", idReciboCompra);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet);  //Llena el DataSet con los resultados de la consulta
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Manejo de excepciones (puedes personalizar esto)
                Console.WriteLine("Error al obtener detalles de compra: " + ex.Message);
                //También podrías lanzar la excepción o registrarla.
                dataSet = null; //Retornar null en caso de error
            }

            return dataSet;
        }


        //REPORTE RECIBO COMPRA
        public DataSet FillReciboByDateRange(DateTime fechaInicio, DateTime fechaFin, string tipoRecibo)
        {
            string fecha_inicio = fechaInicio.ToString("yyyy-MM-dd");
            string fecha_final = fechaFin.ToString("yyyy-MM-dd");
            DataSet dataSet = new DataSet();
            try
            {
                // Construir la consulta SQL parametrizada
                string query = @"SELECT rc.idRecibocompra as Nro_Compra, p.nombre as Nombre_Proveedor, p.Nrodocumento as Documento, rc.fechaingreso as Fecha
                                FROM Recibo_compra rc inner join Proveedor p on rc.idProveedor=p.idProveedor
                                WHERE CONVERT(DATE, rc.fechaingreso) >= @fechaInicio AND CONVERT(DATE, rc.fechaingreso) <= @fechaFin AND rc.tipoRecibo=@tipoRecibo";

                // Conexión y llenado del DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // Añadir parámetros
                    command.Parameters.AddWithValue("@fechaInicio", fecha_inicio);
                    command.Parameters.AddWithValue("@fechaFin", fecha_final);
                    command.Parameters.AddWithValue("@tipoRecibo", tipoRecibo);

                    adapter.Fill(dataSet, "ReciboCompra");
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
