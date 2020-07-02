using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Controllers
{
    public class MaestrosController : Controller
    {
        private MaestrosService service;


        public MaestrosController()
        {
            ViewBag.MainTitle = "Escuela";
            ViewBag.SectionName = "Maestros";
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["login"].ToString()))
                {
                    ViewBag.nombre = Session["nombre"];
                    this.service = new MaestrosService();
                    return View(service.ListarMaestros());
                }
                return RedirectToAction("Login", "Index");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ ERROR ] -> " + e.Message);
                return RedirectToAction("Login", "Index");
            }
        }

        [HttpPost]
        public ActionResult Index(Maestro maestro, string buscar, string agregar, string modificar, string eliminar)
        {
            this.service = new MaestrosService();
            if (buscar != null)
                return View(service.BuscarMaestros(maestro));
            else if (agregar != null)
                return View(service.InsertarMaestro(maestro));
            else if(modificar != null)
                return View(service.ModificarMaestro(maestro));
            else if(eliminar != null)
                return View(service.BorrarMaestro(maestro));
            else
            {
                MaestrosResponse respuesta = new MaestrosResponse();
                respuesta.Result = "ERROR";
                respuesta.Message = "Error al capturar la operacion";
                respuesta.Error = true;
                return View(respuesta);
            }
            
        }

    }
}