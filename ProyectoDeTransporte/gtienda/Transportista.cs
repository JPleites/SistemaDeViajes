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

namespace ProyectoDeTransporte.gtienda
{
    public partial class Transportista : Form
    {
        public Transportista()
        {
            InitializeComponent();
        }

        string sql;

        public void cargardatos()
        {
            sql = "Select * from Transportistas";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conexion.Conectar());
                DataTable dt = new DataTable();

                sda.Fill(dt);
                transdgv.DataSource = dt;
                conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                conexion.desconectar();
            }
        }
        public void limpiar()
        {
            txtid.Text = "";
            txtnombre.Text = "";
        }

        private void Transportista_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            sql = "insert into Transportistas (ID, Nombre, Tarifa) values (@id, @nombre, @tarifa)";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", long.Parse(txtid.Text));
            cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
            cmd.Parameters.AddWithValue("@tarifa", txttarifa.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Agregado Correctamente");
            cargardatos();
            limpiar();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            sql = "update Transportistas set ID=@id, nombre=@nombre, tarifa=@tarifa where ID=@id";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", long.Parse(txtid.Text));
            cmd.Parameters.AddWithValue("@nombre", txtnombre.Text);
            cmd.Parameters.AddWithValue("@tarifa", txttarifa.Value);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Datos actualizados exitosamente");
            cargardatos();
            limpiar();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            sql = "delete from Transportistas where ID=@id";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", long.Parse(txtid.Text));

            DialogResult resultado = MessageBox.Show("¿Está seguro de borrar a " + txtnombre.Text + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eliminado exitosamente");
                cargardatos();
                limpiar();
            }
        }

        private void transdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void transdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = transdgv.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = transdgv.CurrentRow.Cells[1].Value.ToString();
            txttarifa.Value = decimal.Parse(transdgv.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
