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
    public class BeerTypesController : ApiController
    {
        private BeerDBEntities db = new BeerDBEntities();

        // GET: api/BeerTypes
        public IQueryable<BeerType> GetBeerTypes()
        {
            return db.BeerTypes;
        }

        // GET: api/BeerTypes/5
        [ResponseType(typeof(BeerType))]
        public async Task<IHttpActionResult> GetBeerType(int id)
        {
            BeerType beerType = await db.BeerTypes.FindAsync(id);
            if (beerType == null)
            {
                return NotFound();
            }

            return Ok(beerType);
        }

        // PUT: api/BeerTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBeerType(int id, BeerType beerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beerType.Id)
            {
                return BadRequest();
            }

            db.Entry(beerType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerTypeExists(id))
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

        // POST: api/BeerTypes
        [ResponseType(typeof(BeerType))]
        public async Task<IHttpActionResult> PostBeerType(BeerType beerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BeerTypes.Add(beerType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = beerType.Id }, beerType);
        }

        // DELETE: api/BeerTypes/5
        [ResponseType(typeof(BeerType))]
        public async Task<IHttpActionResult> DeleteBeerType(int id)
        {
            BeerType beerType = await db.BeerTypes.FindAsync(id);
            if (beerType == null)
            {
                return NotFound();
            }

            db.BeerTypes.Remove(beerType);
            await db.SaveChangesAsync();

            return Ok(beerType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeerTypeExists(int id)
        {
            return db.BeerTypes.Count(e => e.Id == id) > 0;
        }
    }
}