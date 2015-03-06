using System.Collections.Generic;
using CodePatterns.Model;

namespace QueryServices
{
    public class ContinentQueryService
    {
        public IEnumerable<Continent> Get()
        {

            var continents = new List<Continent>(); 
            
            using (var context = new CodePatternsContext())
            {
                foreach (var continent in context.Continents)
                {
                    continents.Add(new Continent
                    {
                        Id = continent.Id,
                        Name = continent.Name
                    });
                }
            }

            return continents;
        }
    }
}