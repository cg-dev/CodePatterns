namespace OO.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void DepositingFundsShouldReturnTheCorrectNewBalance()
        {
            var sut = new Account(() => Console.WriteLine("CallBack executed"));
            sut.Deposit(10);
            sut.Deposit(1);

            Assert.AreEqual(11, sut.Balance);
        }
        [Test]
        public void DepositingFundsShouldReturnTheCorrectTypeForTheAccountState()
        {
            var sut = new Account(() => Console.WriteLine("CallBack executed"));
            sut.Deposit(10);
            sut.Deposit(1);

            Assert.IsInstanceOf(typeof(Active), sut.State);
        }
    }
}