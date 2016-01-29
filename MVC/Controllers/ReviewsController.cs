using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    using System.Data.Entity;

    using MVC.Models;

    public class ReviewsController : Controller
    {
        private MvcDb _db = new MvcDb();

        public ActionResult Index([Bind(Prefix="id")]int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);

            if (restaurant != null)
            {
                return View(restaurant);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new
                                                 {
                                                     id = review.RestaurantId
                                                 });
            }

            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var review = _db.Reviews.Find(id);
            return View(review);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }

            return View(review);
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