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

        public bool InsertarCompra(CCompra compra)
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
                        cmd.Parameters.AddWithValue("@tipoRecibo", compra.TipoRecibo); // Se agrega tipoRecibo
                        cmd.Parameters.AddWithValue("@fechaIngreso", compra.FechaIngreso);
                        cmd.Parameters.AddWithValue("@idProveedor", compra.IdProveedor);
                        cmd.ExecuteNonQuery();
                    }

                    // Insertar en detalle_compra
                    string insertDetalle = "INSERT INTO Detalle_compra (idDetalle_compra, cantidadentrada, idProducto, idRecibocompra, subtotal, precioCompra, precioVenta) VALUES (@idDetalle, @cantidadEntrada, @idProducto, @idRecibo, @subtotal, @precioCompra, @precioVenta)";
                    using (SqlCommand cmd = new SqlCommand(insertDetalle, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idDetalle", compra.IdDetalleCompra);
                        cmd.Parameters.AddWithValue("@cantidadEntrada", compra.CantidadEntrada);
                        cmd.Parameters.AddWithValue("@idProducto", compra.IdProducto);
                        cmd.Parameters.AddWithValue("@idRecibo", compra.IdReciboCompra);
                        cmd.Parameters.AddWithValue("@subtotal", compra.Subtotal); // Se agrega subtotal
                        cmd.Parameters.AddWithValue("@precioCompra", compra.PrecioCompra); // Se agrega precioCompra
                        cmd.Parameters.AddWithValue("@precioVenta", compra.PrecioVenta); // Se agrega precioVenta
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

        public string GetNextReciboCompraId()
        {
            string nextId = "F0001"; // Valor por defecto
            try
            {
                string query = "SELECT TOP 1 idRecibocompra FROM Recibo_compra ORDER BY idRecibocompra DESC;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string currentId = result.ToString();
                        // Extraer el número del ID actual
                        int currentNumber = int.Parse(currentId.Substring(1)); // Ignora la 'F'
                        nextId = "F" + (currentNumber + 1).ToString("D4"); // Formato F000X
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
    }
}
