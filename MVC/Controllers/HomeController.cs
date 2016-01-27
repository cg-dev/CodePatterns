namespace MVC.Controllers
{
    using System.Web.Mvc;

    using MVC.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
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
    }
}