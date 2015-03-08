using System.Collections.Generic;
using System.Linq;
using CodePatterns.Model;

namespace QueryServices
{
    public class CountryQueryService
    {
        public IEnumerable<Country> Get()
        {

            var countries = new List<Country>();

            using (var context = new CodePatternsContext())
            {
                foreach (var country in context.Countries)
                {
                    countries.Add(new Country
                    {
                        Id = country.Id,
                        Name = country.Name
                    });
                }
            }

            return countries;
        }

        public IEnumerable<Country> GetByContinent(int id)
        {
            if (id == 0)
            {
                return this.Get();
            }

            var countries = new List<Country>();

            using (var context = new CodePatternsContext())
            {
                foreach (var country in context.Countries.Where(c => c.ContinentId == id))
                {
                    countries.Add(new Country
                    {
                        Id = country.Id,
                        Name = country.Name
                    });
                }
            }

            return countries;
        }
    }
}