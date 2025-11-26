using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ApiCalculadora.Data;
using ApiCalculadora.Models;

namespace ApiCalculadora.Controllers
{
    public class CalculosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/calculos - Obtener TODOS los cálculos
        [HttpGet]
        [Route("api/calculos")]
        public IHttpActionResult GetCalculos()
        {
            try
            {
                var calculos = db.Calculos.OrderByDescending(c => c.Fecha).ToList();
                return Ok(calculos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/calculos/{id} - Obtener UN cálculo por ID
        [HttpGet]
        [Route("api/calculos/{id}")]
        public IHttpActionResult GetCalculo(int id)
        {
            try
            {
                var calculo = db.Calculos.Find(id);
                if (calculo == null)
                {
                    return NotFound();
                }
                return Ok(calculo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/calculos/sumas - Obtener solo SUMAS
        [HttpGet]
        [Route("api/calculos/sumas")]
        public IHttpActionResult GetSumas()
        {
            try
            {
                var sumas = db.Calculos
                    .Where(c => c.Operacion.Contains("+"))
                    .OrderByDescending(c => c.Fecha)
                    .ToList();
                return Ok(sumas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/calculos/restas - Obtener solo RESTAS
        [HttpGet]
        [Route("api/calculos/restas")]
        public IHttpActionResult GetRestas()
        {
            try
            {
                var restas = db.Calculos
                    .Where(c => c.Operacion.Contains("-") && !c.Operacion.StartsWith("-"))
                    .OrderByDescending(c => c.Fecha)
                    .ToList();
                return Ok(restas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/calculos/multiplicaciones - Obtener solo MULTIPLICACIONES
        [HttpGet]
        [Route("api/calculos/multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            try
            {
                var multiplicaciones = db.Calculos
                    .Where(c => c.Operacion.Contains("*"))
                    .OrderByDescending(c => c.Fecha)
                    .ToList();
                return Ok(multiplicaciones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/calculos/divisiones - Obtener solo DIVISIONES
        [HttpGet]
        [Route("api/calculos/divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            try
            {
                var divisiones = db.Calculos
                    .Where(c => c.Operacion.Contains("/"))
                    .OrderByDescending(c => c.Fecha)
                    .ToList();
                return Ok(divisiones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/calculos/fecha?fecha=2025-01-15 - Filtrar por FECHA (Endpoint Libre)
        [HttpGet]
        [Route("api/calculos/fecha")]
        public IHttpActionResult GetPorFecha(DateTime fecha)
        {
            try
            {
                var calculosPorFecha = db.Calculos
                    .Where(c => c.Fecha.Year == fecha.Year &&
                                c.Fecha.Month == fecha.Month &&
                                c.Fecha.Day == fecha.Day)
                    .OrderByDescending(c => c.Fecha)
                    .ToList();
                return Ok(calculosPorFecha);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Liberar recursos
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}