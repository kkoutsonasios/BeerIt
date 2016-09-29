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
using BeerWebApi.Models;

namespace BeerWebApi.Controllers
{
    public class PresentableBeersController : ApiController
    {
        private BeerDBEntities db = new BeerDBEntities();

        // GET: api/PresentableBeers
        public IQueryable<PresentableBeer> GetPresentableBeers()
        {
            return db.PresentableBeers;
        }

        // GET: api/PresentableBeers/5
        [ResponseType(typeof(PresentableBeer))]
        public async Task<IHttpActionResult> GetPresentableBeer(int id)
        {
            PresentableBeer presentableBeer = await db.PresentableBeers.FindAsync(id);
            if (presentableBeer == null)
            {
                return NotFound();
            }

            return Ok(presentableBeer);
        }

        // PUT: api/PresentableBeers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPresentableBeer(int id, PresentableBeer presentableBeer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != presentableBeer.Id)
            {
                return BadRequest();
            }

            db.Entry(presentableBeer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentableBeerExists(id))
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

        // POST: api/PresentableBeers
        [ResponseType(typeof(PresentableBeer))]
        public async Task<IHttpActionResult> PostPresentableBeer(PresentableBeer presentableBeer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PresentableBeers.Add(presentableBeer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PresentableBeerExists(presentableBeer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = presentableBeer.Id }, presentableBeer);
        }

        // DELETE: api/PresentableBeers/5
        [ResponseType(typeof(PresentableBeer))]
        public async Task<IHttpActionResult> DeletePresentableBeer(int id)
        {
            PresentableBeer presentableBeer = await db.PresentableBeers.FindAsync(id);
            if (presentableBeer == null)
            {
                return NotFound();
            }

            db.PresentableBeers.Remove(presentableBeer);
            await db.SaveChangesAsync();

            return Ok(presentableBeer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PresentableBeerExists(int id)
        {
            return db.PresentableBeers.Count(e => e.Id == id) > 0;
        }
    }
}