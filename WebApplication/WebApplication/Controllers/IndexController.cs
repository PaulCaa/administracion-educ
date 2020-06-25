using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication.Exceptions;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Controllers
{
    public class IndexController : Controller
    {
        private LoginService loginService;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Logins login)
        {
            loginService = new LoginService();
            try
            {
                ResultadoLogin valid = loginService.ValidarLogin(login.IdUsuario, login.Contrasena);
                if (valid.Resultado)
                {
                    NuevaSesion(valid.Login);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new ValidacionLoginException();
                }
            }
            catch(Exception e)
            {
                ViewBag.error = e.Message;
                return View(ViewBag);
            }
        }

        public ActionResult Index()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["login"].ToString()))
                {
                    ViewBag.nombre = Session["nombre"];
                    return View();
                }
                return RedirectToAction("login");
            }
            catch (Exception e)
            {
                return RedirectToAction("login");
            } 
        }

        private void NuevaSesion(Logins usr)
        {
            Session["login"] = "true";
            if (!string.IsNullOrEmpty(usr.IdUsuario))
                Session["usuario"] = usr.IdUsuario;
            string nombre = "";
            if (!string.IsNullOrEmpty(usr.Apellido))
                nombre = usr.Apellido;
            if (!string.IsNullOrEmpty(usr.Nombre))
                nombre += ", " + usr.Nombre;
            Session["nombre"] = nombre;
            if (!string.IsNullOrEmpty(usr.Email))
                Session["correo"] = usr.Email;
        }
    }
}