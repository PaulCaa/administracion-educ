using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Exceptions
{
    public class DocumentDuplicatedException : WebAppException
    {
        private const string DEFAULT_MESSAGE = "Número de documento repetido.";

        public DocumentDuplicatedException() : base(DEFAULT_MESSAGE) { }

        public DocumentDuplicatedException(string message) : base(message) { }
    }
}