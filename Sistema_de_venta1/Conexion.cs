using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;//Introducir esto
using System.Data.SqlClient;//Tambien esto

namespace Sistema_de_venta1
{
    class Conexion
    {
        public static SqlConnection Conectar()
        { 
        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-HQEFU8A\\JEANSQLEXPRESS;DATABASE=sistemaventa1;Integrated Security=SSPI");
        cn.Open();
        return cn;
        }
    }
}
