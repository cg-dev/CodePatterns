namespace EntityFramework.Tests
{
    using System.Linq;

    using CodePatterns.Entities;

    using NUnit.Framework;

    [TestFixture]
    public class EntityFrameworkTests
    {
        [TearDown]
        public void TearDown()
        {
            using (var db = new EntityFrameworkContext())
            {
                var continents = db.Continents.Where(c => c.Name.ToLower().Contains("continent"));
                foreach (var continent in continents)
                {
                    db.Continents.Remove(continent);
                }
                var countries = db.Countries.Where(c => c.Name.ToLower().Contains("country"));
                foreach (var country in countries)
                {
                    db.Countries.Remove(country);
                }
                db.SaveChanges();
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


        [Test]
        public void EntityFrameworkShouldAddUpdateAndDeleteACountryInTheDatabase()
        {
            using (var db = new EntityFrameworkContext())
            {
                var newContinent = new Continent { Name = "New continent" };
                db.Continents.Add(newContinent);
                db.SaveChanges();


                var newCountry = new Country { Name = "New country" };
                db.Countries.Add(newCountry);
                Assert.AreEqual(1, db.SaveChanges());

                var countryId = db.Countries.Single(c => c.Name == "New country").CountryId;

                Assert.AreEqual(countryId, db.Countries.Single(c => c.Name == "New country").CountryId);

                var updateCountry = db.Countries.Single(c => c.CountryId == countryId);
                updateCountry.Name = "Updated country";
                Assert.AreEqual(1, db.SaveChanges());

                Assert.AreEqual(countryId, db.Countries.Single(c => c.Name == "Updated country").CountryId);

                var removeCountry = db.Countries.Single(c => c.CountryId == countryId);
                db.Countries.Remove(removeCountry);
                Assert.AreEqual(1, db.SaveChanges());

                Assert.AreEqual(0, db.Countries.Select(c => c.Name.ToLower().Contains("country")).Count());
            }
        }
    }
}