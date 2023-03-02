using Personal.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.InterfazAccesoADatos
{
    public interface IFichadaRepositorio
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
