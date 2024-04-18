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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        public string NombreUsuario { get; set; }

        private void admin_Load(object sender, EventArgs e)
        {
            label1.Text = NombreUsuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paneladmin.Controls.Clear();
            gtienda.sucursal sucursal = new gtienda.sucursal();
            sucursal.TopLevel = false;
            sucursal.Parent = paneladmin;
            sucursal.Dock = DockStyle.Fill;
            paneladmin.Controls.Add(sucursal);
            sucursal.MinimizeBox = false;
            sucursal.MaximizeBox = false;
            sucursal.ControlBox = false;
            sucursal.Show();
        }

        private void colaboradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paneladmin.Controls.Clear();
            gtienda.Colaborador colab = new gtienda.Colaborador();
            colab.TopLevel = false;
            colab.Parent = paneladmin;
            colab.Dock = DockStyle.Fill;
            paneladmin.Controls.Add(colab);
            colab.MinimizeBox = false;
            colab.MaximizeBox = false;
            colab.ControlBox = false;
            colab.Show();
        }

        private void transportistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paneladmin.Controls.Clear();
            gtienda.Transportista trans = new gtienda.Transportista();
            trans.TopLevel = false;
            trans.Parent = paneladmin;
            trans.Dock = DockStyle.Fill;
            paneladmin.Controls.Add(trans);
            trans.MinimizeBox = false;
            trans.MaximizeBox = false;
            trans.ControlBox = false;
            trans.Show();
        }

        private void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paneladmin.Controls.Clear();
            gtienda.Viajes viaje= new gtienda.Viajes();
            viaje.TopLevel = false;
            viaje.Parent = paneladmin;
            viaje.Dock = DockStyle.Fill;
            paneladmin.Controls.Add(viaje);
            viaje.MinimizeBox = false;
            viaje.MaximizeBox = false;
            viaje.ControlBox = false;
            viaje.Show();
        }
    }
}
