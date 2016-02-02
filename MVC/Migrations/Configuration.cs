namespace MVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Web.Security;

    using MVC.Models;

    using WebMatrix.WebData;

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

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                                    new Restaurant
                {
                    Name = "Restaurant: " + i.ToString(CultureInfo.InvariantCulture),
                    City = "Nowhere",
                    Country = "USA"
                });
            }

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("MvcConnectionString", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("admin"))
            {
                roles.CreateRole("admin");
            }

            if (membership.GetUser("chris", false) == null)
            {
                membership.CreateUserAndAccount("chris", "password");
            }

            if (!roles.GetRolesForUser("chris").Contains("admin"))
            {
                roles.AddUsersToRoles(new[] { "chris" }, new[] { "admin" });
            }
        }
    }
}