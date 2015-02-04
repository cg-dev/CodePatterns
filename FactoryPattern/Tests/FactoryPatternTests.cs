namespace FactoryPattern.Tests
{
    using System;

    using CodePatterns.Entities;

    using FactoryPattern.Pattern;

    using NUnit.Framework;

    [TestFixture]
    class FactoryPatternTests
    {
        [TestCase(AccountTypes.ChequeAccount, typeof(ChequeAccount))]
        [TestCase(AccountTypes.CreditCardAccount, typeof(CreditCardAccount))]
        [TestCase(AccountTypes.SavingsAccount, typeof(SavingsAccount))]
        public void TheFactoryPatternShouldReturnANewObjectOfTheTypeThatIsRequested(AccountTypes accountType, Type type)
        {
            var result = AccountFactory.Create(accountType);

            Assert.IsTrue(result.GetType() == type);
        }
    }
}