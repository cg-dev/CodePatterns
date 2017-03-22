namespace OO.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void GivenAnUnverifiedAccountWhenDepositingFundsIShouldGetBackTheCorrectNewBalance()
        {
            var sut = new Account(this.UnFreeze);
            sut.Deposit(10);
            sut.Deposit(1);

            Assert.AreEqual(11, sut.Balance);
        }

        [Test]
        public void GivenAnUnverifiedAccountWhenDepositingFundsIShouldGetBackAnActiveState()
        {
            var sut = new Account(() => this.UnFreeze());
            sut.Deposit(10);
            sut.Deposit(1);

            Assert.IsInstanceOf(typeof(Active), sut.State);
        }

        [Test]
        public void GivenAnUnverifiedAccountWhenWithdrawingFundsIShouldGetBAckAnUnchangedBalance()
        {
            var sut = new Account(this.UnFreeze, 20);

            sut.Withdraw(10);

            Assert.AreEqual(20, sut.Balance);
        }

        [Test]
        public void GivenAnUnverifiedAccountWhenWithdrawingFundsIShouldGetBackAnUnchangedState()
        {
            var sut = new Account(this.UnFreeze, 20);

            sut.Withdraw(10);

            Assert.IsInstanceOf(typeof(NotVerified), sut.State);
        }

        private void UnFreeze()
        {
            Console.WriteLine("Callback executing");
            Console.Read();
        }
    }
}