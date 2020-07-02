using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Exceptions
{
    public class ParametroModeloVacioException : WebAppException
    {
        private const string DEFAULT_MESSAGE = "Faltan datos en el modelo";

        public ParametroModeloVacioException() : base(DEFAULT_MESSAGE)
        { }

        public ParametroModeloVacioException(string message) : base(message)
        { }
    }
}