﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeerWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BeerDBEntities : DbContext
    {
        public BeerDBEntities()
            : base("name=BeerDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<BeerRating> BeerRatings { get; set; }
        public virtual DbSet<BeerType> BeerTypes { get; set; }
        public virtual DbSet<PresentableBeer> PresentableBeers { get; set; }
    }
}
