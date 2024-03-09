using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;//Introducir esto para la conexion
using System.Windows.Forms;//Tambien esto
namespace Sistema_de_venta1
{
    class cls_conexion
    {
        SqlConnection MyCon;
        SqlCommand comand;
        SqlDataReader reader;
        public cls_conexion(){
        //USER ID="";PASWORD=""
            MyCon = new SqlConnection("Data Source=DESKTOP-HQEFU8A\\JEANSQLEXPRESS;Initial Catalog=sistemaventa1;Integrated Security=SSPI");
        }
        public SqlConnection Conectar()
        {
        try
        {
        MyCon.Open(); //Abrir conexion
        }
        catch (Exception x) //Si se produce un error los despliega
        {
           MessageBox.Show("Error ::" + x.ToString());
 
            }
            return MyCon; //Return variable de conexion
        }
        public bool Validar(string user, string password) //Valida usuario
        {
        bool valido = false; //Estatus del usuario
            string query = @"SELECT nombre_usuario, contrasena from dbo.usuarios where nombre_usuario='" + user + "' and contrasena='" + password + "'"; //query validar usuario

        comand = new SqlCommand(query, Conectar()); //Ejecuta el query
            reader = comand.ExecuteReader(); // Asigna el resulta del select del comand al reader
        if(reader.HasRows==true)
    {
    valido = true;
    }
            return valido; //return estatus del usuario
        }
        

    }
}
