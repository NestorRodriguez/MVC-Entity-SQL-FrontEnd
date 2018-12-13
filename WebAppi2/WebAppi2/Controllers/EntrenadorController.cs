using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppi2.Models;

namespace WebAppi2.Controllers
{
    public class EntrenadorController : ApiController
    {
        private Equipo2Entities1 db = new Equipo2Entities1();

        // GET: api/Entrenador
        public IQueryable<Entrenador> GetEntrenador()
        {
            return db.Entrenador;
        }

        // GET: api/Entrenador/5
        [ResponseType(typeof(Entrenador))]
        public IHttpActionResult GetEntrenador(int id)
        {
            Entrenador entrenador = db.Entrenador.Find(id);
            if (entrenador == null)
            {
                return NotFound();
            }

            return Ok(entrenador);
        }

        // PUT: api/Entrenador/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrenador(int id, Entrenador entrenador)
        {
           

            if (id != entrenador.id)
            {
                return BadRequest();
            }

            db.Entry(entrenador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrenadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entrenador
        [ResponseType(typeof(Entrenador))]
        public IHttpActionResult PostEntrenador(Entrenador entrenador)
        {
           

            db.Entrenador.Add(entrenador);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EntrenadorExists(entrenador.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = entrenador.id }, entrenador);
        }

        // DELETE: api/Entrenador/5
        [ResponseType(typeof(Entrenador))]
        public IHttpActionResult DeleteEntrenador(int id)
        {
            Entrenador entrenador = db.Entrenador.Find(id);
            if (entrenador == null)
            {
                return NotFound();
            }

            db.Entrenador.Remove(entrenador);
            db.SaveChanges();

            return Ok(entrenador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntrenadorExists(int id)
        {
            return db.Entrenador.Count(e => e.id == id) > 0;
        }
    }
}