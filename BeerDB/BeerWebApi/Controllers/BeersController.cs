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
    public class BeersController : ApiController
    {
        private BeerDBEntities db = new BeerDBEntities();

        [HttpGet]
        [ActionName("Search")]
        public IQueryable<PresentableBeer> SearchBeers(string args)
        {
            return (from x in db.PresentableBeers where x.BeerName.Contains(args) select x);
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IQueryable<PresentableBeer> GetAll()
        {
            return db.PresentableBeers;
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IHttpActionResult> PostBeer(BeerDTO args)
        {
            Beer beer;

            //check if beer exist
            beer = await (from x in db.Beers where x.Name == args.BeerName select x).FirstOrDefaultAsync();

            if (beer != null)
            {
                //if beer exists and BeerDTO has rating update its rating
                if (args.BeerRating.HasValue)
                {
                    BeerRating beerRating = new BeerRating() { BeerId = beer.Id, Rating = args.BeerRating.GetValueOrDefault() };
                    db.BeerRatings.Add(beerRating);
                }
                else
                {
                    //Can't insert a beer that already exists
                    return BadRequest("Can't insert a beer that already exists");
                }
            }
            else
            {
                BeerType beerType;

                //check if type exists, if exists assign it to the beer
                beerType = await (from x in db.BeerTypes where x.Name == args.BeerType select x).FirstOrDefaultAsync();

                //else create it
                if (beerType == null)
                {
                    beerType = new BeerType() { Name = args.BeerType };
                    db.BeerTypes.Add(beerType);
                }

                beer = new Beer() { Name = args.BeerName, TypeId = beerType.Id };

                //insert the new beer
                db.Beers.Add(beer);

                if (args.BeerRating.HasValue)
                {
                    BeerRating beerRating = new BeerRating() { BeerId = beer.Id, Rating = args.BeerRating.GetValueOrDefault() };
                    db.BeerRatings.Add(beerRating);
                }
            }
            await db.SaveChangesAsync();

            return Ok("Good");
        }

        [HttpPut]
        [ActionName("Rate")]
        public async Task<IHttpActionResult> RateByName(BeerRatingDTO args)
        {
            int BeerId = (from x in db.PresentableBeers where x.BeerName == args.BeerName select x.BeerId).FirstOrDefault();

            if (BeerId > 0)
            {
                db.BeerRatings.Add(new BeerRating() { BeerId = BeerId, Rating = args.BeerRating });
                await db.SaveChangesAsync();
                return Ok("Good");
            }
            else
            {
                return BadRequest("Beer not found!");
            }
        }
    }
}