namespace SpecificationPattern.Tests
{
    using System.Linq;

    using NUnit.Framework;

    using SpecificationPattern.Entities;
    using SpecificationPattern.Interfaces;

    [TestFixture]
    public class SpecificationPatternTests
    {
        private World World;

        private ISpecification<Country> EnglishSpeaking;
        private ISpecification<Country> European;
        private ISpecification<Country> InEuroZone;

        [SetUp]
        public void SetUp()
        {
            this.World = new World();

            this.EnglishSpeaking = new ExpressionSpecification<Country>(c => c.Language == "English");
            this.European = new ExpressionSpecification<Country>(c => c.Continent == "Europe");
            this.InEuroZone = new ExpressionSpecification<Country>(c => c.Currency == "EUR");
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenASingleSpecificationIsUsed()
        {
            var result = this.World.Countries.FindAll(this.EnglishSpeaking.IsSatisfiedBy);

            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenAndSpecificationIsUsed()
        {
            var result = this.World.Countries.FindAll(this.EnglishSpeaking.And(this.European).IsSatisfiedBy);

            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenOrSpecificationIsUsed()
        {
            var result = this.World.Countries.FindAll(this.EnglishSpeaking.Or(this.European).IsSatisfiedBy);

            Assert.AreEqual(7, result.Count());
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenNotSpecificationIsUsed()
        {
            var result = this.World.Countries.FindAll(this.EnglishSpeaking.Not(European).IsSatisfiedBy);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void TheSpecificationPatternShouldReturnCorrectItemsWhenAndOrAondNotSpecificationAreUsed()
        {
            var result = this.World.Countries.FindAll(this.EnglishSpeaking.And(European).Or(this.European.Not(this.InEuroZone)).IsSatisfiedBy);

            Assert.AreEqual(2, result.Count());
        }
    }
}