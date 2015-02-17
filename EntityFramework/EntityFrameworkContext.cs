namespace EntityFramework
{
    using System.Data.Entity;

    using CodePatterns.Entities;

    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext()
            : base("name=EntityFrameworkContext")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
    }
}