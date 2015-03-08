using System.Collections.Generic;
using System.Web.Http;
using QueryServices;
using CodePatterns.Model;

namespace Angular.Controllers
{
    public class CountriesForContinentController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Country> Get(int continentId)
        {
            var controller = new CountryQueryService();
            return controller.GetByContinent(continentId);
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