using Personal.Dominio;
using System;
using System.Collections.Generic;

namespace Personal.InterfazAccesoADatos
{
    public interface IPersonaRespositorio
    {
        List<Persona> Obtener();
        Persona Obtener(int personaId);
        Persona Insertar(            
            int personaLegajo,
            string personaNombre,
            string personaApellido
            );
        Persona Modificar(
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
            );

        void Eliminar(int personaId);
    }
}
