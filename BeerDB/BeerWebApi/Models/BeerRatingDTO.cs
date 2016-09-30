using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerWebApi.Models
{
    public class BeerRatingDTO
    {
        public BeerRatingDTO()
        {
        }

        public string BeerName { get; set; }
        public int BeerRating { get; set; }
    }
}