﻿using System;
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
    public class RatingsController : ApiController
    {
        private BeerDBEntities db = new BeerDBEntities();

        // GET: api/Ratings
        public IQueryable<Rating> GetRatings()
        {
            return db.Ratings;
        }

        // GET: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> GetRating(int id)
        {
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        // PUT: api/Ratings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRating(int id, Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rating.BeerId)
            {
                return BadRequest();
            }

            db.Entry(rating).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        // POST: api/Ratings
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> PostRating(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ratings.Add(rating);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RatingExists(rating.BeerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rating.BeerId }, rating);
        }

        // DELETE: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> DeleteRating(int id)
        {
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            db.Ratings.Remove(rating);
            await db.SaveChangesAsync();

            return Ok(rating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RatingExists(int id)
        {
            return db.Ratings.Count(e => e.BeerId == id) > 0;
        }
    }
}