using System.Web.Mvc;

namespace MVC.Controllers
{
    using System;

    using MVC.Filters;

    [Log]
    public class CuisineController : Controller
    {
        //[HttpPost] // Action selector
        //public ActionResult Search(string name = "French")
        //{
        //    var message = Server.HtmlEncode(name);

        //    return Content(message);
        //}

        //[HttpGet] // Action selector
        //public ActionResult Search()
        //{
        //    return Content("Search HttpPost!");
        //}

        // [Authorize] // Action filter
        public ActionResult Search(string name = "French")
        {
            throw new Exception("Something dreadful has happened");

            var message = Server.HtmlEncode(name);

            return Content(message);
        }
    }
}