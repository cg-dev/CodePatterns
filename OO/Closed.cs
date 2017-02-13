namespace OO
{
    using System;

    class Closed : IAccountState
    {
        public IAccountState Deposit(Action addToBalance) => this;

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState Verified() => this;

        public IAccountState Close() => this;
    }
}