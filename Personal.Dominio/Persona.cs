using System;

namespace Personal.Dominio
{
    public class Persona
    {

        public int personaId { get; set; }
        public int personaLegajo { get; set; }
        public string personaNombre { get; set; }
        public string personaApellido { get; set; }
        public string personaCuil { get; set; }
        public string personaEstado { get; set; }
        public string personaPuesto { get; set; }
        public string personaSector { get; set; }
        public DateTime personaFechaAlta { get; set; }
        public DateTime personaFechaNacimiento { get; set; }

    }
}
