using Personal.Dominio;
using Personal.InterfazAccesoADatos;
using Personal.InterfazLogicaDominio;
using System;
using System.Collections.Generic;

namespace Personal.LogicaDominio
{
    public class LogicaPersona : ILogicaPersona
    {
        private readonly IPersonaRespositorio personaRespositorio;

        public LogicaPersona(IPersonaRespositorio personaRespositorio)
        {
            this.personaRespositorio = personaRespositorio;
        }

        public List<Persona> Obtener()
        {
            return personaRespositorio.Obtener();
        }

        public Persona Obtener(int personaId)
        {
            return personaRespositorio.Obtener(personaId);
        }

        public Persona Insertar(            
            int personaLegajo,
            string personaNombre,
            string personaApellido)
        {
            return personaRespositorio.Insertar(
                personaLegajo,
                personaNombre,
                personaApellido);             
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
            DateTime personaFechaNacimiento)
        {
            return personaRespositorio.Modificar(
                personaId,
                personaLegajo,
                personaNombre,
                personaApellido,
                personaCuil,
                personaEstado,
                personaPuesto,
                personaSector,
                personaFechaAlta,
                personaFechaNacimiento);
        }

        public void Eliminar(int personaId)
        {
            personaRespositorio.Eliminar(personaId);
        }
    }
}
