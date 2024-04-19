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
    public partial class sucursal : Form
    {
        public sucursal()
        {
            InitializeComponent();
        }

        string sql;

        public void cargardatos()
        {
            sql = "Select * from Sucursales";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conexion.Conectar());
                DataTable dt = new DataTable();

                sda.Fill(dt);
                sucdgv.DataSource = dt;
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
        private void Colaborador_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void sucursal_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            sql = "insert into Sucursales (ID, Sucursal) values (@id, @suc)";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", long.Parse(txtid.Text));
            cmd.Parameters.AddWithValue("@suc", txtnombre.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Agregado Correctamente");
            cargardatos();
            limpiar();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            sql = "update Sucursales set ID=@id, Sucursal=@suc where ID=@id";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", long.Parse(txtid.Text));
            cmd.Parameters.AddWithValue("@suc", txtnombre.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Datos actualizados exitosamente");
            cargardatos();
            limpiar();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            sql = "delete from Sucursales where ID=@id";
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

        private void sucdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = sucdgv.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = sucdgv.CurrentRow.Cells[1].Value.ToString();
        }

        private void sucdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
