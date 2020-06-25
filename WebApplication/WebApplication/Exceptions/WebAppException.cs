using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Exceptions
{
    public class WebAppException : Exception
    {
        public WebAppException() : base() { }

        public WebAppException(string mensaje) : base(mensaje) { }

        public WebAppException(string mensaje, Exception causa) : base(mensaje, causa) { }
    }
}