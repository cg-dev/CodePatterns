namespace FactoryPattern.Tests
{
    using CodePatterns.Entities;

    using FactoryPattern.Pattern;

    using NUnit.Framework;

    [TestFixture]
    class FactoryPatternTests
    {
        [Test]
        public void TheFactoryPatternShouldReturnANewObjectOfTheTypeThatIsRequested()
        {
            var result = AccountFactory.Create(2);

            Assert.IsFalse(result.GetType() == typeof(ChequeAccount));
            Assert.IsTrue(result.GetType() == typeof(CreditCardAccount));
            Assert.IsFalse(result.GetType() == typeof(SavingsAccount));
        }
    }
}