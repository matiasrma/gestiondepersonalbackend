using Personal.AccesoADatos.Repositorio;
using Personal.Dominio;
using Personal.InterfazAccesoADatos;
using Personal.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Personal.LogicaDominio
{
    public class LogicaFichada : ILogicaFichada
    {
        private readonly IFichadaRepositorio fichadaRespositorio;

        public LogicaFichada(IFichadaRepositorio fichadaRespositorio)
        {
            this.fichadaRespositorio = fichadaRespositorio;
        }

        public List<Fichada> Obtener()
        {
            return fichadaRespositorio.Obtener();
        }

        public List<Fichada> ObtenerFichadas(int persona_personaId, DateTime fichadaFH)
        {
            return fichadaRespositorio.ObtenerFichadas(persona_personaId, fichadaFH);
        }

        public Fichada Insertar(
            DateTime fichadaFH,
            string fichadaEstado,
            int persona_personaId)
        {

            List<Fichada> personaFichadas = new List<Fichada>();

            personaFichadas = fichadaRespositorio.ObtenerFichadas(persona_personaId, fichadaFH);

            if (personaFichadas.Count()%2 == 0)
            {
                fichadaEstado = "Ingreso";
            } else {
                fichadaEstado = "Salida";
            }

            return fichadaRespositorio.Insertar(
                fichadaFH,
                fichadaEstado,
                persona_personaId);
        }

    }
}
