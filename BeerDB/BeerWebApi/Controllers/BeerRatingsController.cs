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
    public class BeerRatingsController : ApiController
    {
        private BeerDBEntities db = new BeerDBEntities();

        // GET: api/BeerRatings
        public IQueryable<BeerRating> GetBeerRatings()
        {
            return db.BeerRatings;
        }

        // GET: api/BeerRatings/5
        [ResponseType(typeof(BeerRating))]
        public async Task<IHttpActionResult> GetBeerRating(int id)
        {
            BeerRating beerRating = await db.BeerRatings.FindAsync(id);
            if (beerRating == null)
            {
                return NotFound();
            }

            return Ok(beerRating);
        }

        // PUT: api/BeerRatings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBeerRating(int id, BeerRating beerRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beerRating.BeerId)
            {
                return BadRequest();
            }

            db.Entry(beerRating).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerRatingExists(id))
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

        // POST: api/BeerRatings
        [ResponseType(typeof(BeerRating))]
        public async Task<IHttpActionResult> PostBeerRating(BeerRating beerRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BeerRatings.Add(beerRating);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BeerRatingExists(beerRating.BeerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = beerRating.BeerId }, beerRating);
        }

        // DELETE: api/BeerRatings/5
        [ResponseType(typeof(BeerRating))]
        public async Task<IHttpActionResult> DeleteBeerRating(int id)
        {
            BeerRating beerRating = await db.BeerRatings.FindAsync(id);
            if (beerRating == null)
            {
                return NotFound();
            }

            db.BeerRatings.Remove(beerRating);
            await db.SaveChangesAsync();

            return Ok(beerRating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeerRatingExists(int id)
        {
            return db.BeerRatings.Count(e => e.BeerId == id) > 0;
        }
    }
}