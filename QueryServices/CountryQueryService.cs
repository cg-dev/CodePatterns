using System.Collections.Generic;
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
    }
}