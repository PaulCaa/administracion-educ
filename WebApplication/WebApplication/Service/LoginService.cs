using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication.Exceptions;
using WebApplication.Models;

namespace WebApplication.Service
{
    public class LoginService
    {
        /// <summary>
        /// Metodo para validar credenciales recibidas contra base de datos
        /// </summary>
        /// <param name="usr">usuario</param>
        /// <param name="ctr">contraseña</param>
        /// <returns></returns>
        public ResultadoLogin ValidarLogin(string usr, string ctr)
        {
            if (string.IsNullOrWhiteSpace(usr))
                throw new ValidacionLoginException("Error al validar usuario");
            if(string.IsNullOrWhiteSpace(ctr))
                throw new ValidacionLoginException("Error al validar contraseña");
            string hash = Encriptar(ctr);
            using (EscuelaDBEntities db = new EscuelaDBEntities())
            {
                UsuarioLogin reg = db.Logins.Find(usr);
                if (reg == null)
                    throw new ValidacionLoginException();
                if(reg.Contrasena == hash)
                {
                    ResultadoLogin operacion = new ResultadoLogin();
                    operacion.Resultado = true;
                    //Roles role = db.Roles.Find(reg.IdRole);
                    operacion.Login = reg;
                    return operacion;
                }
                else
                {
                    throw new ValidacionLoginException();
                }
            }
        }

        private string Encriptar(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }
    }
}