using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supreme_TPS
{
    class Usuario
    {
        private string nombre;
        private string contraseña;
        private char nivel;

        public Usuario(string nombre, string contraseña, char nivel)
        {
            this.nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.contraseña = contraseña ?? throw new ArgumentNullException(nameof(contraseña));
            this.nivel = nivel;
        }

        public string Consulta_Nombre(MySqlConnection con, string nombre)
        {
            string cadena = null;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            
            cmd.CommandText = "SELECT nombre FROM Usuarios WHERE usuario ='" + nombre + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cadena=reader.GetString(0);
            }
            reader.Close();
            return cadena;
            
        }

        public string Consulta_Contraseña(MySqlConnection con, string nombre)
        {
            string cadena = null;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT contraseña FROM Usuarios WHERE usuario ='" + nombre + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cadena = reader.GetString(0);
            }
            reader.Close();
            return cadena;

        }

        public string Consulta_Nivel(MySqlConnection con, string nombre)
        {
            string cadena = null;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT nivel FROM Usuarios WHERE usuario ='" + nombre + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cadena = reader.GetString(0);
            }
            reader.Close();
            return cadena;

        }

        public void Edita_Usuario(MySqlConnection con,Usuario user, Usuario user_new)
        {
            string consulta = "UPDATE usuarios SET(nombre="+"'"+user_new.GetNombre()+
                "',contraseña="+"'"+user_new.GetContraseña()+"',nivel="+"'"+user_new.GetNivel()+"')" +
                " WHERE nombre="+"'"+user.GetNombre()+"'";
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

        public void Alta_Usuario(MySqlConnection con, Usuario usr)
        {
            string consulta = "INSERT INTO USUARIOS(ID_USUARIO,NOMBRE,CONTRASEÑA,NIVEL) VALUES("+"' ',"+"'"+usr.GetNombre()+"',"+
                "'"+usr.GetContraseña()+"',"+"'"+usr.GetNivel()+"')";
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

        
        public string GetNombre()
        {
            return nombre;
        }

        public string GetContraseña()
        {
            return contraseña;
        }

        public char GetNivel()
        {
            return nivel;
        }

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void SetContraseña(string contraseña)
        {
            this.contraseña = contraseña;
        }

        public void SetNivel(char nivel)
        {
            this.nivel = nivel;
        }
    }
}
