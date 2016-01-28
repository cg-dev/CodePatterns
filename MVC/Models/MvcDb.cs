namespace MVC.Models
{
    using System.Data.Entity;

    public class MvcDb : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}