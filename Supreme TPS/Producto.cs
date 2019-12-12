using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Supreme_TPS
{
    class Producto
    {
        private string clave;
        private string nombre;
        private string descripcion;
        private int existencia;
        

        public Producto(string clave, string nombre, string descripcion, int existencia)
        {
            this.clave = clave ?? throw new ArgumentNullException(nameof(clave));
            this.nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            this.existencia = existencia;
        }

        public Producto()
        {

        }

        public string Consulta_Existencia(MySqlConnection con, string clave)
        {
            string resultado = null;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT existencia FROM Productos WHERE Clave ='" + clave + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultado = reader.GetString(0);
            }
            reader.Close();
            return resultado;
        }

        public string Consulta_Clave(MySqlConnection con, string nombre)
        {
            string resultado = null;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT clave FROM Productos WHERE nombre ='" + nombre + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultado = reader.GetString(0);
            }
            reader.Close();
            return resultado;
        }

        public string Consulta_Descripcion(MySqlConnection con, string clave)
        {
            string resultado = null;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT Descripcion FROM Productos WHERE clave ='" + clave + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultado = reader.GetString(0);
            }
            reader.Close();
            return resultado;
        }

        public string Consulta_Nombre(MySqlConnection con, string clave)
        {
            string resultado =  null;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT Nombre FROM Productos WHERE Clave ='" + clave + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultado = reader.GetString(0);
            }
            reader.Close();
            return resultado;
        }

        public override string ToString()
        {
            string retorno = null;
            retorno = "Clave:   " + GetClave() + " Nombre:      " + GetNombre() + " Descripcion:    " + GetDescripcion() + " Existencia:    " + GetExistencia().ToString();
            return retorno;
        }

        public static List<Producto> Consulta_Productos(MySqlConnection con, string clave)
        {

            List<Producto> resultados = new List<Producto>(); //Lista en la que se van a almacenar los resultados del query
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM Productos WHERE Clave like '%" + clave + "%'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //string clv = reader.GetString(0);
                //string nomb = reader.GetString(1);
                //string desc = reader.GetString(2);
                //int exist = reader.GetInt32(3);
                
                resultados.Add(new Producto(reader.GetString(0),reader.GetString(1),reader.GetString(2),reader.GetInt32(3)));
            }
            reader.Close();
            return resultados;
        }

        public void Alta_Producto(MySqlConnection con, Producto prodct)
        {
            string consulta = "INSERT INTO Productos VALUES("+"'"+prodct.GetClave()+"','"+prodct.GetNombre()+"','"+prodct.GetDescripcion()+"','"+prodct.GetExistencia()+"')";
            MySqlCommand cmd = new MySqlCommand(consulta, con);
            MessageBox.Show(consulta);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }


        
        

        //Getters & Setters

        public void SetClave(string clave)
        {
            this.clave = clave;
        }

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void SetDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }
        
        public void SetExistencia(int existencia)
        {
            this.existencia = existencia;
        }

        public string GetClave()
        {
            return clave;
        }

        public string GetNombre()
        {
            return nombre;

        }

        public string GetDescripcion()
        {
            return descripcion;
        }

        public int GetExistencia()
        {
            return existencia;
        }
    }
}
