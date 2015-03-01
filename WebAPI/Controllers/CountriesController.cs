using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodePatterns.Model;

namespace WebAPI.Controllers
{
    public class CountriesController : ApiController
    {
        private List<Country> _countries;

        public CountriesController()
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
            return this._countries;
        }

        // GET api/<controller>/5
        public Country Get(int id)
        {
            var country = this._countries.SingleOrDefault(c => c.Id == id);

            if (country != null)
            {
                return country;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}