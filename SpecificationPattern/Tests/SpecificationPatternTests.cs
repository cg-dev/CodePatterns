namespace SpecificationPattern.Tests
{
    using System.Linq;

    using CodePatterns.Entities;
    using CodePatterns.Model;

    using NUnit.Framework;

    using SpecificationPattern.Interfaces;

    [TestFixture]
    public class SpecificationPatternTests
    {
        private World _world;

        private ISpecification<Country> _englishSpeaking;
        private ISpecification<Country> _european;
        private ISpecification<Country> _inEuroZone;

        [SetUp]
        public void SetUp()
        {
            this._world = new World();

            _englishSpeaking = new ExpressionSpecification<Country>(c => c.Language == "English");
            _european = new ExpressionSpecification<Country>(c => c.Continent.Name == "Europe");
            _inEuroZone = new ExpressionSpecification<Country>(c => c.Currency == "EUR");
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenASingleSpecificationIsUsed()
        {
            var result = _world.Countries.FindAll(_englishSpeaking.IsSatisfiedBy);

            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenAndSpecificationIsUsed()
        {
            var result = _world.Countries.FindAll(_englishSpeaking.And(_european).IsSatisfiedBy);

            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenOrSpecificationIsUsed()
        {
            var result = _world.Countries.FindAll(_englishSpeaking.Or(_european).IsSatisfiedBy);

            Assert.AreEqual(7, result.Count());
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenNotSpecificationIsUsed()
        {
            var result = _world.Countries.FindAll(_englishSpeaking.Not(_european).IsSatisfiedBy);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenAndOrAondNotSpecificationAreUsed()
        {
            var result = _world.Countries.FindAll(_englishSpeaking.And(_european).Or(_european.Not(_inEuroZone)).IsSatisfiedBy);

            Assert.AreEqual(2, result.Count());
        }
    }
}