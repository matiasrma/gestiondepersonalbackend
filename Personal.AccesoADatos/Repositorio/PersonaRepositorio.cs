using MySqlConnector;
using Personal.Dominio;
using Personal.InterfazAccesoADatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Personal.AccesoADatos.Repositorio
{
    public class PersonaRepositorio : IPersonaRespositorio
    {
        private readonly IConexionBD conexion;
        private readonly MySqlConnection conexionBD;
        private MySqlCommand comando;
        private MySqlDataReader consultar;

        public PersonaRepositorio(IConexionBD conexion)
        {
            this.conexion = conexion;
            conexionBD = conexion.abrir();
        }

        public List<Persona> Obtener()
        {
            string cadena = "SELECT * FROM persona;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexionBD);
                MySqlDataReader consultar = comando.ExecuteReader();

                List<Persona> lista = new List<Persona>();

                while (consultar.Read())
                {
                    Persona persona = new Persona();

                    persona.personaId = consultar.GetInt32(0);
                    if (!consultar.IsDBNull(1)) { persona.personaLegajo = consultar.GetInt32(1); }
                    if (!consultar.IsDBNull(2)) { persona.personaNombre = consultar.GetString(2); }
                    if (!consultar.IsDBNull(3)) { persona.personaApellido = consultar.GetString(3); }
                    if (!consultar.IsDBNull(4)) { persona.personaCuil = consultar.GetString(4); }
                    if (!consultar.IsDBNull(5)) { persona.personaEstado = consultar.GetString(5); }
                    if (!consultar.IsDBNull(6)) { persona.personaPuesto = consultar.GetString(6); }
                    if (!consultar.IsDBNull(7)) { persona.personaSector = consultar.GetString(7); }
                    if (!consultar.IsDBNull(8)) { persona.personaFechaAlta = consultar.GetDateTime(8); }
                    if (!consultar.IsDBNull(8)) { persona.personaFechaNacimiento = consultar.GetDateTime(9); }

                    lista.Add(persona);

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

        public Persona Obtener(int personaId)
        {
            string cadena = "SELECT * FROM persona WHERE personaID = @personaId;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexionBD);
                comando.Parameters.Add("@personaId", MySqlDbType.Int32).Value = personaId;
                MySqlDataReader consultar = comando.ExecuteReader();

                Persona persona = new Persona();

                while (consultar.Read())
                {
                    
                    persona.personaId = consultar.GetInt32(0);
                    if (!consultar.IsDBNull(1)) { persona.personaLegajo = consultar.GetInt32(1); }
                    if (!consultar.IsDBNull(2)) { persona.personaNombre = consultar.GetString(2); }
                    if (!consultar.IsDBNull(3)) { persona.personaApellido = consultar.GetString(3); }
                    if (!consultar.IsDBNull(4)) { persona.personaCuil = consultar.GetString(4); }
                    if (!consultar.IsDBNull(5)) { persona.personaEstado = consultar.GetString(5); }
                    if (!consultar.IsDBNull(6)) { persona.personaPuesto = consultar.GetString(6); }
                    if (!consultar.IsDBNull(7)) { persona.personaSector = consultar.GetString(7); }
                    if (!consultar.IsDBNull(8)) { persona.personaFechaAlta = consultar.GetDateTime(8); }
                    if (!consultar.IsDBNull(8)) { persona.personaFechaNacimiento = consultar.GetDateTime(9); }

                }

                conexionBD.Close();
                return persona;
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

        public Persona Insertar(            
            int personaLegajo,
            string personaNombre,
            string personaApellido
            )
        {
            string cadena = "INSERT INTO persona (" +
                "personaLegajo, " +
                "personaNombre, " +
                "personaApellido " +                
                ") VALUES (" +
                "@personaLegajo, " +
                "@personaNombre, " +
                "@personaApellido" +                
                ");";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexionBD);
                comando.Parameters.Add("@personaLegajo", MySqlDbType.Int32).Value = personaLegajo;
                comando.Parameters.Add("@personaNombre", MySqlDbType.String).Value = personaNombre;
                comando.Parameters.Add("@personaApellido", MySqlDbType.String).Value = personaApellido;            

                comando.ExecuteNonQuery();

                Persona persona = new Persona();                
                persona.personaLegajo = personaLegajo;
                persona.personaNombre = personaNombre;
                persona.personaApellido = personaApellido;                                

                conexionBD.Close();
                return persona;
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



        public Persona Modificar(
            int personaId,
            int personaLegajo,
            string personaNombre,
            string personaApellido,
            string personaCuil,
            string personaEstado,
            string personaPuesto,
            string personaSector,
            DateTime personaFechaAlta,
            DateTime personaFechaNacimiento
            )
        {
            string cadena = "UPDATE persona SET " +
                "personaLegajo = @personaLegajo, " +
                "personaNombre = @personaNombre, " +
                "personaApellido = @personaApellido, " +
                "personaCuil = @personaCuil, " +
                "personaEstado = @personaEstado, " +
                "personaPuesto = @personaPuesto, " +
                "personaSector = @personaSector, " +
                "personaFechaAlta = @personaFechaAlta, " +
                "personaFechaNac = @personaFechaNacimiento " +
                "WHERE personaId = @personaId); ";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexionBD);
                comando.Parameters.Add("@personaId", MySqlDbType.Int32).Value = personaId;
                comando.Parameters.Add("@personaLegajo", MySqlDbType.Int32).Value = personaLegajo;
                comando.Parameters.Add("@personaNombre", MySqlDbType.String).Value = personaNombre;
                comando.Parameters.Add("@personaApellido", MySqlDbType.String).Value = personaApellido;
                comando.Parameters.Add("@personaCuil", MySqlDbType.String).Value = personaCuil;
                comando.Parameters.Add("@personaEstado", MySqlDbType.String).Value = personaEstado;
                comando.Parameters.Add("@personaPuesto", MySqlDbType.String).Value = personaPuesto;
                comando.Parameters.Add("@personaSector", MySqlDbType.String).Value = personaSector;
                comando.Parameters.Add("@personaFechaAlta", MySqlDbType.Date).Value = personaFechaAlta;
                comando.Parameters.Add("@personaFechaNac", MySqlDbType.Date).Value = personaFechaNacimiento;

                comando.ExecuteNonQuery();

                Persona persona = new Persona();
                persona.personaId = personaId;
                persona.personaLegajo = personaLegajo;
                persona.personaNombre = personaNombre;
                persona.personaApellido = personaApellido;
                persona.personaCuil = personaCuil;
                persona.personaEstado = personaEstado;
                persona.personaPuesto = personaPuesto; ;
                persona.personaSector = personaSector;
                persona.personaFechaAlta = personaFechaAlta;
                persona.personaLegajo = personaLegajo;


                conexionBD.Close();
                return persona;
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


        public void Eliminar(int personaId)
        {
            string cadena = "DELETE FROM persona WHERE personaId = @personaId;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexionBD);
                comando.Parameters.Add("@personaId", MySqlDbType.Int32).Value = personaId;
                comando.ExecuteNonQuery();

                conexionBD.Close();
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
