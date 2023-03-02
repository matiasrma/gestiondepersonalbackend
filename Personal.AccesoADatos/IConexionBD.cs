using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.AccesoADatos
{
    public interface IConexionBD
    {
        MySqlConnection abrir();

        void cerrar();
    }
}
