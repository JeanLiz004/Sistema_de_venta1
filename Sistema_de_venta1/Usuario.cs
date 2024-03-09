using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data; //Poner esto
using System.Data.SqlClient;//Tambien esto

namespace Sistema_de_venta1
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conexión existosa");
            dataGridView1.DataSource = llenar_grid();
            //En datagridview, en la propiedad autosize column poner fill
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM usuarios";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "insert into usuarios (Id, nombre_usuario, contrasena) values(@Id, @nombre_usuario, @contrasena)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd1.Parameters.AddWithValue("@nombre_usuario", textBox2.Text);
            cmd1.Parameters.AddWithValue("@contrasena", textBox3.Text);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados con éxito.");
            dataGridView1.DataSource = llenar_grid();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //En datagridview1, en evento en cellContentClick nos abrirá la opcion para poner el codigo que se relaciona a este
            Conexion.Conectar();
            string actualizar = "update usuarios set Id=@Id, nombre_usuario=@nombre_usuario, contrasena=@contrasena where Id=@Id";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd2.Parameters.AddWithValue("@nombre_usuario", textBox2.Text);
            cmd2.Parameters.AddWithValue("@contrasena", textBox3.Text);
            
            
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con éxito");
            dataGridView1.DataSource = llenar_grid();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            }  
            catch
            {
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from usuarios where Id=@Id";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@Id", textBox1.Text);

            cmd3.ExecuteNonQuery();
            
            MessageBox.Show("Los datos se han eliminado con éxito");
            
            dataGridView1.DataSource = llenar_grid();
        }
    }
}
