using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Exceptions;
using WebApplication.Models;

namespace WebApplication.Service
{
    public class MaestrosService
    {

        /// <summary>
        /// Listar todos los registros en la base de datos
        /// </summary>
        /// <returns>List<Maestro></returns>
        public MaestrosResponse ListarMaestros()
        {
            MaestrosResponse response;
            try
            {
                List<Maestro> maestros;
                using (EscuelaDBEntities db = new EscuelaDBEntities())
                {
                    maestros = db.Maestros.ToList();
                }
                response = new MaestrosResponse();
                response.Result = "OK";
                response.Data = maestros;
            }
            catch (Exception e)
            {
                Console.WriteLine("[ ERROR ] -> " + e.Message);
                response = new MaestrosResponse("ERROR", true, e.Message);
            }
            return response;
        }

        /// <summary>
        /// Busca registros por varios datos del modelo
        /// </summary>
        /// <param name="m">Maestro</param>
        /// <returns>List<Maestro></returns>
        public MaestrosResponse BuscarMaestros(Maestro m)
        {
            MaestrosResponse response;
            try
            {
                List<Maestro> maestros = new List<Maestro>();
                using (EscuelaDBEntities db = new EscuelaDBEntities())
                {
                    if (m.NumeroDocumento != null)
                        maestros = db.Maestros.Where(x => x.NumeroDocumento == m.NumeroDocumento).ToList();
                    else if (!string.IsNullOrEmpty(m.Apellido))
                        maestros = db.Maestros.Where(x => x.Apellido == m.Apellido).ToList();
                    else if (!string.IsNullOrEmpty(m.Nombre))
                        maestros = db.Maestros.Where(x => x.Nombre == m.Nombre).ToList();
                }
                response = new MaestrosResponse();
                response.Result = "OK";
                response.Data = maestros;
            }
            catch(Exception e)
            {
                Console.WriteLine("[ ERROR ] -> " + e.Message);
                response = new MaestrosResponse("ERROR", true, e.Message);
            }
            return response;
        }

        /// <summary>
        /// Insertar nuevo maestro a la base de datos
        /// </summary>
        /// <param name="m">Maestro</param>
        /// <returns>Boolean</returns>
        public MaestrosResponse InsertarMaestro(Maestro m)
        {
            try
            {
                // Se valida atributos del modelo
                ValidarModeloAInsertar(m);
                using (EscuelaDBEntities db = new EscuelaDBEntities())
                {
                    // Se obtiene el Id y se registra en db
                    m.Id = ObtenerUltimoIdMaestros();
                    db.Maestros.Add(m);
                    db.SaveChanges();
                }
                return new MaestrosResponse("OK", false, "Operacion realizada");
            }
            catch (Exception e)
            {
                // En caso de error se manda respuesta de error
                Console.WriteLine("[ ERROR ] -> " + e.Message);
                return new MaestrosResponse("ERROR", true, e.Message);
            }
        }

        public MaestrosResponse ModificarMaestro(Maestro m)
        {
            MaestrosResponse response;
            try
            {
                ValidarModelo(m);
                List<Maestro> maestros = new List<Maestro>();
                using (EscuelaDBEntities db = new EscuelaDBEntities())
                {
                    Maestro maestro = db.Maestros.Find(m.Id);
                    maestro.Apellido = m.Apellido;
                    maestro.Nombre = m.Nombre;
                    maestro.NumeroDocumento = m.NumeroDocumento;
                    db.SaveChanges();
                    maestros.Add(maestro);
                }
                response = new MaestrosResponse();
                response.Result = "OK";
                response.Data = maestros;
            }catch(Exception e)
            {
                Console.WriteLine("[ ERROR ] -> " + e.Message);
                response = new MaestrosResponse("ERROR", true, e.Message);
            }
            return response;
        }

        /// <summary>
        /// Validar datos basicos del modelo
        /// </summary>
        /// <param name="maestro"></param>
        private void ValidarModelo(Maestro maestro)
        {
            if (string.IsNullOrEmpty(maestro.Apellido))
                throw new EmptyModelParameterException("Falta el apellido");
            if (string.IsNullOrEmpty(maestro.Nombre))
                throw new EmptyModelParameterException("Falta el nombre");
            if (maestro.NumeroDocumento == null)
                throw new EmptyModelParameterException("Falta el número de documento");
        }

        /// <summary>
        /// Validar datos basicos del modelo antes de insertar
        /// </summary>
        /// <param name="maestro"></param>
        private void ValidarModeloAInsertar(Maestro maestro)
        {
            ValidarModelo(maestro);
            Maestro valid;
            try
            {
                using (EscuelaDBEntities db = new EscuelaDBEntities())
                {
                    valid = db.Maestros.Where(m => m.NumeroDocumento == maestro.NumeroDocumento).First();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] -> " + e.Message);
                valid = null;
            }
            if (valid != null)
                throw new DocumentDuplicatedException("El número de  documento ya está registrado en la base de datos");
        }

        /// <summary>
        /// Obtener el siguiente ID para insertar en la base de datos
        /// </summary>
        /// <returns></returns>
        private int ObtenerUltimoIdMaestros()
        {
            using (EscuelaDBEntities db = new EscuelaDBEntities())
            {
                Maestro m = db.Maestros.ToList().Last();
                return m.Id + 1;
            }  
        }
    }
}