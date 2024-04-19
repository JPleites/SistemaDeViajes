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
    public partial class destinos : Form
    {
        public destinos()
        {
            InitializeComponent();
        }

        string sql;

        public void cargardatos()
        {
            sql = "Select * from AsigSucursales";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conexion.Conectar());
                DataTable dt = new DataTable();

                sda.Fill(dt);
                destdgv.DataSource = dt;
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
            comboBox1.ResetText();
            comboBox2.ResetText();
            distancia.ResetText();
        }

        //Se obtiene el ID del Colaborador
        private string ObIDColab(string colab)
        {
            using (conexion.Conectar())
            {
                string query = "SELECT ID FROM Colaboradores WHERE Nombre=@nombre";

                using (SqlCommand command = new SqlCommand(query, conexion.Conectar()))
                {
                    command.Parameters.AddWithValue("@nombre", colab);

                    object result = command.ExecuteScalar();
                    conexion.desconectar();

                    return result != null ? result.ToString() : null;
                }
            }
        }

        //Se obtiene el nombre del colaborador a partir del ID
        private string ObNomColab(long colab)
        {
            using (conexion.Conectar())
            {
                string query = "SELECT Nombre FROM Colaboradores WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, conexion.Conectar()))
                {
                    command.Parameters.AddWithValue("@id", colab);

                    object result = command.ExecuteScalar();
                    conexion.desconectar();

                    return result != null ? result.ToString() : null;
                }
            }
        }

        //Se obtiene el ID de la sucursal
        private string ObIDSuc(string sucu)
        {
            using (conexion.Conectar())
            {
                string query = "SELECT ID FROM Sucursales WHERE Sucursal=@suc";

                using (SqlCommand command = new SqlCommand(query, conexion.Conectar()))
                {
                    command.Parameters.AddWithValue("@suc", sucu);

                    object result = command.ExecuteScalar();
                    conexion.desconectar();

                    return result != null ? result.ToString() : null;
                }
            }
        }

        //Se obtiene el nombre de la sucursal a partir del ID
        private string ObNombreSuc(long sucu)
        {
            using (conexion.Conectar())
            {
                string query = "SELECT Sucursal FROM Sucursales WHERE ID=@suc";

                using (SqlCommand command = new SqlCommand(query, conexion.Conectar()))
                {
                    command.Parameters.AddWithValue("@suc", sucu);

                    object result = command.ExecuteScalar();
                    conexion.desconectar();

                    return result != null ? result.ToString() : null;
                }
            }
        }

        //Se verifica que la relación colaborador-sucursal no exista
        private bool verificacioncs(string col, string suc)
        {
            string consulta = "select * from AsigSucursales where ID_Colaborador=@cola and ID_Sucursal=@sucu";
            SqlCommand com = new SqlCommand(consulta, conexion.Conectar());
            com.Parameters.AddWithValue("cola", col);
            com.Parameters.AddWithValue("sucu", suc);
            SqlDataReader lector;
            lector = com.ExecuteReader();

            if (lector.HasRows == true)
            {
                MessageBox.Show("EL colaborador ya tiene asignada la sucursal");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void llenarcb()
        {
            //Llena el combobox de Colaboradores
            sql = "select Nombre from Colaboradores";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Nombre"].ToString());
            }
            dr.Close();
            conexion.desconectar();

            //Llena el combobox de Sucursales
            sql = "select Sucursal from Sucursales";
            SqlCommand cmd2 = new SqlCommand(sql, conexion.Conectar());
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2["Sucursal"].ToString());
            }
            dr2.Close();
            conexion.desconectar();
        }

        private void destinos_Load(object sender, EventArgs e)
        {
            cargardatos();
            llenarcb();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string Colaborador = ObIDColab(comboBox1.SelectedItem.ToString());
            string Sucursal = ObIDSuc(comboBox2.SelectedItem.ToString());
            if (distancia.Value>0 && distancia.Value < 50 && verificacioncs(Colaborador, Sucursal)!=false)
            {
                sql = "insert into AsigSucursales (ID_Colaborador, ID_Sucursal, Distancia) values (@col, @suc, @dis)";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
                cmd.Parameters.AddWithValue("@col", long.Parse(Colaborador));
                cmd.Parameters.AddWithValue("@suc", long.Parse(Sucursal));
                cmd.Parameters.AddWithValue("@dis", distancia.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Agregado Correctamente");
                cargardatos();
                limpiar();
            }
            else{
                MessageBox.Show("La distancia no puede ser 0 o mayor a 50");
            }
            
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            sql = "update AsigSucursales set ID_Colaborador=@col, ID_Sucursal=@suc, Distancia=@dis where ID_Colaborador=@col and ID_Sucursal=@suc";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@col", long.Parse(ObIDColab(comboBox1.SelectedItem.ToString())));
            cmd.Parameters.AddWithValue("@suc", long.Parse(ObIDSuc(comboBox2.SelectedItem.ToString())));
            cmd.Parameters.AddWithValue("@dis", distancia.Value);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Datos actualizados exitosamente");
            cargardatos();
            limpiar();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            sql = "delete from AsigSucursales where ID_Colaborador=@col and ID_Sucursal=@suc";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            cmd.Parameters.AddWithValue("@col", long.Parse(ObIDColab(comboBox1.SelectedItem.ToString())));
            cmd.Parameters.AddWithValue("@suc", long.Parse(ObIDSuc(comboBox2.SelectedItem.ToString())));

            DialogResult resultado = MessageBox.Show("¿Está seguro de borrar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eliminado exitosamente");
                cargardatos();
                limpiar();
            }
        }

        private void destdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedItem = ObNomColab(long.Parse(destdgv.CurrentRow.Cells[0].Value.ToString()));
            comboBox2.SelectedItem = ObNombreSuc(long.Parse(destdgv.CurrentRow.Cells[1].Value.ToString()));
            distancia.Value = decimal.Parse(destdgv.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
