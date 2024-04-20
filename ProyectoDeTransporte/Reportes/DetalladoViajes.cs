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
    public partial class DetalladoViajes : Form
    {
        public DetalladoViajes()
        {
            InitializeComponent();
        }
        public int id { get; set; }

        string sql;

        private void cargardatos()
        {
            //Carga dato generales
            sql = "select ID_Viaje, Registrado, Fecha, Transportista, Tarifa, Distancia_Total, Costo_Total from Viajes where ID_Viaje=@Id;";
            using (SqlCommand cmd=new SqlCommand(sql, conexion.Conectar()))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtid.Text = rd["ID_Viaje"].ToString();
                    txtreg.Text = rd["Registrado"].ToString();
                    txtfecha.Text = rd["Fecha"].ToString();
                    txttrans.Text = rd["Transportista"].ToString();
                    txttarifa.Text = rd["Tarifa"].ToString();
                    txtdist.Text = rd["Distancia_Total"].ToString();
                    txtCost.Text = rd["Costo_Total"].ToString();
                }
            }

            //Carga los colaboradores
            sql = "select Colaborador_1, Colaborador_2, Colaborador_3, Colaborador_4, Colaborador_5, Colaborador_6, Colaborador_7, Colaborador_8, Colaborador_9, Colaborador_10 from Viajes";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conexion.Conectar());
                DataTable dt = new DataTable();

                sda.Fill(dt);
                colabdgv.DataSource = dt;
                conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                conexion.desconectar();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DetalladoViajes_Load(object sender, EventArgs e)
        {
            cargardatos();
        }
    }
}
