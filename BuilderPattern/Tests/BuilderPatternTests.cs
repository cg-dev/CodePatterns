using BuilderPattern.Pattern;
using NUnit.Framework;

namespace BuilderPattern.Tests
{
    [TestFixture]
    public class BuilderPatternTests
    {
        private const string testName = "Brazil";
        private const int testContinentId = 5;
        private const string testContinent = "South America";
        private const string testCurrency = "BRL";
        private const string testLanguage = "Portugese";
        private const string defaultString = "Default";

        private CountryBuilder _builder;

        [SetUp]
        public void SetUp()
        {
            _builder = new CountryBuilder();
        }

        [Test]
        public void TheBuilderPatternShouldReturnADefaultObjectIfNoValuesAreProvided()
        {
            var country = _builder.Build();

            Assert.AreEqual("Default", country.Name);
            Assert.AreEqual("Default", country.Continent.Name);
            Assert.AreEqual("Default", country.Currency);
            Assert.AreEqual("Default", country.Language);
        }

        [Test]
        public void TheBuilderPatternShouldReturnAnObjectWithDefaultsAndValuesIfSomeValuesAreProvided()
        {
            var country = _builder.WithName(testName).WithLanguage(testLanguage).Build();

            Assert.AreEqual(testName, country.Name);
            Assert.AreEqual(defaultString, country.Continent.Name);
            Assert.AreEqual(defaultString, country.Currency);
            Assert.AreEqual(testLanguage, country.Language);
        }

        [Test]
        public void TheBuilderPatternShouldReturnAnObjectWithNoDefaultValuesIfAllValuesAreProvided()
        {
            var country = _builder.WithName(testName).WithLanguage(testLanguage).WithContinent(testContinentId, testContinent).WithCurrency(testCurrency).Build();

            Assert.AreEqual(testName, country.Name);
            Assert.AreEqual(testContinent, country.Continent.Name);
            Assert.AreEqual(testCurrency, country.Currency);
            Assert.AreEqual(testLanguage, country.Language);
        }
    }
}
