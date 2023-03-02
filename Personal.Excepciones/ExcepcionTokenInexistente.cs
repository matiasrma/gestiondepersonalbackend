using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.Excepciones
{
    [Serializable]
    public class ExcepcionTokenInexistente : ExcepcionGenerica
    {
        public const string message = "No existe el token : ";
        public ExcepcionTokenInexistente(string msg) : base(message + msg) { }

    }
}
