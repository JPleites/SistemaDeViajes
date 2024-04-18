using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoDeTransporte
{
    public partial class Login : Form
    {
        private string ObtenerRol(string username, string password)
        {
            using (conexion.Conectar())
            {
                string query = "SELECT Rol FROM Usuario WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, conexion.Conectar()))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    object result = command.ExecuteScalar();
                    conexion.desconectar();

                    return result != null ? result.ToString() : null;
                }
            }
        }

        private string ObtenerNombre(string username, string password)
        {
            using (conexion.Conectar())
            {
                string query = "SELECT Nombre FROM Usuario WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, conexion.Conectar()))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    object result = command.ExecuteScalar();
                    conexion.desconectar();

                    return result != null ? result.ToString() : null;
                }
            }
        }

        private void MostrarPantallaSegunRol(string role)
        {
            switch (role)
            {
                case "admin":
                    admin admin = new admin();
                    admin.NombreUsuario = ObtenerNombre(textBox1.Text, textBox2.Text);
                    admin.Show();
                    break;
                case "supervisor":
                    reportes sup = new reportes();
                    sup.Show();
                    break;
                default:
                    MessageBox.Show("Rol de usuario no válido.");
                    break;
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string consulta = "select * from Usuario where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
            SqlCommand com = new SqlCommand(consulta, conexion.Conectar());
            SqlDataReader lector;
            lector = com.ExecuteReader();

            if(lector.HasRows == true)
            {
                MessageBox.Show("Bienvenido");
                this.Hide();
                string rol = ObtenerRol(textBox1.Text, textBox2.Text);
                MostrarPantallaSegunRol(rol);
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
            conexion.desconectar();
        }
    }
}
