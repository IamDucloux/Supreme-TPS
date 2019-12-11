using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace Supreme_TPS
{
    public partial class Form1 : Form
    {
        UserForm usrform = new UserForm();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=null && textBox2.Text!=null)
            {
                if (Usuario.Consulta_Nombre(Program.bases_d(),textBox1.Text)==textBox1.Text && Usuario.Consulta_Contraseña(Program.bases_d(),textBox1.Text)==textBox2.Text)
                {
                    MessageBox.Show("Bienvenido");
                    usrform = new UserForm();
                    usrform.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                    Hide();

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese sus datos");
            }
        }
    }
}
