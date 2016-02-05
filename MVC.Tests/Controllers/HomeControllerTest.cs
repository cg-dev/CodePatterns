using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MVC.Controllers;

namespace MVC.Tests.Controllers
{
    using MVC.ViewModels;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(NewFakeDb());
            controller.ControllerContext = new FakeControllerContext();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<RestaurantListViewModel>;

            // Assert
            Assert.AreEqual(10, model.Count());
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(NewFakeDb());

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(NewFakeDb());

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        private static FakeMvcDb NewFakeDb()
        {
            var db = new FakeMvcDb();
            db.AddSet(TestData.Restaurants);
            return db;
        }
    }
}