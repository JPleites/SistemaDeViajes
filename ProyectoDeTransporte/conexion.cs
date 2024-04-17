using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoDeTransporte
{
    class conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER = JEPPLEITES; DATABASE = ProyectoDeTransporte; integrated security=true");
            cn.Open();
            return cn;
        }

        public static SqlConnection desconectar()
        {
            SqlConnection cn = new SqlConnection("SERVER = JEPPLEITES; DATABASE = ProyectoDeTransporte; integrated security=true");
            cn.Close();
            return cn;
        }
    }
}
