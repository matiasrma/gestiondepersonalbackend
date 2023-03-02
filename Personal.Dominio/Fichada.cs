using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.Dominio
{
    public class Fichada
    {
        public int fichadaId { get; set; }
        public DateTime fichadaFH { get; set; }
        public string fichadaEstado { get; set; }
        public int persona_personaId { get; set; }
        public string persona_personaNombre { get; set; }
        public string persona_personaApellido { get; set; }
        public int persona_personaLegajo { get; set; }
    }
}
