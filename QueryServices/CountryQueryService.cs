using System.Collections.Generic;
using System.Linq;
using CodePatterns.Model;

namespace QueryServices
{
    public class CountryQueryService
    {
        public IEnumerable<Country> Get()
        {
            using (var context = new CodePatternsContext())
            {
                var countries = new List<Country>();

                foreach (var country in context.Countries)
                {
                    countries.Add(new Country
                    {
                        Id = country.Id,
                        Name = country.Name
                    });
                }

                return countries;
            }
        }

        public Country GetById(int id)
        {
            if (id == 0)
            {
                return new Country();
            }

            using (var context = new CodePatternsContext())
            {
                var myTest = context.Countries.SingleOrDefault(c => c.Id == id);
                return myTest;
            }
        }

        public IEnumerable<Country> GetByContinent(int id)
        {
            if (id == 0)
            {
                return this.Get();
            }

            using (var context = new CodePatternsContext())
            {
                var countries = new List<Country>();

                foreach (var country in context.Countries.Where(c => c.ContinentId == id))
                {
                    countries.Add(new Country
                        {
                            Id = country.Id,
                            Name = country.Name
                        });
                }

                return countries;
            }
        }
    }
}