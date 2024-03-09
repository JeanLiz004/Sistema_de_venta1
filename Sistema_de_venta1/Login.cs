using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_venta1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cls_conexion conexion = new cls_conexion();
            if (conexion.Validar(textBox1.Text, textBox2.Text) == true)
            {
                this.Hide();
                principal principal1 = new principal();
                principal1.Show();
            }
            else {
                MessageBox.Show("Usuario Incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();

            }
        }
    }
}
