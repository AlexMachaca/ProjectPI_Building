using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPI_Building.Clases;
using ProjectPI_Building.Servicios;

namespace ProjectPI_Building.Forms_Register
{
    public partial class Frm_Producto_Register : Frm_Template_Register
    {
        public int option { get; set; }
        private Connection_Producto con = new Connection_Producto();
        public Frm_Producto_Register()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            if (option == 0)
            {
                generateID();
            }
        }

        public void generateID()
        {
            int count = con.count_product();
            txt_id.Text = count.ToString();
        }

        public void filldata(CProducto1 producto)
        {
            txt_id.Text = producto.IdProducto.ToString();
            cb_categoria.SelectedItem = producto.Categoria;
            txt_descripcion.Text = producto.Descripcion;
            cb_unidad.SelectedItem = producto.Unidad;
            txt_cantidad.Text = producto.Cantidad.ToString();
            txt_stock.Text = producto.Stock.ToString();
            txt_precio_compra.Text = producto.PrecioCompra.ToString();
            txt_precio_venta.Text = producto.PrecioVenta.ToString();
            txt_precio_unitario.Text = producto.PrecioUnitario.ToString();
            dtp_fecha_actualizacion.Value = DateTime.Parse(producto.FechaActualizacion.ToString());

        }

        private void Frm_Producto_Register_Load(object sender, EventArgs e)
        {
            if (option == 0)
            {
                generateID();
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string idp = txt_id.Text.Trim();
            string categoria = cb_categoria.SelectedItem.ToString();
            string descripcion = txt_descripcion.Text.Trim();
            string unidad = cb_unidad.SelectedItem.ToString();
            string cantidadp = txt_cantidad.Text.Trim();
            string stockp = txt_stock.Text.Trim();
            string preciocomprap = txt_precio_compra.Text.Trim();
            string precioventap = txt_precio_venta.Text.Trim();//trim elimina los espacios en blanco
            string preciounitariop = txt_precio_unitario.Text.ToString();
            if (string.IsNullOrEmpty(idp) ||
                string.IsNullOrEmpty(categoria) ||
                string.IsNullOrEmpty(descripcion) ||
                string.IsNullOrEmpty(unidad) ||
                string.IsNullOrEmpty(cantidadp) ||
                string.IsNullOrEmpty(stockp) ||
                string.IsNullOrEmpty(preciocomprap) ||
                string.IsNullOrEmpty(precioventap) ||
                string.IsNullOrEmpty(preciounitariop))
            {
                MessageBox.Show("Por favor, llene todos los campos.");
                return;
            }

            int id;
            int cantidad;
            int stock;
            float preciocompra;
            float precioventa;
            float preciounitario;

            try
            {
                // Validar y convertir id
                id = int.Parse(idp);

                // Validar y convertir cantidad
                cantidad = int.Parse(cantidadp);

                // Validar y convertir stock
                stock = int.Parse(stockp);

                // Validar y convertir precio de compra
                preciocompra = float.Parse(preciocomprap, CultureInfo.InvariantCulture);

                // Validar y convertir precio de venta
                precioventa = float.Parse(precioventap, CultureInfo.InvariantCulture);

                // Validar y convertir precio unitario
                preciounitario = float.Parse(preciounitariop, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show("Uno o más campos tienen un formato inválido.");
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Uno o más campos tienen un valor fuera del rango permitido.");
                return;
            }

            DateTime fechaactualizacion = dtp_fecha_actualizacion.Value;
                

            CProducto1 producto = new CProducto1();
            producto.IdProducto = id;
            producto.Categoria = categoria;
            producto.Descripcion = descripcion;
            producto.Unidad = unidad;
            producto.Cantidad = cantidad;
            producto.Stock = stock;
            producto.PrecioCompra = preciocompra;
            producto.PrecioVenta = precioventa;
            producto.PrecioUnitario = preciounitario;
            producto.FechaActualizacion = fechaactualizacion;

            if (option == 0)
            {
                //Conection con = new Conection();
                if (con.insert_producto(producto) == 1)
                {
                    MessageBox.Show("Se Agrego un nuevo registro ");
                    this.DialogResult = DialogResult.OK; // Establecer resultado del diálogo como OK
                    this.Close(); // Cerrar el formulario
                }
                else
                {
                    MessageBox.Show("Error en la insercion ");
                }
            }
            else if (option == 1)
            {
                if (con.update_producto(producto) == 1)
                {
                    MessageBox.Show("Se modifico un registro ");
                    this.DialogResult = DialogResult.OK; // Establecer resultado del diálogo como OK
                    this.Close(); // Cerrar el formulario
                }
                else
                {
                    MessageBox.Show("Error en la modificacion ");
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
