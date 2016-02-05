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
        private IMvcDb _db;

        public RestaurantController()
        {
            _db = new MvcDb();
        }

        public RestaurantController(IMvcDb db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Query<Restaurant>().ToList());
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
                _db.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        public ActionResult Edit(int id)
        {
            var restaurant = _db.Query<Restaurant>()
                .Single(r => r.Id == id);

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
                    _db.Update(restaurant);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(restaurant);
        }

        public ActionResult Delete(int id)
        {
            var restaurant = _db.Query<Restaurant>().Single(r => r.Id == id);

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
                _db.Remove(restaurant);
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