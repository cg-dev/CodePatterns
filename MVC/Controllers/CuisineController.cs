using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        public ActionResult Search(string name = "French")
        {
            var message = Server.HtmlEncode(name);

            return Content(message);
        }
    }
}