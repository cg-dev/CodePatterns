namespace EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using CodePatterns.Entities;

    public class EntityDataModel : DbContext
    {
        // Your context has been configured to use a 'EntityDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EntityFramework.EntityDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EntityDataModel' 
        // connection string in the application configuration file.
        public EntityDataModel()
            : base("name=EntityDataModel")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
    }
}