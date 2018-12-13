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
    public class MasajistasController : ApiController
    {
        private Equipo2Entities1 db = new Equipo2Entities1();

        // GET: api/Masajistas
        public IQueryable<Masajista> GetMasajista()
        {
            return db.Masajista;
        }

        // GET: api/Masajistas/5
        [ResponseType(typeof(Masajista))]
        public IHttpActionResult GetMasajista(int id)
        {
            Masajista masajista = db.Masajista.Find(id);
            if (masajista == null)
            {
                return NotFound();
            }

            return Ok(masajista);
        }

        // PUT: api/Masajistas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMasajista(int id, Masajista masajista)
        {
           

            if (id != masajista.id)
            {
                return BadRequest();
            }

            db.Entry(masajista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasajistaExists(id))
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

        // POST: api/Masajistas
        [ResponseType(typeof(Masajista))]
        public IHttpActionResult PostMasajista(Masajista masajista)
        {
           

            db.Masajista.Add(masajista);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MasajistaExists(masajista.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = masajista.id }, masajista);
        }

        // DELETE: api/Masajistas/5
        [ResponseType(typeof(Masajista))]
        public IHttpActionResult DeleteMasajista(int id)
        {
            Masajista masajista = db.Masajista.Find(id);
            if (masajista == null)
            {
                return NotFound();
            }

            db.Masajista.Remove(masajista);
            db.SaveChanges();

            return Ok(masajista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MasajistaExists(int id)
        {
            return db.Masajista.Count(e => e.id == id) > 0;
        }
    }
}