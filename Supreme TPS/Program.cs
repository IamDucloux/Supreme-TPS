using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supreme_TPS
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }

        public static MySqlConnection bases_d()
        {
            MySqlConnection con;
            string conexion = "Server=remotemysql.com;Port=3306;Username=VkW8sPJRRH;Password=5qczt1sobH;Database=VkW8sPJRRH";
            con = new MySqlConnection(conexion);
            try
            {
                con.Open();
                MessageBox.Show("conexion establecida");

            }
            catch
            {
                MessageBox.Show("sin conexion");
            }
            return con;
        }
    }
}
