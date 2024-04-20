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
using System.Collections;

namespace ProyectoDeTransporte.gtienda
{
    public partial class Viajes : Form
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public long Distancia { get; set; }

        public string trans { get; set; }
        public string tar { get; set; }

        public Viajes()
        {
            InitializeComponent();
        }
        public Viajes(long id, string nombre, long dist)
        {
            Id = id;
            Nombre = nombre;
            Distancia = dist;
        }

        public Viajes(string tr, string ta)
        {
            trans = tr;
            tar = ta;
        }

        public string registrador { get; set; }

        string sql;

        long dtotal=0;

        private void llenarcb(ComboBox cb)
        {
            //Llena el combobox
            sql = "SELECT a.ID_Colaborador AS ID_Colaborador, c.nombre AS Nombre, a.Distancia AS Distancia FROM colaboradores c INNER JOIN AsigSucursales a ON c.id = a.ID_Colaborador;";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            SqlDataReader dr = cmd.ExecuteReader();

            List<Viajes> listaColaboradores = new List<Viajes>();
            listaColaboradores.Add(new Viajes(0,"",0));

            while (dr.Read())
            {
                long id = long.Parse(dr["ID_Colaborador"].ToString());
                string nombre = dr["Nombre"].ToString();
                long dist = long.Parse(dr["Distancia"].ToString());
                listaColaboradores.Add(new Viajes(id, nombre, dist));
            }
            cb.DataSource = listaColaboradores;
            cb.DisplayMember = "Nombre";
            dr.Close();
        }

        private void llenarcbt(ComboBox cb)
        {
            sql = "select Nombre from Transportistas";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cb.Items.Add(dr["Nombre"].ToString());
            }
            dr.Close();
            conexion.desconectar();
        }

        private string bustrans(string trans)
        {
            using (conexion.Conectar())
            {
                string query = "SELECT Tarifa FROM Transportistas WHERE nombre=@nom";

                using (SqlCommand command = new SqlCommand(query, conexion.Conectar()))
                {
                    command.Parameters.AddWithValue("@nom", trans);

                    object result = command.ExecuteScalar();
                    conexion.desconectar();

                    return result != null ? result.ToString() : null;
                }
            }
        }

        private void suma(long d)
        {
            dtotal = dtotal + d;
            txtdist.Text = dtotal.ToString();
        }

        private long distancia(ComboBox cb)
        {
            Viajes colaboradorSeleccionado = (Viajes)cb.SelectedItem;
            return colaboradorSeleccionado.Distancia;
        }


        private void Viajes_Load(object sender, EventArgs e)
        {
            llenarcb(cbcolab1);
            llenarcb(cbcolab2);
            llenarcb(cbcolab3);
            llenarcb(cbcolab4);
            llenarcb(cbcolab5);
            llenarcb(cbcolab6);
            llenarcb(cbcolab7);
            llenarcb(cbcolab8);
            llenarcb(cbcolab9);
            llenarcb(cbcolab10);
            llenarcbt(cbtrans);
            txtregistrado.Text = registrador;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de registrar el viaje?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes && long.Parse(txtdist.Text) > 0 && long.Parse(txtdist.Text) <= 100 && long.Parse(txttarifa.Text) > 0)
            {
                string reg = txtregistrado.Text;
                string c1 = cbcolab1.SelectedItem.ToString();
                string c2 = cbcolab1.SelectedItem.ToString();
                string c3 = cbcolab1.SelectedItem.ToString();
                string c4 = cbcolab1.SelectedItem.ToString();
                string c5 = cbcolab1.SelectedItem.ToString();
                string c6 = cbcolab1.SelectedItem.ToString();
                string c7 = cbcolab1.SelectedItem.ToString();
                string c8 = cbcolab1.SelectedItem.ToString();
                string c9 = cbcolab1.SelectedItem.ToString();
                string c10 = cbcolab1.SelectedItem.ToString();
                string tr = cbtrans.SelectedItem.ToString();
                string ta = txttarifa.Text;
                string dt = txtdist.Text;
                string ct = txtCost.Text;
                string fec = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                sql = "insert into Viajes(Registrado, Colaborador_1, Colaborador_2, Colaborador_3, Colaborador_4, Colaborador_5, Colaborador_6, Colaborador_7, Colaborador_8, Colaborador_9, Colaborador_10, Transportista, Tarifa, Distancia_Total, Costo_Total, Fecha) values ('"+reg+"', '"+c1+ "', '" + c2 + "', '" + c3 + "', '" + c4 + "', '" + c5 + "', '" + c6 + "', '" + c7 + "', '" + c8 + "', '" + c9 + "', '" + c10 + "', '"+tr+"', '"+ta+"', '"+dt+"', '"+ct+"', '"+fec+"')";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conectar());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Agregado Correctamente");
            }
            else if(resultado == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Porfavor verifique los datos");
            }
        }

        private void cbcolab1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txttarifa_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbtrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttarifa.Text = bustrans(cbtrans.SelectedItem.ToString());
        }

        private void calculobtn_Click(object sender, EventArgs e)
        {
            if (txttarifa.Text != null && cbtrans != null)
            {
                if(long.Parse(txtdist.Text)>0 && long.Parse(txtdist.Text) <= 100)
                {
                    long suma;
                    suma = long.Parse(txttarifa.Text) * long.Parse(txtdist.Text);
                    txtCost.Text = suma.ToString();
                }
                else
                {
                    MessageBox.Show("La distancia debe estar entre 0 y 100");
                }
            }
            else
            {
                MessageBox.Show("No se ha fijado la tarifa");
            }
        }

        private void cbcolab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab1));
        }

        private void cbcolab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab2));

            List<ComboBox> listaDeComboBox = new List<ComboBox>();

            ComboBox comboBoxActual = (ComboBox)sender;
            object valorSeleccionado = comboBoxActual.SelectedItem;

            // Verificar si el valor seleccionado está repetido en los otros ComboBox
            foreach (Control control in Controls)
            {
                if (control is ComboBox comboBox && comboBox != comboBoxActual && comboBox.SelectedItem != null && comboBox.SelectedItem.Equals(valorSeleccionado))
                {
                    MessageBox.Show("El valor seleccionado ya está presente en otro ComboBox.");
                    // Aquí puedes tomar medidas adicionales si lo deseas, como deseleccionar el valor repetido.
                }
            }
        }

        private void cbcolab3_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab3));
        }

        private void cbcolab4_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab4));
        }

        private void cbcolab5_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab5));
        }

        private void cbcolab6_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab6));
        }

        private void cbcolab7_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab7));
        }

        private void cbcolab8_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab8));
        }

        private void cbcolab9_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab9));
        }

        private void cbcolab10_SelectedIndexChanged(object sender, EventArgs e)
        {
            suma(distancia(cbcolab10));
        }

        private void cleanbtn_Click(object sender, EventArgs e)
        {
            cbcolab1.SelectedItem = null;
            cbcolab2.SelectedItem = null;
            cbcolab3.SelectedItem = null;
            cbcolab4.SelectedItem = null;
            cbcolab5.SelectedItem = null;
            cbcolab6.SelectedItem = null;
            cbcolab7.SelectedItem = null;
            cbcolab8.SelectedItem = null;
            cbcolab9.SelectedItem = null;
            cbcolab10.SelectedItem = null;
            cbtrans.SelectedItem = null;
            txttarifa.Clear();
            txtdist.Clear();
            txtCost.Clear();
            dtotal = 0;
        }

        private void txtdist_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
