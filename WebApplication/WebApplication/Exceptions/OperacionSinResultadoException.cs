using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Exceptions
{
    public class OperacionSinResultadoException : WebAppException
    {
        private const string DEFAULT_MESSAGE = "No se encontraron resultados";

        public OperacionSinResultadoException() : base(DEFAULT_MESSAGE)
        { }

        public OperacionSinResultadoException(string mensaje) : base(mensaje) 
        { }

        public OperacionSinResultadoException(Exception causa) : base(DEFAULT_MESSAGE, causa)
        { }

        public OperacionSinResultadoException(string mensaje, Exception causa) : base(mensaje, causa)
        { }
    }
}