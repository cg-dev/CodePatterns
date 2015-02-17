namespace EntityFramework.Tests
{
    using System.Linq;

    using CodePatterns.Entities;

    using NUnit.Framework;

    [TestFixture]
    public class EntityFrameworkTests
    {
        [SetUp]
        public void SetUp()
        {
            using (var db = new EntityFrameworkContext())
            {
                var continents = db.Continents.Where(c => c.Name.ToLower().Contains("continent"));
                foreach (var continent in continents)
                {
                    db.Continents.Remove(continent);
                    db.SaveChanges();
                }
            }
        }

        [Test]
        public void EntityFrameworkShouldAddUpdateAndDeleteAContinentInTheDatabase()
        {
            using (var db = new EntityFrameworkContext())
            {
                var newContinent = new Continent { Name = "New continent" };
                db.Continents.Add(newContinent);
                Assert.AreEqual(1, db.SaveChanges());

                var continentId = db.Continents.Single(c => c.Name == "New continent").Id;

                Assert.AreEqual(continentId, db.Continents.Single(c => c.Name == "New continent").Id);

                var updateContinent = db.Continents.Single(c => c.Id == continentId);
                updateContinent.Name = "Updated continent";
                Assert.AreEqual(1, db.SaveChanges());

                Assert.AreEqual(continentId, db.Continents.Single(c => c.Name == "Updated continent").Id);

                var removeContinent = db.Continents.Single(c => c.Id == continentId);
                db.Continents.Remove(removeContinent);
                Assert.AreEqual(1, db.SaveChanges());

                Assert.AreEqual(0, db.Continents.Select(c => c.Name.ToLower().Contains("continent")).Count());
            }
        }
    }
}