using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerWebApi.Models
{
    public class BeerDTO
    {
        public BeerDTO()
        {

        }
        public string BeerName { get; set; }
        public string BeerType { get; set; }
        public int? BeerRating { get; set; }
    }
}
