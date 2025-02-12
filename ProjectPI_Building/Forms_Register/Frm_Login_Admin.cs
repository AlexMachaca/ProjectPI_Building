using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProjectPI_Building.Forms_Register
{
    public partial class Frm_Login_Admin : Form
    {
        public string NameUser { get; set; }

        private string connectionString;
        public Frm_Login_Admin()
        {
            InitializeComponent();
            // Obtener la cadena de conexión desde AppConfig
            connectionString = AppConfig.ConnectionString;

            // Configurar el TextBox para contraseñas
            txt_contrasenia.PasswordChar = '*'; // Muestra asteriscos en lugar de caracteres

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string usuario = txt_usuario.Text.Trim();
            string contrasenia = txt_contrasenia.Text.Trim();

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.");
                return;
            }

            // Consulta SQL para verificar el usuario y contraseña
            string query = "SELECT COUNT(*) FROM Personal WHERE usuario = @usuario AND pasword = @contrasenia AND categoria = 'Administrativo'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contrasenia", contrasenia);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        DialogResult = DialogResult.OK;
                        NameUser = usuario;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos, o no pertenece a la categoría 'Administrativo'.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}");
                }
            }
        }

        private void btn_togglePassword_Click(object sender, EventArgs e)
        {
            // Alternar visibilidad de la contraseña
            if (txt_contrasenia.PasswordChar == '*')
            {
                txt_contrasenia.PasswordChar = '\0'; // Muestra el texto
                btn_togglePassword.Text = "Ocultar"; // Cambia el texto del botón
            }
            else
            {
                txt_contrasenia.PasswordChar = '*'; // Oculta el texto
                btn_togglePassword.Text = "Mostrar"; // Cambia el texto del botón
            }
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
