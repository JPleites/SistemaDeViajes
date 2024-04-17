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
                supervisor inicio = new supervisor();
                this.Hide();
                inicio.Show();
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
            conexion.desconectar();
        }
    }
}
