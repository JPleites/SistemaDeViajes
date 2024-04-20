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

namespace ProyectoDeTransporte.Reportes
{
    public partial class ReporteViajes : Form
    {
        public ReporteViajes()
        {
            InitializeComponent();
        }

        string sql;

        public void cargardatos()
        {
            sql = "select ID_Viaje as 'ID Viaje', Transportista, Costo_Total as 'Costo del Viaje', Fecha from Viajes";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conexion.Conectar());
                DataTable dt = new DataTable();

                sda.Fill(dt);
                reporte.DataSource = dt;
                conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                conexion.desconectar();
            }
        }

        private void llenarcb()
        {
            sql = "select Nombre from Transportistas";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbfiltrans.Items.Add(dr["Nombre"].ToString());
            }
            dr.Close();
            conexion.desconectar();
        }

        private void total()
        {
            long total = 0;
            foreach (DataGridViewRow fila in reporte.Rows)
            {
                
                if (!fila.IsNewRow && fila.Cells[3].Value != null)
                {
                    long valorCelda = long.Parse(fila.Cells[2].Value.ToString());

                    total += valorCelda;
                }
            }
            txttotal.Text = total.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lgtbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void ReporteViajes_Load(object sender, EventArgs e)
        {
            llenarcb();
            cargardatos();
            total();
        }

        private void reporte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Reportes.DetalladoViajes dv = new Reportes.DetalladoViajes();
            dv.id = int.Parse(reporte.CurrentRow.Cells[0].Value.ToString());
            dv.Show();
        }

        private void cleanbtn_Click(object sender, EventArgs e)
        {
            cargardatos();
            cbfiltrans.SelectedItem = null;
            fechafin.ResetText();
            fechaini.ResetText();
            total();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (cbfiltrans.SelectedItem != null)
            {
                sql = "Select ID_Viaje as 'ID Viaje', Transportista, Costo_Total as 'Costo del Viaje', Fecha from Viajes where Transportista = '" + cbfiltrans.SelectedItem.ToString()+"' and Fecha>='"+fechaini.Value.ToString("yyyy-MM-dd") +"' and Fecha<='"+fechafin.Value.ToString("yyyy-MM-dd") +"'";

                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conexion.Conectar());
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    reporte.DataSource = dt;
                    conexion.desconectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conexion.desconectar();
                }
            }
            else if (cbfiltrans.SelectedItem == null)
            {
                sql = "Select ID_Viaje as 'ID Viaje', Transportista, Costo_Total as 'Costo del Viaje', Fecha from Viajes where Fecha>='" + fechaini.Value.ToString("yyyy-MM-dd") + "' and Fecha<='" + fechafin.Value.ToString("yyyy-MM-dd") + "'";

                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conexion.Conectar());
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    reporte.DataSource = dt;
                    conexion.desconectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conexion.desconectar();
                }
            }
            else
            {
                MessageBox.Show("Campos de busqueda vacíos");
            }
            total();
        }
    }
}
