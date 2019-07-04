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
using BiblioMetierBOL.Models;

namespace WebAPIEntreprise.Controllers
{
    public class EntrepriseMeresController : ApiController
    {
        private ModelEf1 db = new ModelEf1();

        // GET: api/EntrepriseMeres
        public IQueryable<EntrepriseMere> GetEntrepriseMeres()
        {
            return db.EntrepriseMeres;
        }

        // GET: api/EntrepriseMeres/5
        [ResponseType(typeof(EntrepriseMere))]
        public async Task<IHttpActionResult> GetEntrepriseMere(string id)
        {
            EntrepriseMere entrepriseMere = await db.EntrepriseMeres.FindAsync(id);
            if (entrepriseMere == null)
            {
                return NotFound();
            }

            return Ok(entrepriseMere);
        }

        // PUT: api/EntrepriseMeres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntrepriseMere(string id, EntrepriseMere entrepriseMere)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != entrepriseMere.IDEntreprise)
            {
                return BadRequest();
            }

            db.Entry(entrepriseMere).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrepriseMereExists(id))
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

        // POST: api/EntrepriseMeres
        [ResponseType(typeof(EntrepriseMere))]
        public async Task<IHttpActionResult> PostEntrepriseMere(EntrepriseMere entrepriseMere)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.EntrepriseMeres.Add(entrepriseMere);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntrepriseMereExists(entrepriseMere.IDEntreprise))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = entrepriseMere.IDEntreprise }, entrepriseMere);
        }

        // DELETE: api/EntrepriseMeres/5
        [ResponseType(typeof(EntrepriseMere))]
        public async Task<IHttpActionResult> DeleteEntrepriseMere(string id)
        {
            EntrepriseMere entrepriseMere = await db.EntrepriseMeres.FindAsync(id);
            if (entrepriseMere == null)
            {
                return NotFound();
            }

            db.EntrepriseMeres.Remove(entrepriseMere);
            await db.SaveChangesAsync();

            return Ok(entrepriseMere);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntrepriseMereExists(string id)
        {
            return db.EntrepriseMeres.Count(e => e.IDEntreprise == id) > 0;
        }
    }
}