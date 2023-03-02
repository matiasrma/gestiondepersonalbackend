using MySqlConnector;
using Personal.Dominio;
using Personal.InterfazAccesoADatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.AccesoADatos.Repositorio
{
    public class FichadaRepositorio : IFichadaRepositorio
    {
        private readonly IConexionBD conexion;
        private readonly MySqlConnection conexionBD;
        private MySqlCommand comando;
        private MySqlDataReader consultar;

        public FichadaRepositorio(IConexionBD conexion)
        {
            this.conexion = conexion;
            conexionBD = conexion.abrir();
        }

        public List<Fichada> Obtener()
        {            
            string cadena = "SELECT fichada.fichadaFH, fichada.fichadaEstado, fichada.persona_personaId, " +
                "persona.personaNombre, persona.personaApellido, persona.personaLegajo FROM personal.fichada " +
                "INNER JOIN personal.persona ON fichada.persona_personaId=persona.personaId ORDER BY fichadaId DESC;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexionBD);
                MySqlDataReader consultar = comando.ExecuteReader();

                List<Fichada> lista = new List<Fichada>();

                while (consultar.Read())
                {
                    Fichada fichada = new Fichada();
                    
                    if (!consultar.IsDBNull(1)) { fichada.fichadaFH = consultar.GetDateTime(0); }
                    if (!consultar.IsDBNull(2)) { fichada.fichadaEstado = consultar.GetString(1); }
                    if (!consultar.IsDBNull(3)) { fichada.persona_personaId = consultar.GetInt32(2); }
                    if (!consultar.IsDBNull(3)) { fichada.persona_personaNombre = consultar.GetString(3); }
                    if (!consultar.IsDBNull(3)) { fichada.persona_personaApellido = consultar.GetString(4); }
                    if (!consultar.IsDBNull(3)) { fichada.persona_personaLegajo = consultar.GetInt32(5); }

                    lista.Add(fichada);

                }

                conexionBD.Close();
                return lista;
            }
            catch (MySqlConnector.MySqlException e)
            {
                conexionBD.Close();

                if (e.Message.Split(' ')[0] == "Unknown")
                {
                    throw new Excepciones.ExcepcionErrorDeSintaxisSql(cadena);
                }
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public List<Fichada> ObtenerFichadas(int persona_personaId, DateTime fichadaFH)
        {
            fichadaFH = fichadaFH - fichadaFH.TimeOfDay;
            string cadena = "SELECT * FROM fichada WHERE persona_personaId = @persona_personaId AND fichadaFH > @fichadaFH;";            

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexionBD);
                comando.Parameters.Add("@persona_personaId", MySqlDbType.Int32).Value = persona_personaId;
                comando.Parameters.Add("@fichadaFH", MySqlDbType.DateTime).Value = fichadaFH;
                MySqlDataReader consultar = comando.ExecuteReader();

                List<Fichada> listaFichadas = new List<Fichada>();

                while (consultar.Read())
                {
                    Fichada fichada = new Fichada();

                    fichada.fichadaId = consultar.GetInt32(0);
                    if (!consultar.IsDBNull(1)) { fichada.fichadaFH = consultar.GetDateTime(1); }
                    if (!consultar.IsDBNull(2)) { fichada.fichadaEstado = consultar.GetString(2); }
                    if (!consultar.IsDBNull(3)) { fichada.persona_personaId = consultar.GetInt32(3); }

                    listaFichadas.Add(fichada);
                }

                conexionBD.Close();
                return listaFichadas;
            }
            catch (MySqlConnector.MySqlException e)
            {
                conexionBD.Close();

                if (e.Message.Split(' ')[0] == "Unknown")
                {
                    throw new Excepciones.ExcepcionErrorDeSintaxisSql(cadena);
                }
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public Fichada Insertar(
            DateTime fichadaFH,
            string fichadaEstado,
            int persona_personaId
            )
        {
            string cadena = "INSERT INTO fichada (" +
                "fichadaFH, fichadaEstado, persona_personaId" +
                ") VALUES (" +
                "@fichadaFH, @fichadaEstado, @persona_personaId" +
                ");";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexionBD);
                comando.Parameters.Add("@fichadaFH", MySqlDbType.DateTime).Value = fichadaFH;
                comando.Parameters.Add("@fichadaEstado", MySqlDbType.String).Value = fichadaEstado;
                comando.Parameters.Add("@persona_personaId", MySqlDbType.Int32).Value = persona_personaId;                

                if (!comando.IsPrepared) { conexionBD.Open(); }

                comando.ExecuteNonQuery();

                Fichada fichada = new Fichada();
                fichada.fichadaFH = fichadaFH;
                fichada.fichadaEstado = fichadaEstado;
                fichada.persona_personaId = persona_personaId;                

                conexionBD.Close();
                return fichada;
            }
            catch (MySqlConnector.MySqlException e)
            {
                conexionBD.Close();

                if (e.Message.Split(' ')[0] == "Unknown")
                {
                    throw new Excepciones.ExcepcionErrorDeSintaxisSql(cadena);
                }
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

    }
}
