using System;
using System.Windows.Forms;

namespace Supreme_TPS
{
    
    public partial class UserForm : Form
    {
        Form1 inicio = new Form1();
        public UserForm()
        {
            InitializeComponent();
        }



        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                try
                {
                    
                    Producto[] prod = new Producto[Producto.Consulta_Productos(Program.bases_d(),textBox1.Text).Count];
                    Producto.Consulta_Productos(Program.bases_d(), textBox1.Text).CopyTo(prod);
                    string[] prods = new string[prod.Length];
                    for (int i = 0; i < prod.Length; i++)
                    {
                        prods[i] = prod[i].ToString();
                    }

                    

                    //Producto.Consulta_Productos(Program.bases_d(), textBox1.Text).CopyTo(prod);
                    listBox1.Items.AddRange(prods);
                    
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Profavor indique la busqueda");
            }
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            inicio.Show();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto produtcin = new Producto(textBox2.Text,textBox3.Text,richTextBox1.Text,0);
                Producto.Alta_Producto(Program.bases_d(), produtcin);
                textBox2.Clear();
                textBox3.Clear();
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.TextLength>0 && Producto.Consulta_Clave(Program.bases_d(),textBox7.Text)==textBox7.Text)
            {
                try
                {
                    textBox4.Text = textBox7.Text;
                    textBox5.Text = Producto.Consulta_Nombre(Program.bases_d(), textBox7.Text);
                    richTextBox2.Text = Producto.Consulta_Descripcion(Program.bases_d(), textBox7.Text);
                    Editar.Enabled = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor existente");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
