using System.Collections.Generic;
using System.Web.Http;
using QueryServices;
using CodePatterns.Model;

namespace Angular2.Controllers
{
    public class ContinentController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Continent> Get()
        {
            var controller = new ContinentQueryService();
            return controller.Get();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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