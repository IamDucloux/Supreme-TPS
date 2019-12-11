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

        public int Consulta_Existencia(MySqlConnection con, string clave)
        {
            int resultado = 0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT existencia FROM Productos WHERE Clave ='" + clave + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultado = reader.GetInt32(0);
            }
            reader.Close();
            return resultado;
        }

        public void Alta_Producto(MySqlConnection con, Producto prodct)
        {
            string consulta = "INSERT INTO Productos VALUES("+"'"+prodct.GetClave()+"','"+prodct.GetNombre()+"','"+prodct.GetDescripcion()+"'"+")";
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
