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
    public partial class Colaborador : Form
    {
        public Colaborador()
        {
            InitializeComponent();
        }

        string sql;

        public void cargardatos()
        {
            sql = "Select * from Colaboradores";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conexion.Conectar());
                DataTable dt = new DataTable();

                sda.Fill(dt);
                colabdgv.DataSource = dt;
                conexion.desconectar();
            }
            catch(Exception e)
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

        private void addbtn_Click(object sender, EventArgs e)
        {
            sql = "insert into Colaboradores (ID, Nombre) values (@id, @nombre)";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", long.Parse(txtid.Text));
            cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Agregado Correctamente");
            cargardatos();
            limpiar();
        }

        private void colabdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = colabdgv.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = colabdgv.CurrentRow.Cells[1].Value.ToString();
        }

        private void colabdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = colabdgv.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = colabdgv.CurrentRow.Cells[1].Value.ToString();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            sql = "update Colaboradores set ID=@id, nombre=@nombre where ID=@id";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", long.Parse(txtid.Text));
            cmd.Parameters.AddWithValue("@nombre", txtnombre.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Datos actualizados exitosamente");
            cargardatos();
            limpiar();
        }
        
        private void deletebtn_Click(object sender, EventArgs e)
        {
            sql = "delete from Colaboradores where ID=@id";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", long.Parse(txtid.Text));

            DialogResult resultado = MessageBox.Show("¿Está seguro de borrar a "+txtnombre.Text+"?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eliminado exitosamente");
                cargardatos();
                limpiar();
            }
        }
    }
}
