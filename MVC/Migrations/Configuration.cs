namespace MVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC.Models.MvcDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC.Models.MvcDb";
        }

        protected override void Seed(MVC.Models.MvcDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant
                {
                    Name = "Henry's House",
                    City = "Bedford",
                    Country = "United Kingdon"
                },
                new Restaurant
                {
                    Name = "Chez Pierre",
                    City = "Paris",
                    Country = "France",
                    Reviews = new List<RestaurantReview>
                              {
                                  new RestaurantReview
                                  {
                                      Rating = 6,
                                      Body = "Too expensive",
                                      ReviewerName = "Gaston"
                                  }
                              }
                },
                new Restaurant
                {
                    Name = "Cassa Juan",
                    City = "Madrid",
                    Country = "Spain"
                });
        }
    }
}
