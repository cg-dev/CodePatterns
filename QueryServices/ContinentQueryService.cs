using System.Collections.Generic;
using CodePatterns.Model;

namespace QueryServices
{
    public class ContinentQueryService
    {
        private CodePatternsConnectionString _context;

        public ContinentQueryService()
        {
            _context = new CodePatternsConnectionString();
        }

        // GET api/<controller>
        public IEnumerable<Continent> Get()
        {
            var continents = new List<Continent>();

            foreach (var continent in _context.Continents)
            {
                continents.Add(new Continent
                               {
                                   Id = continent.Id,
                                   Name = continent.Name
                               });
            }

            return continents;
        }
    }
}