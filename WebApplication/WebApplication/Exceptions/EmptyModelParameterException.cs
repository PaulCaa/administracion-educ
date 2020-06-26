using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Exceptions
{
    public class EmptyModelParameterException : WebAppException
    {
        private const string DEFAULT_MESSAGE = "Faltan datos en el modelo";

        public EmptyModelParameterException() : base(DEFAULT_MESSAGE)
        { }

        public EmptyModelParameterException(string message) : base(message)
        { }
    }
}