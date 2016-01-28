namespace MVC.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MVC.Models;

    public class HomeController : Controller
    {
        MvcDb _db = new MvcDb();

        public ActionResult Index()
        {
            var model = _db.Restaurants.ToList();

            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel
            {
                Name = "Chris", //this.RouteData.Values["controller"].ToString(),
                Location = "Milton Keynes, United Kingdom" //this.RouteData.Values["action"].ToString()
            };

            ViewBag.Message = "Your app description page.";
            ViewBag.Location = "Milton Keynes, UK";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}