namespace MVC.Models
{
    using System.Data.Entity;
    using System.Linq;

    public class MvcDb : DbContext, IMvcDb
    {
        public MvcDb() : base("name=MvcConnectionString")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        IQueryable<T> IMvcDb.Query<T>()
        {
            return Set<T>();
        }

        void IMvcDb.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IMvcDb. Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IMvcDb.Remove<T>(T entity)
        {
            //Set<T>().Remove(entity);
            Entry(entity).State = EntityState.Deleted;
        }

        void IMvcDb.SaveChanges()
        {
            SaveChanges();
        }
    }
}