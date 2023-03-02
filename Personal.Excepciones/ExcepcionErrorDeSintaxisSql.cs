using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.Excepciones
{
    [Serializable]
    public class ExcepcionErrorDeSintaxisSql : ExcepcionGenerica
    {
        public const string message = "La consutal Sql esta mal escrita, verifique";
        public ExcepcionErrorDeSintaxisSql(string msg) : base(message + msg) { }
    }
}
