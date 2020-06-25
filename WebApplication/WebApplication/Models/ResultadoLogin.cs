using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ResultadoLogin
    {
        public Boolean Resultado { set; get; }
        public string Mensaje { set; get; }
        public Logins Login { set; get; }

        public ResultadoLogin()
        {
            Resultado = false;
        }
    }
}