using System;
using System.Linq;

using CodePatterns.Entities;

using EntityFramework;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new EntityFrameworkContext())
        {
            // Create and save a new continent 
            Console.Write("Enter a name for a new continent: ");
            var name = Console.ReadLine();

            var continent = new Continent { Name = name };
            db.Continents.Add(continent);
            db.SaveChanges();

            // Display all continents from the database 
            var query = from b in db.Continents
                        orderby b.Name
                        select b;

            Console.WriteLine("All continents in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}