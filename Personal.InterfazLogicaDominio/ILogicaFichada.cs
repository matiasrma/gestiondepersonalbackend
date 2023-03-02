using Personal.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.InterfazLogicaDominio
{
    public interface ILogicaFichada
    {
        List<Fichada> Obtener();
        List<Fichada> ObtenerFichadas(int persona_personaId, DateTime fichadaFH);
        Fichada Insertar(
            DateTime fichadaFH,
            string fichadaEstado,
            int persona_personaId
            );
        
    }
}
