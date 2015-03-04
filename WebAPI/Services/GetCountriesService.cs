namespace WebAPI.Services
{
    using System.Collections.Generic;

    using CodePatterns.Model;

    public class GetCountriesService
    {
        private List<Country> _countries;

        public GetCountriesService()
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

        public IEnumerable<Country> Get()
        {
            var retVal = this._countries;

            return retVal;
        }
    }
}