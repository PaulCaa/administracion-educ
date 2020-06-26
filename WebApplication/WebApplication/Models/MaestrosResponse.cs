using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class MaestrosResponse
    {
        public string Result { set; get; }
        public Boolean Error { set; get; }
        public string Message { set; get; }
        public List<Maestro> Data { set; get; }

        public MaestrosResponse()
        {
            this.Error = false;
        }

        public MaestrosResponse(string res, Boolean err, string msj)
        {
            this.Result = res;
            this.Error = err;
            this.Message = msj;
        }
    }
}