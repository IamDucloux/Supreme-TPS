using System;
using System.Windows.Forms;

namespace Supreme_TPS
{
    public partial class UserForm : Form
    {
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
    }
}
