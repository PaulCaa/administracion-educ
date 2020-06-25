using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Exceptions
{
    public class ValidacionLoginException : WebAppException
    {
        private const string DEFAULT_MESSAGE = "No se reconoce usuario o contraseña";

        public ValidacionLoginException() : base(DEFAULT_MESSAGE) { }

        public ValidacionLoginException(string mensaje) : base(mensaje) { }
    }
}