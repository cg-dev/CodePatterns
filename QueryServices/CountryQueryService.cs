using System.Collections.Generic;
using CodePatterns.Model;

namespace QueryServices
{
    public class CountryQueryService
    {
        private List<Country> _countries;

        public CountryQueryService()
        {
            this._countries = new List<Country>{
                    new Country {Id = 1, Name = "England"},
                    new Country {Id = 2, Name = "Wales"},
                    new Country {Id = 3, Name = "Scotland"},
                    new Country {Id = 4, Name = "Ireland"},
                    new Country {Id = 5, Name = "France"},
                    new Country {Id = 6, Name = "Italy"}
            };
        }

        // GET api/<controller>
        public IEnumerable<Country> Get()
        {
            var retVal = this._countries;

            return retVal;
        }
    }
}