using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjectPI_Building.Clases;

namespace ProjectPI_Building.Servicios
{
    internal class Connection_Compra
    {
        private string connectionString = "Server=ROG\\SQLEXPRESS;Database=BDBuilding3;User ID=sa;Password=1111;Encrypt=False;";

        public bool InsertarCompra(CCompra compra)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insertar en recibo_compra
                    string insertRecibo = "INSERT INTO Recibo_compra (idRecibocompra, fechaingreso, idProveedor) VALUES (@idRecibo, @fechaIngreso, @idProveedor)";
                    using (SqlCommand cmd = new SqlCommand(insertRecibo, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idRecibo", compra.IdReciboCompra);
                        cmd.Parameters.AddWithValue("@fechaIngreso", compra.FechaIngreso);
                        cmd.Parameters.AddWithValue("@idProveedor", compra.IdProveedor);
                        cmd.ExecuteNonQuery();
                    }

                    // Insertar en detalle_compra
                    string insertDetalle = "INSERT INTO Detalle_compra (idDetalle_compra, cantidadentrada, idProducto, idRecibocompra) VALUES (@idDetalle, @cantidadEntrada, @idProducto, @idRecibo)";
                    using (SqlCommand cmd = new SqlCommand(insertDetalle, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idDetalle", compra.IdDetalleCompra);
                        cmd.Parameters.AddWithValue("@cantidadEntrada", compra.CantidadEntrada);
                        cmd.Parameters.AddWithValue("@idProducto", compra.IdProducto);
                        cmd.Parameters.AddWithValue("@idRecibo", compra.IdReciboCompra);
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
    }
}
