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
    public class FutbolistasController : ApiController
    {
        private Equipo2Entities1 db = new Equipo2Entities1();

        // GET: api/Futbolistas
        public IQueryable<Futbolista> GetFutbolista()
        {
            return db.Futbolista;
        }

        // GET: api/Futbolistas/5
        [ResponseType(typeof(Futbolista))]
        public IHttpActionResult GetFutbolista(int id)
        {
            Futbolista futbolista = db.Futbolista.Find(id);
            if (futbolista == null)
            {
                return NotFound();
            }

            return Ok(futbolista);
        }

        // PUT: api/Futbolistas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFutbolista(int id, Futbolista futbolista)
        {
           

            if (id != futbolista.id)
            {
                return BadRequest();
            }

            db.Entry(futbolista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FutbolistaExists(id))
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

        // POST: api/Futbolistas
        [ResponseType(typeof(Futbolista))]
        public IHttpActionResult PostFutbolista(Futbolista futbolista)
        {
           

            db.Futbolista.Add(futbolista);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FutbolistaExists(futbolista.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = futbolista.id }, futbolista);
        }

        // DELETE: api/Futbolistas/5
        [ResponseType(typeof(Futbolista))]
        public IHttpActionResult DeleteFutbolista(int id)
        {
            Futbolista futbolista = db.Futbolista.Find(id);
            if (futbolista == null)
            {
                return NotFound();
            }

            db.Futbolista.Remove(futbolista);
            db.SaveChanges();

            return Ok(futbolista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FutbolistaExists(int id)
        {
            return db.Futbolista.Count(e => e.id == id) > 0;
        }
    }
}