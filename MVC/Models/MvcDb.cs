namespace MVC.Models
{
    using System.Data.Entity;

    public class MvcDb : DbContext
    {
        public MvcDb() : base("MvcConnectionString")
        {
            
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}