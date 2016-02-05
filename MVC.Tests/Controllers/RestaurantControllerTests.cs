using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.Tests.Controllers
{
    using MVC.Controllers;
    using MVC.Models;

    using NUnit.Framework;

    [TestFixture]
    public class RestaurantControllerTests
    {
        [Test]
        public void CreateSavesRestaurantWhenValid()
        {
            var db = NewFakeDb();
            var controller = new RestaurantController(db);

            controller.Create(new Restaurant());

            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.Saved);
        }

        [Test]
        public void CreateDoesNotSaveRestaurantWhenInvalid()
        {
            var db = NewFakeDb();
            var controller = new RestaurantController(db);
            controller.ModelState.AddModelError("", "Invalid");

            controller.Create(new Restaurant());

            Assert.AreEqual(0, db.Added.Count);
        }

        private static FakeMvcDb NewFakeDb()
        {
            var db = new FakeMvcDb();
            db.AddSet(TestData.Restaurants);
            return db;
        }
    }
}