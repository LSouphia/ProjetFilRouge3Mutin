using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BiblioMetierBOL;

namespace WebAPIContrat.Controllers
{
    public class ContratsController : ApiController
    {
        private ModelEf db = new ModelEf();

        // GET: api/Contrats
        public IQueryable<Contrat> GetContrats()
        {
            return db.Contrats;
        }

        // GET: api/Contrats/5
        [ResponseType(typeof(Contrat))]
        public async Task<IHttpActionResult> GetContrat(string id)
        {
            Contrat contrat = await db.Contrats.FindAsync(id);
            if (contrat == null)
            {
                return NotFound();
            }

            return Ok(contrat);
        }

        // PUT: api/Contrats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContrat(string id, Contrat contrat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contrat.IDContrat)
            {
                return BadRequest();
            }

            db.Entry(contrat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratExists(id))
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

        // POST: api/Contrats
        [ResponseType(typeof(Contrat))]
        public async Task<IHttpActionResult> PostContrat(Contrat contrat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contrats.Add(contrat);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContratExists(contrat.IDContrat))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = contrat.IDContrat }, contrat);
        }

        // DELETE: api/Contrats/5
        [ResponseType(typeof(Contrat))]
        public async Task<IHttpActionResult> DeleteContrat(string id)
        {
            Contrat contrat = await db.Contrats.FindAsync(id);
            if (contrat == null)
            {
                return NotFound();
            }

            db.Contrats.Remove(contrat);
            await db.SaveChangesAsync();

            return Ok(contrat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContratExists(string id)
        {
            return db.Contrats.Count(e => e.IDContrat == id) > 0;
        }
    }
}