using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.Excepciones
{
    public class ExcepcionGenerica : Exception
    {
        public ExcepcionGenerica(string message) : base(message) { }
    }
}
