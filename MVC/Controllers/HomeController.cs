namespace MVC.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MVC.Models;
    using MVC.ViewModels;

    using PagedList;

    public class HomeController : Controller
    {
        MvcDb _db = new MvcDb();

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
                   .Where(r => r.Name.Contains(term))
                   .Take(10)
                   .OrderBy(r => r.Name)
                   .Select(r => new 
                   {
                       label = r.Name
                   })
                   .ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model = _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(rv => rv.Rating))
                .ThenBy(r => r.Name)
                .Where(r => searchTerm == null || r.Name.Contains(searchTerm))
                .Select(r => new RestaurantListViewModel
                             {
                                 Id = r.Id,
                                 Name = r.Name,
                                 City = r.City,
                                 Country = r.Country,
                                 NumberOfReviews = r.Reviews.Count
                             })
                .ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_RestaurantList", model);
            }

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