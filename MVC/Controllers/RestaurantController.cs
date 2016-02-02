using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    using System.Data.Entity;

    using MVC.Models;

    public class RestaurantController : Controller
    {
        private MvcDb _db = new MvcDb();

        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        public ActionResult Edit(int id)
        {
            var restaurant = _db.Restaurants.Find(id);

            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Edit(int id, Restaurant restaurant)
        {
                if (ModelState.IsValid)
                {
                    _db.Entry(restaurant).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(restaurant);
        }

        public ActionResult Delete(int id)
        {
            var restaurant = _db.Restaurants.Find(id);

            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Delete(int id, Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Deleted;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
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