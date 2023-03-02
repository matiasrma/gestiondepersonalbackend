using MySqlConnector;
using System;

namespace Personal.AccesoADatos
{
    public class ConexionBD : IConexionBD
    {
        public MySqlConnection conectarbd = new MySqlConnection();

        MySqlConnectionStringBuilder conn_string;

        public ConexionBD()
        {
            conn_string = new MySqlConnectionStringBuilder();

            conn_string.Server = "127.0.0.1";
            conn_string.Port = 3306;
            conn_string.UserID = "jorge";
            conn_string.Password = "lacontra";
            conn_string.Database = "personal";

            conectarbd = new MySqlConnection(conn_string.ToString());
        }

        public MySqlConnection abrir()
        {
            try
            {
                conectarbd.Open();
                return conectarbd;
            }
            catch (Exception ex)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido("La Base de Datos esta Caida");
            }
        }

        public void cerrar()
        {
            conectarbd.Close();
        }
    }
}
